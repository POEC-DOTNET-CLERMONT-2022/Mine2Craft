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