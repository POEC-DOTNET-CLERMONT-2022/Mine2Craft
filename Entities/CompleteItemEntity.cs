using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class CompleteItemEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Durability { get; set; }
        public string Description { get; set; }

        public CompleteItemEntity(Guid id, string name, int durability, string description)
        {
            Id = id;
            Name = name;
            Durability = durability;
            Description = description;
        }
    }
}
