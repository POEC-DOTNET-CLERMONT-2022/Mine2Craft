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

        private Guid _id;
        private string _name;
        private int _durability;
        private string _description;
        private ICollection<WorkbenchDto> _workbenches;

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
        public ICollection<WorkbenchDto> Workbenches
        {
            get { return _workbenches; }
            set
            {
                if (_workbenches != value)
                {
                    var allPositions = new List<int> {1,2,3,4,5,6,7,8,9};

                    var itemPositions = value.Select(w => w.Position);

                    var emptyPosition = allPositions.Except(itemPositions);

                    var positionManaged = new List<WorkbenchDto>();

                    foreach (var position in emptyPosition)
                    {
                        positionManaged.Add(new WorkbenchDto(){Position = position, Item = null});
                    }

                    foreach (var workbench in value)
                    {
                        positionManaged.Add(workbench);
                    }
                    
                    _workbenches = positionManaged.OrderBy(w => w.Position).ToList();
                    OnNotifyPropertyChanged();
                }
            }
        }

        
    }
}
