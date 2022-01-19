using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class CompleteItemsList : ObservableObject
    {
        private ObservableCollection<CompleteItemDto> _completeItemsDtos;

        private CompleteItemDto _currentCompleteItem;

        public CompleteItemsList()
        {
            _completeItemsDtos = new ObservableCollection<CompleteItemDto>();
        }

        public CompleteItemDto CurrentCompleteItem
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


        public ObservableCollection<CompleteItemDto> CompleteItemsDtos
        {
            get { return _completeItemsDtos; }
            set
            {
                if (_completeItemsDtos != value)
                {
                    _completeItemsDtos = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
