using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public abstract class CompleteItemEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public int Durability { get; set; }

        public string Description { get; set; }
        public string CompleteItemType { get; set; }
        public ICollection<WorkbenchEntity> Workbenches { get; set; }
        
    }
}
