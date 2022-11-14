using ScanerLibrary.Entity;
using System;
using System.Collections.Concurrent;

namespace ScanerLibrary;

public class DirectoryScanner
{
    private static int MaxThreadCount = 1000;
    private static CancellationTokenSource cancelTokenSource;
    private static CancellationToken token;


    private static Semaphore semaphore = new Semaphore(MaxThreadCount, MaxThreadCount);
    private static int runningCount;

    private static void SetPercents(MemoryObject fileData)
    {
        foreach (var child in fileData.Children)
        {
            SetPercents(child);
            if (fileData.Size > 0)
                child.Percentage = Math.Round(child.Size * 100 / fileData.Size, 1);
        }
    }

    private static void SetFolderSize(MemoryObject fileData)
    {
        foreach (var child in fileData.Children)
            SetFolderSize(child);
        if (fileData.Type == MemoryObjectType.Directory)
            fileData.Size = fileData.Children.Sum(x => x.Size);
    }

    private static void ProcessDirectory(object data)
    {
        semaphore.WaitOne();

        var directoryInfo = new DirectoryInfo(((List<object>)data)[1].ToString());
        MemoryObject fileData = new MemoryObject(MemoryObjectType.Directory, directoryInfo.Name);
        fileData.Children = ProcessFiles(((List<object>)data)[1].ToString());
        var fileTree = ((List<object>)data)[0];
        ((ConcurrentBag<MemoryObject>)fileTree).Add(fileData);
        Interlocked.Decrement(ref runningCount);

        semaphore.Release();
    }

    private static string[] CheckAccess(string path)
    {
        string[] filePaths;

        try
        {
            filePaths = Directory.GetFiles(path);
        }
        catch
        {
            return null;
        }

        return filePaths;
    }

    private static ConcurrentBag<MemoryObject> ProcessFiles(string path)
    {
        ConcurrentBag<MemoryObject> fileTree = new ConcurrentBag<MemoryObject>();
        string[] filePaths = CheckAccess(path);

        if (filePaths == null)
            return fileTree;

        foreach (var filePath in filePaths)
        {
            var fileInfo = new FileInfo(filePath);
            //игнорирование символических ссылок
            if (fileInfo.LinkTarget == null)
            {
                MemoryObject fileData = new MemoryObject(
                    MemoryObjectType.File, fileInfo.Name, fileInfo.Length);
                fileTree.Add(fileData);
            }
        }

        string[] directoryPaths = Directory.GetDirectories(path);

        foreach (var directoryPath in directoryPaths)
        {
            if (token.IsCancellationRequested)
                return fileTree;

            if (new DirectoryInfo(directoryPath).LinkTarget == null)
            {
                List<object> data = new List<object>() { fileTree, directoryPath };
                Interlocked.Increment(ref runningCount);
                ThreadPool.QueueUserWorkItem(ProcessDirectory, data);
            }
        }

        return fileTree;
    }

    public static async Task<MemoryObject> StartScan(string path)
    {
        //int inOutThreads = 1;
        //ThreadPool.GetAvailableThreads(out MaxThreadCount, out inOutThreads);

        MemoryObject rootFileTree = null;

        await Task.Run(() =>
        {
            var directoryInfo = new DirectoryInfo(path);

            rootFileTree = new MemoryObject(MemoryObjectType.Directory, directoryInfo.Name);
            rootFileTree.Children = ProcessFiles(path);
            rootFileTree.Percentage = 100;

            while (runningCount > 0 || ThreadPool.PendingWorkItemCount > 0) 
            { 
                //ожидание и снова проверка
                //Thread.Sleep(100);
            }

            if (token.IsCancellationRequested)
            {
                cancelTokenSource.Dispose();
                token = new CancellationToken();
            }

            SetFolderSize(rootFileTree);
            SetPercents(rootFileTree);
        });

        return rootFileTree;
    }

    public static void StopScan()
    {
        cancelTokenSource = new CancellationTokenSource();
        token = cancelTokenSource.Token;
        cancelTokenSource.Cancel();
    }
}