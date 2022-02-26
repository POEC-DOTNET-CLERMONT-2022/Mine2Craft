using System.Collections.ObjectModel;

namespace Models
{
    public class FurnaceListObservable : ObservableObject
    {
        private ObservableCollection<FurnaceModel> _furnaces;

        private FurnaceModel _currentFurnace;

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
        public FurnaceModel CurrentFurnace
        {
            get { return _currentFurnace; }
            set
            {
                if (_currentFurnace != value)
                {
                    _currentFurnace = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<FurnaceModel> Furnaces
        {
            get { return _furnaces; }
            set
            {
                if (_furnaces != value)
                {
                    _furnaces = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
