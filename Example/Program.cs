using ScanerLibrary;
using System.Diagnostics;

namespace Example
{
    public static class Program
    {
        static void Main()
        {
            /*
            var scanner = new DirectoryScanner();

            // List of all our entities (files and directories)
            List<MemoryObject> memoryObjects = new List<MemoryObject>();

            // Get head directory for proceeding
            string directoryPath = @"F:\vt";
            DirectoryInfo headDirectory = new DirectoryInfo(directoryPath);

            // Add head directory as an entity
            memoryObjects.Add(scanner.ConvertDirectoryToMemoryObject(headDirectory, isRootDirectory: true));

            // Get files in the head folder
            var files_HeadDirectory = headDirectory.GetFiles();

            // Get all files (normal and directories). Hidden files included
            var filesAndDirectories_HeadDirectory = headDirectory.GetFileSystemInfos();

            // Create a list with only file names
            var fileNames_HeadDirectory = new List<string>();
            foreach (var file in files_HeadDirectory)
                fileNames_HeadDirectory.Add(file.Name);

            var timer = new Stopwatch();
            // Check every file and directory in head directory
            scanner.GetDirectoryIerarchy(memoryObjects, fileNames_HeadDirectory, filesAndDirectories_HeadDirectory);

            // Get all system threads available for usage
            ThreadPool.GetAvailableThreads(out int systemThreadsCount, out _);

            // Start timer to count how much time it took to calculate size of files and directories
            timer.Start();

            // Use this code to proceed all files asynchronously
            scanner.CalculateTotalSize(memoryObjects, isAsync: true, numberOfThreadsToProceed: 7, numberOfSystemThreads: systemThreadsCount);

            // Use this code to proceed all files synchronously
            //CalculateSizeOfAllEntities(entities);

            // Stop timer
            timer.Stop();

            // Print all results using console
            int startIndex = 0;
            string str = "";
            PrintResult(memoryObjects, ref startIndex, ref str, null);

            Console.WriteLine($"\n\nTime spent: {(float)timer.ElapsedMilliseconds / 1000} s");
            Console.ReadLine();
            */
        }

        /*
    // Method for printing all the results on the console 
    static void PrintResult(List<MemoryObject> memoryObjects, ref int index, ref string indent, DirectoryInfo rootDir)
    {
        // Proceed through all list of entities
        while (index <= memoryObjects.Count - 1)
        {
            //для вывода первой директории или всех файлов в директории
            if (index == 0 || memoryObjects[index].RootDirectory.FullName == rootDir?.FullName)
            {
                Console.WriteLine(indent + memoryObjects[index].ToString());

                index += 1;
                continue;
            }
            else
            {
                if (rootDir == null || memoryObjects[index].RootDirectory.FullName.Contains(memoryObjects[index - 1].RootDirectory.FullName))
                {
                    indent += "\t";
                    rootDir = memoryObjects[index].r;
                    continue;
                }
                else
                {
                    rootDir = rootDir.Parent;
                    indent = indent.Length >= 2 ? indent.Remove(0, 1) : indent;
                    continue;
                }
            }
        }

        while (index <= memoryObjects.Count - 1)
        {
            if (memoryObjects[index].RootDirectory.Name == rootDir?.Name)
            {
                PrintResult(memoryObjects, ref index, ref indent, rootDir);
            }
            else
            {
                //если это вложенный файл
                if (rootDir == null || memoryObjects[index].RootDirectory.FullName.Contains(memoryObjects[index - 1].RootDirectory.FullName))
                {
                    indent += "\t";
                    PrintResult(memoryObjects, ref index, ref indent, memoryObjects[index].RootDirectory);
                }
                else
                {
                    //убираем лишний отступ, так как пошла новая директория
                    indent = indent.Length >= 2 ? indent.Remove(0, 2) : indent;
                    return;
                }
            }
        }

    }
        */

    }

}
