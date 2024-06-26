using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Interfaces
{
    public interface IFileService
    {
        Task<string?> SaveFileAsync(IFormFile? file);
        Task RemoveFileAsync(string? fileName);
        Stream? GetFileByFileName(string fileName);
        public string GetFilePath(string fileName);
    }
}
