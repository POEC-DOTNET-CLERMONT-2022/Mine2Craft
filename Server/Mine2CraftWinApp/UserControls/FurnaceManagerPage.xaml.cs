﻿using ApiRequest;
using Dtos;
using Mine2CraftWinApp.Utils;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mine2CraftWinApp.UserControls
{
    public partial class FurnaceManagerPage : UserControl
    {
        private readonly IRequestManager<ItemModel, ItemDto> _itemDataManager
        = ((App)Application.Current).ItemDataManager;

        private Guid GuidCooked = Guid.Empty;
        public ItemListObservable ItemListCooked { get; set; } = new ItemListObservable();
        private List<ItemModel> CookedList = new List<ItemModel>();
        private IEnumerable<ItemModel> CookedEnum { get; set; }
        private Dictionary<Guid, string> dicoCookedItem = new Dictionary<Guid, string>();
        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;



        public FurnaceManagerPage()
        {
            InitializeComponent();
            DataContext = this;
        }


        private async void Root_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadItem();
        }

        public async Task LoadItem()
        {
            var itemModels = await _itemDataManager.GetAll();
            CookedList.Clear();
            dicoCookedItem.Clear();

            foreach (var item in itemModels)
            {
                dicoCookedItem.Add(item.Id, item.Name);
                if (item.IsCooked == 1 && item.ItemBeforeCook != Guid.Empty) // 
                    CookedList.Add(item);
            }

            CookedEnum = CookedList;

            ItemListCooked.Items = new ObservableCollection<ItemModel>(CookedEnum);
        }

        private void lbItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbItem.SelectedIndex != -1)
                GuidCooked = Guid.Parse(tbResultCooked.Text);
            if (dicoCookedItem.ContainsKey(GuidCooked) == true)
                labelItemBurn.Content = dicoCookedItem[GuidCooked];
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(SelectionMenuUC));
        }
    }
}
