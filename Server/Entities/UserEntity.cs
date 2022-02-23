using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models;

namespace Entities
{
    [Table("users")]
    public class UserEntity : IBaseEntity
    {
        public Guid Id { get; set; }

        public string Nickname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        
        public UserRole UserRole { get; set; }

        public UserEntity()
        {

        }

        public UserEntity(Guid id, string nickname, string email, string password, UserRole userRole)
        {
            Id = id;
            Nickname = nickname;
            Email = email;
            Password = password;
            UserRole = userRole;
        }
    }
}
