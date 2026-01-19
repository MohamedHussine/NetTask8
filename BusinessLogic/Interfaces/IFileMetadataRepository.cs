using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IFileMetadataRepository : IGeneralRepository<FileMetadata>
    {
        Task<FileMetadata> GetFileWithApprovalsAsync(int id);
    }
}
