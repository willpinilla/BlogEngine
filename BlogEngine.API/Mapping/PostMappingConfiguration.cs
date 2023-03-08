using BlogEngine.Utilities.Entities;
using BlogEngine.Utilities.PayLoad;

namespace BlogEngine.API.Mapping
{
    public class PostMappingConfiguration : AutoMapper.Profile
    {
        public PostMappingConfiguration() 
        {
            CreateMap<PostPayLoad, Post>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.Ignore())
                .ForMember(dest =>
                    dest.Title,
                    opt => opt.MapFrom(src => src.Title))
                .ForMember(dest =>
                    dest.Description,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(dest =>
                    dest.WriterId,
                    opt => opt.MapFrom(src => src.WriterId))
                .ForMember(dest =>
                    dest.CreationDate,
                    opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest =>
                    dest.EditorId,
                    opt => opt.Ignore())
                .ForMember(dest =>
                    dest.EditorComments,
                    opt => opt.Ignore())
                .ForMember(dest =>
                    dest.RevisionDate,
                    opt => opt.Ignore())
                .ForMember(dest =>
                    dest.Status,
                    opt => opt.MapFrom(src => "IN PROGRESS"))
                .ReverseMap();

            CreateMap<CommentPayLoad, Comment>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.Ignore())
                .ForMember(dest =>
                    dest.Description,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(dest =>
                    dest.CreationDate,
                    opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest =>
                    dest.PostId,
                    opt => opt.MapFrom(src => src.PostId))
                .ReverseMap();
        }
    }
}
