using BlogEngine.Utilities.Entities;

namespace BlogEngine.Services
{
    public class UserMappingConfiguration : AutoMapper.Profile
    {
        public UserMappingConfiguration() 
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.UserName,
                    opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                    dest.Email,
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(dest =>
                    dest.ProfileId,
                    opt => opt.MapFrom(src => src.ProfileId))
                .ForMember(dest =>
                    dest.ExpiresIn,
                    opt => opt.Ignore())
                .ForMember(dest =>
                    dest.Token,
                    opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
