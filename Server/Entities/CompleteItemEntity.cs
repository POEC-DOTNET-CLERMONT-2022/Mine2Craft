using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public abstract class CompleteItemEntity : IBaseEntity
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
        
        [Column("complete_item_type")]
        public string CompleteItemType { get; set; }
        
        public ICollection<WorkbenchEntity> Workbenches { get; set; }
        
    }
}
