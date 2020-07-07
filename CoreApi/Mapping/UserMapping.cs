using AutoMapper;
using CoreApi.Domain;
using CoreApi.Resources;

namespace CoreApi.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<UserResource, User>();

            CreateMap<User, UserResource>();
        }
    }
}