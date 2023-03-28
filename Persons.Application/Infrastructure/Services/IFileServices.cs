using Microsoft.AspNetCore.Http;

namespace Persons.Application.Infrastructure.Services
{
    public interface IFileServices
    {
        Task<string> UploadFile(int personId, IFormFile file);
        Task<byte[]> DownloadFile( string path);
    }
}
