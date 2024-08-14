using System;
using System.IO;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.FileRepository;
using Entity.Attributes;
using Entity.Models.File;
using Microsoft.AspNetCore.Http;
using Services.Interfaces;

namespace Services.Services
{
    [Injectable]
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async ValueTask<FileModel> UploadFileAsync(IFormFile file)
        {
            var resultFile = await CreateAsync(file);
            await SaveFileAsync(file, resultFile.Path);
            return resultFile;
        }

        public async Task SaveFileAsync(IFormFile file, string filePath)
        {
            try
            {
                var directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Faylni saqlashda xato yuz berdi", ex);
            }
        }

        public async ValueTask<string> MakeFilePath(string filePath)
        {
            var webRootFolder = "wwwroot";
            var path = Path.Combine(Directory.GetCurrentDirectory(), webRootFolder, filePath);

            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return path;
        }

        private async Task<FileModel> CreateAsync(IFormFile file)
        {
            var id = Guid.NewGuid();
            string fileName = id.ToString() + DetectionFileType(file.FileName);
            var resultFile = new FileModel()
            {
                Id = id,
                FileName = fileName,
                ContentType = file.ContentType ?? string.Empty,
                Path = await MakeFilePath(fileName)
            };
            resultFile = await _fileRepository.AddAsync(resultFile);
            return resultFile;
        }

        public string DetectionFileType(string fileName)
        {
            string[] names = fileName.Split('.');
            return "." + names[names.Length - 1];
        }

        public async ValueTask<FileModel> DeleteAsync(Guid id)
        {
            var file = await _fileRepository.GetByIdAsync(id);
            if (file is null)
                throw new Exception("File not found");
            await RemoveFileWebRootFolderAsync(file.Path);
            var result = await _fileRepository.RemoveAsync(file);
            return result;
        }

        private async Task RemoveFileWebRootFolderAsync(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

        public async ValueTask<FileModel> UpdateFileAsync(Guid id, IFormFile file)
        {
            var updateFile = await GetByIdAsync(id);
            updateFile = await UpdateAsync(updateFile, file);
            await RemoveFileWebRootFolderAsync(updateFile.Path);
            await SaveFileAsync(file, updateFile.Path);
            return updateFile;
        }

        private async ValueTask<FileModel> UpdateAsync(FileModel file, IFormFile updateFile)
        {
            file.FileName = updateFile.FileName;
            file.ContentType = updateFile.ContentType;
            file = await _fileRepository.UpdateAsync(file);
            return file;
        }

        public async ValueTask<FileModel> GetByIdAsync(Guid id)
        {
            var file = await _fileRepository.GetByIdAsync(id);
            if (file is null)
                throw new Exception("File not found");
            return file;
        }

        public async Task<Stream> SendFileAsync(Guid id)
        {
            var file = await _fileRepository.GetByIdAsync(id);
            if (file == null || !System.IO.File.Exists(file.Path))
                throw new FileNotFoundException("Fayl topilmadi.");

            var stream = new FileStream(file.Path, FileMode.Open, FileAccess.Read);
            return stream;
        }

        public Task SaveFileAsync(byte[] bytes, string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
