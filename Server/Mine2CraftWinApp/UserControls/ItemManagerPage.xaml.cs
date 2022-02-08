using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ApiRequest;
using Dtos;
using Models;
using Mine2CraftWinApp.Utils;

namespace Mine2CraftWinApp.UserControls
{
    /// <summary>
    /// Logique d'interaction pour ItemManagerUc.xaml
    /// </summary>
    public partial class ItemManagerPage : UserControl
    {

        private readonly IRequestManager<ItemModel, ItemDto> _itemDataManager
                = ((App)Application.Current).ItemDataManager;

        public ItemListObservable ItemsList { get; set; } = new ItemListObservable();

        public ItemModel itemModel;

        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;


        public ItemManagerPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUser();
            tbNameItem.Text = "New Item";
            tbDescItem.Text = "New Desc Item";
            rbNull.IsChecked = true;
        }

        private async void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            int index = lbItem.SelectedIndex;
            if (index != -1)
            {
                var itemModel = ItemsList.Items[index].Id;
                if (itemModel != System.Guid.Empty)
                    await _itemDataManager.Delete(itemModel);
                    LoadUser();
            }
        }

        private async void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            byte isCombustible = 0, isCooked = 0;
            
            if (rbCombustible.IsChecked == true)
                isCombustible = 1;

            if (rbCooked.IsChecked == true)
                isCooked = 1;

            var newItem = new ItemModel()
            {
                Name = tbNameItem.Text,
                Description = tbDescItem.Text,
                IsCombustible = isCombustible,
                IsCooked = isCooked
            };

            await _itemDataManager.Add(newItem);
            LoadUser();
            Reset();
        }

        private async void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            int index = lbItem.SelectedIndex;
            byte isCombustible = 0, isCooked = 0;

            if (rbCombustible.IsChecked == true)
                isCombustible = 1;

            if (rbCooked.IsChecked == true)
                isCooked = 1;

            if (index != -1)
            {
                var itemModel = ItemsList.Items[index];
                if (itemModel.Id != System.Guid.Empty)
                {
                    itemModel.Name = tbNameItem.Text;
                    itemModel.Description = tbDescItem.Text;
                    itemModel.IsCombustible = isCombustible;
                    itemModel.IsCooked = isCooked;

                    await _itemDataManager.Update(itemModel, itemModel.Id);
                    LoadUser();
                    Reset();
                }
                Reset();
            }
        }


        private void lbItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rbCombustible.IsChecked == false && rbCooked.IsChecked == false)
                rbNull.IsChecked = true;
            btAdd.Visibility = Visibility.Hidden;
            btUpdate.Visibility = Visibility.Visible;
        }

        public async void LoadUser()
        {
            var itemModels = await _itemDataManager.GetAll();
            ItemsList.Items = new ObservableCollection<ItemModel>(itemModels);
            btAdd.Visibility = Visibility.Visible;
            btUpdate.Visibility = Visibility.Hidden;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(SelectionMenuUC));
        }

        private void Reset()
        {
            lbItem.SelectedItem = null;
            tbNameItem.Text = "";
            tbDescItem.Text = "";
            rbCooked.IsChecked = false;
            rbCombustible.IsChecked = false;
            rbNull.IsChecked = true;
            btAdd.Visibility = Visibility.Visible;
            btUpdate.Visibility = Visibility.Hidden;
        }

        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            Reset();
        }
    }
}
