using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("users")]
    public class UserEntity : IBaseEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("nickname")]
        public string Nickname { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("pwd")]
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
