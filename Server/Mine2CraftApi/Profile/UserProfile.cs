using Dtos;
using Entities;

namespace Mine2CraftApi.Profile
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
        }
    }
}
