using Mine2CraftWinApp.Utils;
using System.Windows;
using System.Windows.Controls;

namespace Mine2CraftWinApp.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UserConnection.xaml
    /// </summary>
    public partial class UserConnectionPage : UserControl
    {
        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;

        public UserConnectionPage()
        {
            InitializeComponent();
        }

        private void btBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(SelectionMenuUC));
        }
    }
}
