using ApiRequest;
using Dtos;
using Mine2CraftWinApp.Utils;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Mine2CraftWinApp.UserControls
{
    public partial class FurnaceManagerPage : UserControl
    {
        private readonly IRequestManager<FurnaceModel, FurnaceDto> _furnaceManager
        = ((App)Application.Current).FurnaceManager;
        public FurnaceListObservable FurnaceListObservable { get; set; } = new FurnaceListObservable();
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
            var furnaceModels = await _furnaceManager.GetAll();
            FurnaceListObservable.Furnaces = new ObservableCollection<FurnaceModel>(furnaceModels);
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(SelectionMenuUC));
        }
    }
}
