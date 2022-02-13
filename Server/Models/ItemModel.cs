
using System;

namespace Models
{
    public class ItemModel : ObservableObject
    {
        private string? _name;
        private string? _description;
        private byte _isCombustible;
        private byte _isCooked;

        public Guid Id { get; set; }
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
