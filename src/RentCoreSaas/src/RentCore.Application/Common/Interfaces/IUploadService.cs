namespace RentCore.Application.Common.Interfaces
{
    public interface IUploadService
    {
        Task<string> Upload(string path, Stream content, string fileName);
        Task DeleteFileAsync(string path, string fileName);
    }
}
