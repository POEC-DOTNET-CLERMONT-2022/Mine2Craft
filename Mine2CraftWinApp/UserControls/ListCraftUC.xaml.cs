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
using Persistance;
using Mine2CraftWebApp.Service.CompleteItem;

namespace Mine2CraftWinApp.UserControls
{
    /// <summary>
    /// Interaction logic for ListCraftUC.xaml
    /// </summary>
    public partial class ListCraftUC : UserControl
    {

        public ICompleteItemRepository CompleteItemManager { get; }

        public ICompleteItemService CompleteItemService { get; }

        public ListCraftUC()
        {
            InitializeComponent();

            if (Application.Current is App app)
            {
                CompleteItemManager = app.CompleteItemManager;
            }

            CompleteItemService = new CompleteItemService((BddCompleteItemManager)CompleteItemManager);


            ListBoxCompleteItem.ItemsSource = CompleteItemService.GetCompleteItems();


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
            /*CompleteItemDto completeItemSelected = (CompleteItemDto)ListBoxCompleteItem.SelectedItem;

            CompleteItemDescriptionContainer.Content = $"Description : {completeItemSelected.Description}";
            CompleteItemDurabilityContainer.Content = $"Durabilité : {completeItemSelected.Durability}";*/
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            /*var completeItemDtoToDelete = ListBoxCompleteItem.SelectedItem;

            var client = new CompleteItemServiceClient();

            var completeItemsUpdate = client.DeleteCompleteItem((CompleteItemDto)completeItemDtoToDelete);

            ListBoxCompleteItem.ItemsSource = completeItemsUpdate.ToList();

            client.Close();*/
        }
    }
}
