using System;
using System.IO;
using System.Threading.Tasks;
using Entity.Models.File;
using Microsoft.AspNetCore.Http;
namespace Services.Interfaces;

public interface IFileService
{
    ValueTask<FileModel> UploadFileAsync(IFormFile file);
    ValueTask<FileModel> DeleteAsync(Guid id);
    ValueTask<FileModel> UpdateFileAsync(Guid id, IFormFile file);
    ValueTask<string> MakeFilePath(string filePath);
    string DetectionFileType(string fileName);
    Task SaveFileAsync(IFormFile file, string filePath);
    Task SaveFileAsync(byte[] bytes, string filePath);
    ValueTask<FileModel> GetByIdAsync(Guid id);
    Task<Stream> SendFileAsync(Guid id);
}
