using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfFileDownloader
{
    public class FileDownloader
    {
        private IEnumerable<FileInfo> _files;

        public FileDownloader(IEnumerable<FileInfo> files)
        {
            _files = files;
        }

        public async Task DownloadAsync()
        {
            foreach (var file in _files)
            {
                if (file.DownloadState is not DownloadState.Wait)
                    continue;

                var c = new WebClient();
                c.DownloadProgressChanged += (s, e) =>
                {
                    if (file.DownloadState is DownloadState.Wait)
                        file.DownloadState = DownloadState.Downloading;

                    file.BytesReceived = e.BytesReceived;
                    file.TotalBytesToReceive = e.TotalBytesToReceive;
                };
                await c.DownloadFileTaskAsync(new Uri(file.OriginUri), file.Filename);
                file.DownloadState = DownloadState.DownloadComplete;
                c.Dispose();
            }
        }
    }
}
