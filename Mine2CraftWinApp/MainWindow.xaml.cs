using Mine2CraftWinApp.UserControls;
using System.Windows;
using System.Windows.Controls;
using Mine2CraftWinApp.Utils;

namespace Mine2CraftWinApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //internal ListCraftPage ListCraftPage { get; set; } = new ListCraftPage();

        //internal SelectionMenuUC SelectionMenuUC { get; set; } = new SelectionMenuUC();

        //internal CreateOrUpdateUC CreateOrUpdateUC { get; set; } = new CreateOrUpdateUC();

        //public MainWindow()
        //{
        //    InitializeComponent();

        //    DataContext = this;

        //    ContentControl.Content = SelectionMenuUC;

        //    //Subscribe UserControl's event on the method who change the UserControl of the main Window
        //    ListCraftPage.BackToMenu += BackToMenu;

        //    //Subscribe UserControl's event on the method who change the UserControl of the main Window
        //    SelectionMenuUC.GoToCraftList += GoToCraftList;

        //    SelectionMenuUC.GoToCreateOrUpdateItem += GoToCreateOrUpdateItem;

        //    CreateOrUpdateUC.BackToMenu += BackToMenu;
        //}

        //private void BackToMenu(object sender, RoutedEventArgs e)
        //{
        //    ContentControl.Content = SelectionMenuUC;
        //}

        //private void GoToCraftList(object sender, RoutedEventArgs e)
        //{
        //    ContentControl.Content = ListCraftPage;
        //}

        //private void GoToCreateOrUpdateItem(object sender, RoutedEventArgs e)
        //{
        //    ContentControl.Content = CreateOrUpdateUC;
        //}


        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Navigator.NavigateTo(typeof(SelectionMenuUC));
        }

        private void GoBackClick(object sender, RoutedEventArgs e)
        {
            if (Navigator.CanGoBack())
            {
                Navigator.Back();
            }
        }

    }
}