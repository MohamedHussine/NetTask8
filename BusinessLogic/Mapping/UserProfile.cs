


using BuisnessLogic.DTOs.User;
using BuisnessLogic.VeiwModel.User;
using DataAccess.Idntity;

namespace BuisnessLogic.Mapping
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterViewModel, RegisterDTO>().ReverseMap();
            CreateMap<LoginViewModel, LoginDTO>().ReverseMap();
            CreateMap<ProfileViewModel, ProfileDTO>().ReverseMap();
            CreateMap<ApplicationUser, ProfileDTO>().ReverseMap();
        }
    }
}
