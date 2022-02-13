using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ApiRequest;
using Dtos;
using Mine2CraftWinApp.Utils;
using Models;

namespace Mine2CraftWinApp.UserControls;

public partial class CompleteItemManagerPage : UserControl
{
    private readonly IRequestManager<CompleteItemModel, CompleteItemDto> _completeItemManager
        = ((App) Application.Current).CompleteItemRequestManager;
    
    private readonly IRequestManager<ToolModel, ToolDto> _toolRequestManager
        = ((App) Application.Current).ToolRequestManager;
    
    public CompleteItemsList CompleteItemsList { get; set; } = new CompleteItemsList();
    public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;

    private readonly Dictionary<int, object> _currentItemWorbenches = new Dictionary<int, object>();

    private string completeItemDiscriminator;
    
    public CompleteItemManagerPage()
    {
        InitializeComponent();
    }

    private void Button_Click_Back(object sender, RoutedEventArgs e)
    {
        Navigator.NavigateTo(typeof(SelectionMenuUC));
    }

    private void RadioButtonChecked(object sender, RoutedEventArgs e)
    {
        var radioButton = sender as RadioButton;
        if (radioButton == null)
            return;
        completeItemDiscriminator = radioButton.Name;
    }

    private void CreateCompleteItem(object sender, RoutedEventArgs e)
    {
        var workbenches = new List<WorkbenchModel>();
        
        if (completeItemDiscriminator == "tools")
        {
            foreach (KeyValuePair<int, object> entry in _currentItemWorbenches) {
                ItemModel item = entry.Value as ItemModel;
                workbenches.Add(new WorkbenchModel(entry.Key, item.Id));
            }

            var toolToCreate = new ToolModel(ItemName.Text, Int32.Parse(ItemDurability.Text),
                ItemDescription.Text, workbenches, completeItemDiscriminator, Int32.Parse(ItemAttack.Text));
            
            _toolRequestManager.Add(toolToCreate);
        }
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        LoadData();
    }

    public async void LoadData()
    {
        var completeItemModels = await _completeItemManager.GetAll();

        CompleteItemsList.CompleteItemsModels = new ObservableCollection<CompleteItemModel>(completeItemModels);
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBox comboBox = sender as ComboBox;

        var position = Int32.Parse(comboBox.SelectedValuePath);

        _currentItemWorbenches[position] = comboBox.SelectedItem;
    }

    private void OnSelectionChangeCompleteItemList(object sender, SelectionChangedEventArgs e)
    {
        var test = "ou";
    }
}