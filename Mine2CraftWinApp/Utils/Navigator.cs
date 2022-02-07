using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Models;

namespace Mine2CraftWinApp.Utils
{
    public class Navigator : ObservableObject, INavigator
    {
        private List<Control> Views { get; set; } = new List<Control>();

        private ContentControl currentContentControl = new ContentControl();

        public Stack<Control> BackStack { get; set; } = new Stack<Control>(); 

        public ContentControl CurrentContentControl
        {
            get => currentContentControl;
            set
            {
                currentContentControl = value;
                OnNotifyPropertyChanged();
            }
        }

        public void RegisterView(Control view)
        {
            Views.Add(view);
        }
        
        public void NavigateTo(Type type)
        {
            if(CurrentContentControl == null) return;
            if (CurrentContentControl.Content != null)
            {
                BackStack.Push((Control)CurrentContentControl.Content);
            }
            var view = Views.SingleOrDefault(elt => elt.GetType() == type);
            if (view == null) return;
            CurrentContentControl.Content = view;
        }



        public void Back()
        {
            if (CurrentContentControl == null) return;
            CurrentContentControl.Content = BackStack.Pop(); 
        }

        public bool CanGoBack()
        {
            return BackStack.TryPeek(out var result);
        }
    }
}
