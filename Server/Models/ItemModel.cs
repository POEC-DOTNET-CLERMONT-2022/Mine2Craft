
using System;

namespace Models
{
    public class ItemModel : ObservableObject
    {
        public Guid Id { get; set; }
        private string _name;
        private string _description;
        private byte _isCombustible;
        private byte _isCooked;
        private Guid _itemBeforeCook;
        private string _imagePath;

        public string ImagePath
        {
            get { return _imagePath; }
            set 
            {
                if (_imagePath != value)
                {
                    _imagePath = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public Guid ItemBeforeCook
        {
            get { return _itemBeforeCook; }
            set
            {
                if (_itemBeforeCook != value)
                {
                    _itemBeforeCook = value;
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
        public byte IsCombustible
        {
            get { return _isCombustible; }
            set
            {
                if (_isCombustible != value)
                {
                    _isCombustible = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public byte IsCooked
        {
            get { return _isCooked; }
            set
            {
                if (_isCooked != value)
                {
                    _isCooked = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        
    }
}
