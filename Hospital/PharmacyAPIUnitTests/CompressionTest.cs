using Microsoft.Extensions.Logging;
using PharmacyLibrary.Compression;
using System.IO;
using Xunit;

namespace PharmacyAPIUnitTests
{
    public class CompressionTest
    {
        [Fact]
        public void check_if_files_loaded()
        {
            RoutineZipCompressionService routineZipCompressionService = new RoutineZipCompressionService();
            string path = System.AppContext.BaseDirectory;
            path = path.Replace(@"\bin\Debug\netcoreapp3.1\" , "/Resources/");
            File.Create(path + "test.pdf").Close();
            var loaded = routineZipCompressionService.LoadAllPDFFiles(path);
            Assert.NotNull(loaded);
            File.Delete(path + "test.pdf");
        }

        [Fact]
        public void check_if_no_files()
        {
            RoutineZipCompressionService routineZipCompressionService = new RoutineZipCompressionService();
            string path = System.AppContext.BaseDirectory;
            path = path.Replace(@"\bin\Debug\netcoreapp3.1\", "/Resources/");
            var not_loaded = routineZipCompressionService.LoadAllPDFFiles(path);
            var empty = not_loaded.Count;
            Assert.Equal(0, empty);
        }


        [Fact]
        public void check_if_not_pdf_file()
        {
            RoutineZipCompressionService routineZipCompressionService = new RoutineZipCompressionService();
            string path = System.AppContext.BaseDirectory;
            path = path.Replace(@"\bin\Debug\netcoreapp3.1\", "/Resources/");
            File.Create(path + "test.txt").Close();
            var not_loaded = routineZipCompressionService.LoadAllPDFFiles(path);
            var count = not_loaded.Count;
            Assert.Equal(0, count);
            File.Delete(path + "test.txt");
        }
        [Fact]
        public void check_if_file_compressed()
        {
              RoutineZipCompressionService routineZipCompressionService = new RoutineZipCompressionService();
            string path = System.AppContext.BaseDirectory;
            path = path.Replace(@"\bin\Debug\netcoreapp3.1\" , "/Resources/");
            File.Create(path + "test.pdf").Close();
            File.SetLastWriteTime(path + "test.pdf", new System.DateTime(1999, 8, 23));
            bool loaded = routineZipCompressionService.Compress(routineZipCompressionService.LoadAllPDFFiles(path), path);
            Assert.True(loaded);
            File.Delete(path +  "23-08-1999.zip");
        }
        [Fact]
        public void check_if_file_not_compressed()
        {
            RoutineZipCompressionService routineZipCompressionService = new RoutineZipCompressionService();
            string path = System.AppContext.BaseDirectory;
            path = path.Replace(@"\bin\Debug\netcoreapp3.1\", "/Resources/");
            bool loaded = routineZipCompressionService.Compress(routineZipCompressionService.LoadAllPDFFiles(path), path);
            Assert.False(loaded);
            
        }

    }
}
