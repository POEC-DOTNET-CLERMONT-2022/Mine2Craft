using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Mine2CraftWebApp.CompleteItem
{
    public class CompleteItemDto
    {
        protected Guid _id;
        protected string _name;
        protected int _durability;
        protected string _description;

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException(nameof(value));
        }

        [DataMember]
        public int Durability { get; set; }

        [DataMember]
        public string Description
        {
            get => _description;
            set => _description = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override string ToString()
        {
            return $"{Name} {Durability} {Description}";
        }
    }
}