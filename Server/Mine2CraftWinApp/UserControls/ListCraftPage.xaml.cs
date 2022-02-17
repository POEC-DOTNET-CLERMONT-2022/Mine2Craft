using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ApiRequest;
using AutoMapper;
using Dtos;
using Entities;
using Mine2CraftWinApp.Utils;
using Persistance;
using Models;

namespace Mine2CraftWinApp.UserControls
{
    /// <summary>
    /// Interaction logic for ListCraftUC.xaml
    /// </summary>
    public partial class ListCraftPage : UserControl
    {
        private readonly IRequestManager<CompleteItemModel, CompleteItemDto> _completeItemManager
            = ((App) Application.Current).CompleteItemRequestManager;

        public CompleteItemsList CompleteItemsList { get; set; } = new CompleteItemsList();
        
        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;
        
        public ListCraftPage()
        {
            InitializeComponent();
        }
        
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        public async Task LoadData()
        {
            CompleteItemsList.CompleteItemsModels.Clear();

            var completeItemModels = await _completeItemManager.GetAll();

            CompleteItemsList.CompleteItemsModels = new ObservableCollection<CompleteItemModel>(completeItemModels);
            
        }

        /*
         * Create an event to get back to the menu with User Control
         */
        internal static readonly RoutedEvent BackToMenuEvent = EventManager.RegisterRoutedEvent(
            "BackToMenu", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(ListCraftPage));

        internal event RoutedEventHandler BackToMenu
        {
            add { AddHandler(BackToMenuEvent, value); }
            remove { RemoveHandler(BackToMenuEvent, value); }
        }

        /*
         * OnClick method who will raise the event on the button "BackToMenu" click
         */
        internal void BackToMenuClick(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(SelectionMenuUC));
        }
    }
}
