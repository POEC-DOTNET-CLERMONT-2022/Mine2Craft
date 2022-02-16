using System;
using System.Collections.Generic;

namespace Entities
{
    public class ItemEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //TODO: MAJ 
        public byte isCombustible { get; set; }
        public byte isCooked { get; set; }
        public Guid ItemBeforeCook { get; set; }

        public ICollection<WorkbenchEntity> Workbenches { get; set; }
    }
}
