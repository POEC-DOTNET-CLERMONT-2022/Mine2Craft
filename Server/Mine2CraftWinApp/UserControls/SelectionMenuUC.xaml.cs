using Mine2CraftWinApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mine2CraftWinApp.UserControls
{
    /// <summary>
    /// Interaction logic for SelectionMenuUC.xaml
    /// </summary>
    public partial class SelectionMenuUC : UserControl
    {
        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;

        public SelectionMenuUC()
        {
            InitializeComponent();
        }

        /*
         * Create an event to get back to the menu with User Control
         */
        internal static readonly RoutedEvent GoToCraftListEvent = EventManager.RegisterRoutedEvent(
            "GoToCraftList", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(SelectionMenuUC));

        internal event RoutedEventHandler GoToCraftList
        {
            add { AddHandler(GoToCraftListEvent, value); }
            remove { RemoveHandler(GoToCraftListEvent, value); }
        }

        /*
         * OnClick method who will raise the event on the button "BackToMenu" click
         */
        internal void GoToCraftListClick(object sender, RoutedEventArgs e)
        {
            //RaiseEvent(new RoutedEventArgs(GoToCraftListEvent));
            Navigator.NavigateTo(typeof(ListCraftPage));
        }

        internal static readonly RoutedEvent GoToCreateOrUpdateItemEvent = EventManager.RegisterRoutedEvent(
            "GoToCreateOrUpdateItem", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(SelectionMenuUC));

        internal event RoutedEventHandler GoToCreateOrUpdateItem
        {
            add { AddHandler(GoToCreateOrUpdateItemEvent, value); }
            remove { RemoveHandler(GoToCreateOrUpdateItemEvent, value); }
        }

        internal void GoToCreateOrUpdateItemClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(GoToCreateOrUpdateItemEvent));
        }

        private void GoToItemManagerPage(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(ItemManagerPage));
        }
        
        private void GoToCompleteItemManager(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(CompleteItemManagerPage));
        }

        private void GoToFurnaceManagerPage(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(FurnaceManagerPage));
        }
    }
}
