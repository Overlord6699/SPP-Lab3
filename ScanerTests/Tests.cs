using ScanerLibrary;
using ScanerLibrary.Entity;

namespace ScanerTests
{
    public class Tests
    {
      /*  [Fact]
        public void ScanFiles_WhenStopScanning_ReturnNotRealSize()
        {
            double size1, size2;

            var res1 = DirectoryScanner.StartScan("F:");
            size1 = res1.Result.Size;

            var res2 = DirectoryScanner.StartScan("F:");
            DirectoryScanner.StopScan();

            size2 = res2.Result.Size;

            Assert.Equal(size1, size2);

        }*/


        [Fact]
        public void ScanFiles_SetWrongPath_ThrowException()
        {
            Assert.ThrowsAsync<Exception>( () => DirectoryScanner.StartScan("F:/dhdf"));
        }


        [Fact]
        public void ScanFiles_SetNullPath_ThrowException()
        {
            string path = null;
            Assert.ThrowsAsync<Exception>(() => DirectoryScanner.StartScan(path));
        }

        [Fact]
        public void ScanFiles_SetDirectoryWith4Files_ReturnCorrectNumber()
        {
            string path = @"F:\test4";
            MemoryObject data = DirectoryScanner.StartScan(path).Result;
            Assert.Equal(4, data.Children.Count);
        }

        [Fact]
        public void ScanFiles_CheckFilesType_ReturnDirectoryType()
        {
            string path = "F:\\test4";
            var res = DirectoryScanner.StartScan(path).Result;
            Assert.Equal(MemoryObjectType.Directory,res.Type);
        }

        [Fact]
        public void ScanFiles_CheckFilesType_ReturnFileType()
        {
            string path = @"F:\test4";
            var res = DirectoryScanner.StartScan(path).Result;
            var firstChild = res.Children.FirstOrDefault(child => child.Name == "1.txt");
            Assert.Equal(MemoryObjectType.File, firstChild.Type);
        }

        [Fact]
        public void ScanFiles_CheckDirectorySize_ReturnCorrectSize()
        {
            string path = @"F:\test4";
            var res = DirectoryScanner.StartScan(path).Result;
            Assert.Equal(11, res.Size);
        }


        [Fact]
        public void ScanFiles_CheckFilePercentage_ReturnCorrectPercentage()
        {
            string path = @"F:\test4\1.txt";
            var res = DirectoryScanner.StartScan(path).Result;
            Assert.Equal(100, res.Percentage);
        }

        public void ScanFiles_CheckFilesPercentageSum_ReturnTrue()
        {
            string path = @"F:\test4";
            double sum = 0;
            var res = DirectoryScanner.StartScan(path).Result;
            var children = res.Children;

            foreach (MemoryObject child in children)
                sum += child.Percentage;

            Assert.Equal(100, sum);
        }


    }
}