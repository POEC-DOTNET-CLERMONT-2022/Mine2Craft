using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Models
{
    public class CompleteItemModel : ObservableObject
    {

        private Guid _id;
        private string _name;
        private int _durability;
        private string _description;

        [JsonPropertyName("id")]
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

        [JsonPropertyName("name")]
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

        [JsonPropertyName("durability")]
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

        [JsonPropertyName("description")]
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
    }
}
