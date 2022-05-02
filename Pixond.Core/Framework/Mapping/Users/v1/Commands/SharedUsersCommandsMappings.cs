using AutoMapper;
using Pixond.Model.Entitites;
using Pixond.Model.General.Commands.Users.User;

namespace Pixond.Core.Framework.Mapping.Users.v1.Commands
{
    public class SharedUsersCommandsMappings : Profile
    {
        public SharedUsersCommandsMappings()
        {
            CreateMap<User, PublicUser>()
                .ForMember(dest => dest.Username,
                opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email));

            CreateMap<PublicUser, User>()
                .ForMember(dest => dest.UserId,
                opt => opt.Ignore())
                .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Username,
                opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password,
                opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt,
                opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy,
                opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedAt,
                opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedAt,
                opt => opt.Ignore());
        }
    }
}
