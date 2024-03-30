using AutoMapper;
using Identity.Domain.Entities;
using Identity.UseCases.Users.RegisterUser;
using Inspirer.Contracts.Identity;

namespace Identity.UseCases.Users;

/// <summary>
/// Users mapping profile.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public MappingProfile()
    {
        CreateMap<RegisterUserDto, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
        CreateMap<User, UserRegisteredEvent>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
    }
}
