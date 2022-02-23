using System;
using System.Collections.Generic;

namespace Entities
{
    public class ItemEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte IsCombustible { get; set; }
        public byte IsCooked { get; set; }
        public string ImagePath { get; set; }

        public ICollection<WorkbenchEntity> Workbenches { get; set; }
        public FurnaceEntity? Furnace { get; set; }
    }
}
