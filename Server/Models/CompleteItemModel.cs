using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Dtos;

namespace Models
{
    public class CompleteItemModel : ObservableObject
    {

        protected Guid _id;
        protected string _name;
        protected int _durability;
        protected string _description;
        protected ICollection<WorkbenchModel> _workbenches;
        protected string _completeItemType;
        
        public CompleteItemModel()
        {
            
        }

        [JsonConstructorAttribute]
        public CompleteItemModel(Guid id, string name, int durability, string description,
            ICollection<WorkbenchModel> workbenches, string completeItemType)
        {
            Id = id;
            Name = name;
            Durability = durability;
            Description = description;
            Workbenches = workbenches;
            _completeItemType = completeItemType;
        }
        
        public CompleteItemModel( string name, int durability, string description,
            ICollection<WorkbenchModel> workbenches, string completeItemType)
        {
            Name = name;
            Durability = durability;
            Description = description;
            Workbenches = workbenches;
            _completeItemType = completeItemType;
        }

        public Guid Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public int Durability
        {
            get { return _durability; }
            set
            {
                if (_durability != value)
                {
                    _durability = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        
        public ICollection<WorkbenchModel> Workbenches
        {
            get { return _workbenches; }
            set
            {
                if (_workbenches != value)
                {
                    _workbenches = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public string CompleteItemType
        {
            get { return _completeItemType; }
            set
            {
                if (_completeItemType != value)
                {
                    _completeItemType = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        
    }
}
