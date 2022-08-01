using AutoMapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserViewModel>()
        .ForMember(dest =>
            dest.SurName,
            opt => opt.MapFrom(src => src.LastName));
    }
}