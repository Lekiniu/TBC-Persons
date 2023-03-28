using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Persons.Application.Infrastructure.Services;

namespace Persons.Infrastructure.Services
{
    internal class FileServices : IFileServices
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly string Folder = "Files";
        public FileServices( IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public async Task<string> UploadFile(int personId, IFormFile file)
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            GuidString = GuidString.Replace("/", "");

            var fileNameLength = file.FileName.Length > 10 ? file.FileName.Substring(file.FileName.Length - 10) : file.FileName;
            string fileName = personId + GuidString + fileNameLength;
            if (!Directory.Exists(Path.Combine(_appEnvironment.ContentRootPath, Folder)))
            {
                Directory.CreateDirectory(Path.Combine(_appEnvironment.ContentRootPath,
                    Folder));
            }
            var filePath = Path.Combine(_appEnvironment.ContentRootPath, Folder, Path.GetExtension(fileName));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return filePath;
        }

        public async Task<byte[]> DownloadFile(string path)
        {
            if (!File.Exists(path)) return null;

            return await File.ReadAllBytesAsync(path);
        }
    }
}
