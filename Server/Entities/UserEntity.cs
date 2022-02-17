using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("users")]
    public class UserEntity : IBaseEntity
    {
        public Guid Id { get; set; }

        public string Nickname { get; set; }

        public string Email { get; set; }

        public string Paswword { get; set; }

        public UserEntity()
        {

        }

        public UserEntity(Guid id, string nickname, string email, string password)
        {
            Id = id;
            Nickname = nickname;
            Email = email;
            Paswword = password;
        }
    }
}
