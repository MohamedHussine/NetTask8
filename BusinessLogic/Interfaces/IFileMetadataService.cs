using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DTOs.FileMetadata;

namespace BusinessLogic.Interfaces
{
    public interface IFileMetadataService
    {
        Task<FileMetadataDto> GetFileDetailsAsync(int id);
        Task<bool> ApproveFileAsync(int fileId, string employeeName);
    }
}
