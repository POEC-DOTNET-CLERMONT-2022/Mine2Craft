using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class CompleteItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Durability { get; set; }

        public string Description { get; set; }
    }
}
