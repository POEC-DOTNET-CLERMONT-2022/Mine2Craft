using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dtos;
using Entities;

namespace Persistance.Manager.User
{
    public class BddUserManager : IUserManager
    {

        private readonly RepositoryGeneric<UserEntity> _userRepository;
        public IMapper Mapper { get; set; }

        public BddUserManager()
        {
            _userRepository = new RepositoryGeneric<UserEntity>(new SqlDbContext("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Mine2Craft;Integrated Security=True"));
        }

        public IEnumerable<UserDto> GetAllUser()
        {
            return Mapper.Map<IEnumerable<UserDto>>(_userRepository.GetAll());
        }

        public UserDto GetSingleUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public int CreateUser(UserDto userDtoToCreate)
        {
            var userEntityToCreate = Mapper.Map<UserEntity>(userDtoToCreate);
            return _userRepository.Create(userEntityToCreate);
        }

        public int DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
