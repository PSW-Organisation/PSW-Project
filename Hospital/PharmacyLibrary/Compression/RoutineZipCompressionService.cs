using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PharmacyLibrary.Compression
{
    public class RoutineZipCompressionService : IHostedService, IDisposable
    {
        public Dictionary<DateTime, IList<FileInfo>> Files = new Dictionary<DateTime, IList<FileInfo>>();
        private int executionCount = 0;
        private readonly ILogger<RoutineZipCompressionService> _logger;
        private Timer _timer = null;
        public RoutineZipCompressionService(ILogger<RoutineZipCompressionService> logger)
        {
            _logger = logger;
        }

        public RoutineZipCompressionService()
        {
        }

        public bool Compress(Dictionary<DateTime, IList<FileInfo>> files, string pathToDo)
        {
            if(files.Count == 0 || files == null)
            {
                return false;
            }
            foreach(var fileCreationDate in files.Keys)
            {
                if(DateTime.Now.AddMonths(-6)> fileCreationDate) {
                    string path = Path.Combine(pathToDo, fileCreationDate.ToString("dd-MM-yyyy") + ".zip");
                    using (var stream = File.OpenWrite(path))
                    using (ZipArchive zip = new ZipArchive(stream, System.IO.Compression.ZipArchiveMode.Create))
                    {
                        foreach (var filename in files[fileCreationDate])
                        {
                            zip.CreateEntryFromFile(filename.FullName, filename.Name, CompressionLevel.Optimal);
                            File.Delete(filename.FullName);
                        }
                    }
                }
            }
            return true;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Dictionary<DateTime, IList<FileInfo>> LoadAllPDFFiles(string path)
        {

            foreach (var file in Directory.GetFiles(path)) {
                var fi = new FileInfo(file);
                var date = fi.LastWriteTime;
                var groupDate = new DateTime(date.Year, date.Month, date.Day);
                if (Path.GetExtension(file).Equals(".pdf")) { 
                if (!Files.ContainsKey(groupDate))
                    Files.Add(groupDate, new Collection<FileInfo>());
                Files[groupDate].Add(fi);
                }
            }
            if(Files.Count == 0)
            {
                return new Dictionary<DateTime, IList<FileInfo>>();
            }
            return Files;

        }

        

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Startovao je kompresioni servis");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(31));
            return Task.CompletedTask;
        }
        private void DoWork(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);
            LoadAllPDFFiles("@../../Resources/Reports");
            Compress(Files, @"../../Hospital/PharmacyAPI/Resources/Reports");
            _logger.LogInformation(
                "Timed Hosted Service is working. Count: {Count}", count);
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Pretsao je da radi");
            _timer.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
    
}
