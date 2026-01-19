using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.DTOs.FileApproval;
using DataAccess.Models;

namespace BusinessLogic.Mapping
{
    public class FileApprovalProfile : Profile
    {
        public FileApprovalProfile() {

            CreateMap<FileApproval, FileApprovalDto>();
        }
    }
}
