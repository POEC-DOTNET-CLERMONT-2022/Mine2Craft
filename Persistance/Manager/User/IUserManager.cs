using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dtos;

namespace Persistance.Manager.User
{
    public interface IUserManager
    {
        public IMapper Mapper { get; set; }

        IEnumerable<UserDto> GetAllUser();
        
        UserDto GetSingleUser(Guid id);
        
        int CreateUser(UserDto userDtoToCreate);

        int DeleteUser(Guid id);
    }
}
