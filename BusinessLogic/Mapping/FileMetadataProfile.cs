using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.DTOs.FileMetadata;
using DataAccess.Models;

namespace BusinessLogic.Mapping
{
    public class FileMetadataProfile : Profile
    {
        public FileMetadataProfile() {
            CreateMap<FileMetadata, FileMetadataDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}
