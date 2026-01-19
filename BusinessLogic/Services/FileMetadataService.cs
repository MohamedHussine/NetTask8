using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.DTOs.FileMetadata;
using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Models.Enums;

namespace BusinessLogic.Services
{
    public class FileMetadataService : IFileMetadataService
    {

        private readonly IGeneralRepository<FileMetadata> _fileRepo;
        private readonly IGeneralRepository<FileApproval> _approvalRepo;
        private readonly IMapper _mapper;

        public FileMetadataService(
            IGeneralRepository<FileMetadata> fileRepo,
            IGeneralRepository<FileApproval> approvalRepo,
            IMapper _mapper)
        {
            _fileRepo = fileRepo;
            _approvalRepo = approvalRepo;
            this._mapper = _mapper;
        }

        public async Task<FileMetadataDto> GetFileDetailsAsync(int id)
        {
      
            var file = await _fileRepo.GetByIdAsync(id, f => f.Approvals);
            return _mapper.Map<FileMetadataDto>(file);
        }

        public async Task<bool> ApproveFileAsync(int fileId, string employeeName)
        {
    
            var file = await _fileRepo.GetByIdAsync(fileId, f => f.Approvals);
            if (file == null) return false;

       
            var nextApproval = file.Approvals
                .OrderBy(a => a.Order)
                .FirstOrDefault(a => !a.IsApproved);

            if (nextApproval == null || nextApproval.EmployeeName != employeeName)
                return false;

            nextApproval.IsApproved = true;
            nextApproval.CreatedAt = DateTime.Now;
            _approvalRepo.Update(nextApproval);

     
            var allApproved = file.Approvals.All(a => a.IsApproved);
            file.Status = allApproved ? FileStatus.Approved : FileStatus.Pending;

            _fileRepo.Update(file);

            return true;

        }
    }
}
