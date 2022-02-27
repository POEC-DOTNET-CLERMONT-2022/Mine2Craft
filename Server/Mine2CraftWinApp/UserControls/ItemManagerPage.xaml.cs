using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ApiRequest;
using Dtos;
using Models;
using Mine2CraftWinApp.Utils;
using System.Collections.Generic;
using System.Windows.Documents;
using System;
using System.IO;
using System.Threading.Tasks;

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
        public ItemListObservable ItemCookedList { get; set; } = new ItemListObservable();

        private List<ItemModel> CookedList = new List<ItemModel>();
        private IEnumerable<ItemModel> CookedEnum { get; set; }

        private Dictionary<Guid, string> dicoCookedItem = new Dictionary<Guid, string>();
        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;

        private int index = -1;

        public ItemManagerPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadItem();
            LoadImage();
        }

        private async void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            index = LbItem.SelectedIndex;
            if (index != -1)
            {
                var itemModel = ItemsList.Items[index].Id;
                if (itemModel != Guid.Empty)
                    await _itemDataManager.Delete(itemModel);
                await LoadItem();
            }
        }

        private async void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            byte isCombustible = 0, isCooked = 0;

            if (rbCombustible.IsChecked == true)
            {
                isCombustible = 1;
            }
            if (rbCooked.IsChecked == true)
            {
                isCooked = 1;
            }

            var newItem = new ItemModel()
            {
                Name = tbNameItem.Text,
                Description = tbDescItem.Text,
                IsCombustible = isCombustible,
                IsCooked = isCooked,
                ItemBeforeCook = Guid.Empty,
                ImagePath = tbImagePath.Text
            };

            await _itemDataManager.Add(newItem);
            await LoadItem();
            Reset();
        }

        private async void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            index = LbItem.SelectedIndex;

            if (index != -1)
            {
                byte isCombustible = 0, isCooked = 0;

                if (rbCombustible.IsChecked == true)
                {
                    isCombustible = 1;
                }
                if (rbCooked.IsChecked == true)
                {
                    isCooked = 1;
                }

                var itemModel = ItemsList.Items[index];
                if (itemModel.Id != Guid.Empty)
                {
                    itemModel.Name = tbNameItem.Text;
                    itemModel.Description = tbDescItem.Text;
                    itemModel.IsCombustible = isCombustible;
                    itemModel.IsCooked = isCooked;
                    itemModel.ImagePath = tbImagePath.Text;

                    await _itemDataManager.Update(itemModel, itemModel.Id);
                    await LoadItem();
                }
                Reset();
            }
        }

        private void LbItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Guid guidCooked = Guid.Empty;
            index = LbItem.SelectedIndex;

            if (tbImagePath.Text == null)
                tbImagePath.Text = "Cet Item n'a aucune image";

            if (rbCombustible.IsChecked == false && rbCooked.IsChecked == false)
                rbNull.IsChecked = true;
            btAdd.Visibility = Visibility.Hidden;
            btUpdate.Visibility = Visibility.Visible;
        }

        public async Task LoadItem()
        {
            var itemModels = await _itemDataManager.GetAll();

            ItemsList.Items = new ObservableCollection<ItemModel>(itemModels);
            btAdd.Visibility = Visibility.Visible;
            btUpdate.Visibility = Visibility.Hidden;
        }

        public void LoadImage()
        {
            cbListImage.Items.Clear();

            string[] files = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, @"Image/"), "*.*");
            foreach (var file in files)
            {
                cbListImage.Items.Add(file);
            }
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(SelectionMenuUC));
        }

        private void Reset()
        {
            LbItem.SelectedItem = null;
            tbNameItem.Text = "";
            tbDescItem.Text = "";
            rbCooked.IsChecked = false;
            rbCombustible.IsChecked = false;
            rbNull.IsChecked = true;
            btAdd.Visibility = Visibility.Visible;
            btUpdate.Visibility = Visibility.Hidden;
            tbImagePath.Text = "";
            cbListImage.SelectedIndex = -1;
        }

        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(SelectionMenuUC));
        }
        private void cbListImage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbListImage.SelectedIndex != -1)
                tbImagePath.Text = cbListImage.SelectedItem.ToString();
        }
    }
}
