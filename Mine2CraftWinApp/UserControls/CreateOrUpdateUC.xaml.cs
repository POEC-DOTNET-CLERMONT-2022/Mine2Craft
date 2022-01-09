using Mine2CraftWebApp.CompleteItem;
using Mine2CraftWinApp.CompleteItemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for CreateOrUpdateUC.xaml
    /// </summary>
    public partial class CreateOrUpdateUC : UserControl
    {
        public CreateOrUpdateUC()
        {
            InitializeComponent();
        }

        //Create a Regex to allow only number in the TextBox
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /*
         * Create an event to get back to the menu with User Control
         */
        internal static readonly RoutedEvent BackToMenuEvent = EventManager.RegisterRoutedEvent(
            "BackToMenu", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(CreateOrUpdateUC));

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

        internal void CreateCompleteItem(object sender, RoutedEventArgs e)
        {
            var client = new CompleteItemServiceClient();

            client.CreateCompleteItem(CompleteItemName.Text, Int32.Parse(CompleteItemDurability.Text), CompleteItemDescription.Text);

            client.Close();
        }
    }
}
