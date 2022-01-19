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
using AutoMapper;
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

        //public CompleteItemsList CompleteItemList { get; set; } = new CompleteItemsList();
        public CompleteItemsList CompleteItemsList { get; set; } = new CompleteItemsList();

        public ListCraftUC()
        {
            InitializeComponent();
        }

        public async void LoadData()
        {
            CompleteItemsList.CompleteItemsDtos.Clear();

            await CompleteItemRequest.GetCompleteItems();

            foreach (var completeItem in CompleteItemRequest.CompleteItems)
            {
                CompleteItemsList.CompleteItemsDtos.Add(completeItem);
            }

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

            if (completeItemSelected != null)
            {
                CompleteItemDescriptionContainer.Content = $"Description : {completeItemSelected.Description}";
                CompleteItemDurabilityContainer.Content = $"Durabilité : {completeItemSelected.Durability}";
            }
            else
            {
                CompleteItemDescriptionContainer.Content = "";
                CompleteItemDurabilityContainer.Content = "";
            }
            
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            CompleteItemDto completeItemModelToDelete = (CompleteItemDto) ListBoxCompleteItem.SelectedItem;

            await CompleteItemRequest.DeleteCompleteItem(completeItemModelToDelete.Id);

            CompleteItemsList.CompleteItemsDtos.Remove(completeItemModelToDelete);
        }

    }
}
