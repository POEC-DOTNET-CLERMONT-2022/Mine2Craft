using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    [Table("completeItem")]
    public class CompleteItemEntity : IBaseEntity
    {

        [Key]
        [Column("id")] 
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("durability")]
        public int Durability { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public CompleteItemEntity()
        {

        }
        
        public CompleteItemEntity(Guid id, string name, int durability, string description)
        {
            Id = id;
            Name = name;
            Durability = durability;
            Description = description;
        }
    }
}
