using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Nickname { get; set; }

        public string Email { get; set; }

    }
}
