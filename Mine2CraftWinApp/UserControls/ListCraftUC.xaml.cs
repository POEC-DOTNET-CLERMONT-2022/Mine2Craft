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
using Dtos;
using Persistance;
using Mine2CraftWebApp.Service.CompleteItem;
using Mine2CraftWinApp.Request;

namespace Mine2CraftWinApp.UserControls
{
    /// <summary>
    /// Interaction logic for ListCraftUC.xaml
    /// </summary>
    public partial class ListCraftUC : UserControl
    {

        public CompleteItemRequest CompleteItemRequest { get; } = new CompleteItemRequest();

        public ListCraftUC()
        {
            InitializeComponent();
            
            Task.Run( () => CompleteItemRequest.GetCompleteItems()).Wait();

            ListBoxCompleteItem.ItemsSource = CompleteItemRequest.CompleteItems;
        }

        /*
         * Create an event to get back to the menu with User Control
         */
        internal static readonly RoutedEvent BackToMenuEvent = EventManager.RegisterRoutedEvent(
            "BackToMenu", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(ListCraftUC));

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
            RaiseEvent(new RoutedEventArgs(BackToMenuEvent));
        }

        private void DisplayCompleteItemInfo(object sender, RoutedEventArgs e)
        {
            CompleteItemDto completeItemSelected = (CompleteItemDto)ListBoxCompleteItem.SelectedItem;

            CompleteItemDescriptionContainer.Content = $"Description : {completeItemSelected.Description}";
            CompleteItemDurabilityContainer.Content = $"Durabilité : {completeItemSelected.Durability}";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            CompleteItemDto completeItemDtoToDelete = (CompleteItemDto) ListBoxCompleteItem.SelectedItem;

            CompleteItemRequest.DeleteCompleteItem(completeItemDtoToDelete.Id);
        }

    }
}
