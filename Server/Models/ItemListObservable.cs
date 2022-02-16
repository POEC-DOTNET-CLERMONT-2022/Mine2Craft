using System.Collections.ObjectModel;

namespace Models
{
    public class ItemListObservable : ObservableObject
    {
        private ObservableCollection<ItemModel> _items;

        private ItemModel _currentItem;

        private bool isVisible;

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                OnNotifyPropertyChanged();
            }
        }
        public ItemModel CurrentItem
        {
            get { return _currentItem; }
            set
            {
                if (_currentItem != value)
                {
                    _currentItem = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<ItemModel> Items
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
