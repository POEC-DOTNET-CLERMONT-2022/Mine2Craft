using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CompleteItemsList : ObservableObject
    {
        private ObservableCollection<CompleteItemModel> _completeItemsModels;

        private CompleteItemModel _currentCompleteItem;

        public CompleteItemsList()
        {
            _completeItemsModels = new ObservableCollection<CompleteItemModel>();
        }

        public CompleteItemModel CurrentCompleteItem
        {
            get { return _currentCompleteItem; }
            set
            {
                if (_currentCompleteItem != value)
                {
                    _currentCompleteItem = value;
                    OnNotifyPropertyChanged();
                }
            }
        }


        public ObservableCollection<CompleteItemModel> CompleteItemsModels
        {
            get { return _completeItemsModels; }
            set
            {
                if (_completeItemsModels != value)
                {
                    _completeItemsModels = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
