using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Repositories
{
    public class FileMetadataRepository : GeneralRepository<FileMetadata>,IFileMetadataRepository
    {
        //for special logic
        Context _context;
        public FileMetadataRepository(Context context):base(context) {
          _context = context;
        }
        
        public async Task<FileMetadata> GetFileWithApprovalsAsync(int id)
        {
            return await _context.FileMetadatas
                .Include(f => f.Approvals) 
                .FirstOrDefaultAsync(f => f.ID == id);
        }

    }
}
