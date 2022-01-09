using Mine2CraftWinApp.UserControls;
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

namespace Mine2CraftWinApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal ListCraftUC ListCraftUC { get; set; } = new ListCraftUC();

        internal SelectionMenuUC SelectionMenuUC { get; set; } = new SelectionMenuUC();

        internal CreateOrUpdateUC CreateOrUpdateUC{ get; set; } = new CreateOrUpdateUC();

        public MainWindow()
        {
            InitializeComponent();
            ContentControl.Content = SelectionMenuUC;

            //Subscribe UserControl's event on the method who change the UserControl of the main Window
            ListCraftUC.BackToMenu += BackToMenu;

            //Subscribe UserControl's event on the method who change the UserControl of the main Window
            SelectionMenuUC.GoToCraftList += GoToCraftList;

            SelectionMenuUC.GoToCreateOrUpdateItem += GoToCreateOrUpdateItem;

            CreateOrUpdateUC.BackToMenu += BackToMenu;
        }

        private void BackToMenu(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = SelectionMenuUC;
        }

        private void GoToCraftList(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = ListCraftUC;
        }

        private void GoToCreateOrUpdateItem(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = CreateOrUpdateUC;
        }

    }
}
