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
        public ItemListObservable ItemCookedList{ get; set; } = new ItemListObservable();

        private List<ItemModel> CookedList = new List<ItemModel>();
        private IEnumerable<ItemModel> CookedEnum { get; set;}

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
        }

        private async void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            index = lbItem.SelectedIndex;
            if (index != -1)
            {
                var itemModel = ItemsList.Items[index].Id;
                if (itemModel != Guid.Empty)
                    await _itemDataManager.Delete(itemModel);
                await LoadItem(); // TODO Eviter double appel API
            }
        }

        private async void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            //TODO : trop complexe 
            byte isCombustible = 0, isCooked = 0;
            Guid guidCooked = Guid.Empty;


            if (rbCooked.IsChecked == true && rbNull.IsChecked == false)
            {
                isCooked = 1;
                stackLbCooked.Visibility = Visibility.Visible;
                //TODO : binding ? avec converter ? 

                if (lbCooked.SelectedItem != null)
                {
                    if (tbGuid.Text != string.Empty)
                        guidCooked = System.Guid.Parse(tbGuid.Text);
                }
            }
            else
            {
                isCombustible = 1;
            }

            var newItem = new ItemModel()
            {
                Name = tbNameItem.Text,
                Description = tbDescItem.Text,
                IsCombustible = isCombustible,
                IsCooked = isCooked,
                ItemBeforeCook = guidCooked,
                ImagePath = tbImagePath.Text
            };

            await _itemDataManager.Add(newItem);
            await LoadItem(); // TODO Eviter double appel API
            Reset();
        }

        private async void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            //TODO : même chose 
            index = lbItem.SelectedIndex;
            byte isCombustible = 0, isCooked = 0;

            if (rbCombustible.IsChecked == true)
                isCombustible = 1;

            if (rbCooked.IsChecked == true)
            {
                isCooked = 1;
                stackLbCooked.Visibility = Visibility.Visible;
                stackItemBeforeCook.Visibility = Visibility.Visible;
            }
            else
            {
                stackLbCooked.Visibility = Visibility.Collapsed;
                tbItemBeforeCook.Visibility = Visibility.Collapsed;
            }
                

            if (index != -1)
            {
                var itemModel = ItemsList.Items[index];
                if (itemModel.Id != System.Guid.Empty)
                {
                    itemModel.Name = tbNameItem.Text;
                    itemModel.Description = tbDescItem.Text;
                    itemModel.IsCombustible = isCombustible;
                    itemModel.IsCooked = isCooked;
                    itemModel.ImagePath = tbImagePath.Text;

                    await _itemDataManager.Update(itemModel, itemModel.Id);
                    await LoadItem(); // TODO Eviter double appel API
                }
                Reset();
            }
        }

        //TODO : majuscule 
        private void lbItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO trop complexe
            Guid guidCooked = Guid.Empty;
            index = lbItem.SelectedIndex;

            if (index != -1)
                guidCooked = Guid.Parse(tbItemBeforeCook.Text);


            if (tbImagePath.Text == null)
                tbImagePath.Text = "Cet Item n'a aucune image";

            if (dicoCookedItem.ContainsKey(guidCooked) == true)
                tbItemBeforeCook.Text = dicoCookedItem[guidCooked];

            if (rbCooked.IsChecked == true)
            {
                stackLbCooked.Visibility = Visibility.Collapsed;

                if (tbItemBeforeCook.Text != Guid.Empty.ToString())
                    stackItemBeforeCook.Visibility = Visibility.Visible;
                else
                    stackItemBeforeCook.Visibility = Visibility.Collapsed;
            }

            if (rbCombustible.IsChecked == false && rbCooked.IsChecked == false)
                rbNull.IsChecked = true;
            btAdd.Visibility = Visibility.Hidden;
            btUpdate.Visibility = Visibility.Visible;
        }



        public async Task LoadItem()
        {
            var itemModels = await _itemDataManager.GetAll();
            CookedList.Clear();
            dicoCookedItem.Clear();
            cbListImage.Items.Clear();

            var defaultItem = new ItemModel { Name = "Default Item", ItemBeforeCook = Guid.Empty };

            CookedList.Insert(0, defaultItem);

            foreach (var item in itemModels)
            {
                dicoCookedItem.Add(item.Id, item.Name);
                if (item.IsCooked == 1 && item.ItemBeforeCook == Guid.Empty)
                    CookedList.Add(item);
            }

            CookedEnum = CookedList;

            ItemsList.Items = new ObservableCollection<ItemModel>(itemModels);
            ItemCookedList.Items = new ObservableCollection<ItemModel>(CookedEnum);
            btAdd.Visibility = Visibility.Visible;
            btUpdate.Visibility = Visibility.Hidden;

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
            lbItem.SelectedItem = null;
            tbNameItem.Text = "";
            tbDescItem.Text = "";
            rbCooked.IsChecked = false;
            rbCombustible.IsChecked = false;
            rbNull.IsChecked = true;
            btAdd.Visibility = Visibility.Visible;
            btUpdate.Visibility = Visibility.Hidden;
            tbItemBeforeCook.Text = "";
            stackItemBeforeCook.Visibility = Visibility.Collapsed;
            stackLbCooked.Visibility = Visibility.Collapsed;
            tbImagePath.Text = "";
            cbListImage.SelectedIndex = -1;
        }

        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            Reset();
        }


        //TODO: see DataTrigger
        private void lbCooked_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            lbCooked.Height = 500;
            gridForm.Visibility = Visibility.Collapsed;
            var marg = stackLbCooked.Margin;
            marg.Top = 50;
        }

        //TODO: see DataTrigger
        private void lbCooked_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            lbCooked.Height = 50;
            gridForm.Visibility = Visibility.Visible;

        }

        //TODO: Binding
        private void rbCooked_Checked(object sender, RoutedEventArgs e)
        {
            if (lbItem.SelectedItem == null && btAdd.Visibility == Visibility.Visible)
                stackLbCooked.Visibility = Visibility.Visible;
        }

        //TODO: Binding
        private void rbCombustible_Checked(object sender, RoutedEventArgs e)
        {
            stackLbCooked.Visibility = Visibility.Collapsed;
            stackItemBeforeCook.Visibility = Visibility.Collapsed;
        }

        //TODO: Binding
        private void rbNull_Checked(object sender, RoutedEventArgs e)
        {
            /*stackLbCooked.Visibility = Visibility.Collapsed;
            stackItemBeforeCook.Visibility = Visibility.Collapsed;*/
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
