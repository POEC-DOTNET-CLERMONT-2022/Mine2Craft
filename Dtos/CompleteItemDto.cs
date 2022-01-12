using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Mine2CraftWebApp.CompleteItem
{
    public class CompleteItemDto
    {
        
        [DataMember]
        public Guid Id { get; set; }

        [DataMember] 
        public string Name { get; set; }

        [DataMember]
        public int Durability { get; set; }

        [DataMember]
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Name} {Durability} {Description}";
        }
    }
}