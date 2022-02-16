using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ApiRequest;
using Dtos;
using Mine2CraftWinApp.Annotations;
using Mine2CraftWinApp.Utils;
using Models;

namespace Mine2CraftWinApp.UserControls;

public partial class CompleteItemManagerPage : UserControl, INotifyPropertyChanged
{
    private readonly IRequestManager<CompleteItemModel, CompleteItemDto> _completeItemRequestManager
        = ((App) Application.Current).CompleteItemRequestManager;
    
    private readonly IRequestManager<ItemModel, ItemDto> _itemDataManager
        = ((App)Application.Current).ItemDataManager;
    
    private readonly IRequestManager<ToolModel, ToolDto> _toolRequestManager
        = ((App) Application.Current).ToolRequestManager;
    
    public CompleteItemsList CompleteItemsList { get; set; } = new CompleteItemsList();
    
    public ItemListObservable ItemsList { get; set; } = new ItemListObservable();
    public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;

    private readonly Dictionary<int, object> _currentItemWorbenches = new Dictionary<int, object>();

    private string _completeItemDiscriminator = String.Empty;
    public string CompleteItemDiscriminator
    {
        get => _completeItemDiscriminator;
        set
        {
            _completeItemDiscriminator = value;
            OnPropertyChanged();
        }
    }
    
    public CompleteItemManagerPage()
    {
        InitializeComponent();
    }

    private void Button_Click_Back(object sender, RoutedEventArgs e)
    {
        CompleteItemsList.CompleteItemsModels.Clear();
        ItemAttack.Clear();
        CompleteItemDiscriminator = String.Empty;
        Navigator.NavigateTo(typeof(SelectionMenuUC));
    }

    private void RadioButtonChecked(object sender, RoutedEventArgs e)
    {
        var radioButton = sender as RadioButton;
        if (radioButton == null)
            return;
        CompleteItemDiscriminator = radioButton.Name;
    }

    private void CreateCompleteItem(object sender, RoutedEventArgs e)
    {
        var workbenches = new List<WorkbenchModel>();
        
        foreach (KeyValuePair<int, object> entry in _currentItemWorbenches) {
            ItemModel item = entry.Value as ItemModel;
            workbenches.Add(new WorkbenchModel(entry.Key, item.Id));
        }

        CompleteItemModel completeItemModelToCreate = null;
        
        if (CompleteItemDiscriminator == "tools")
        {
            completeItemModelToCreate = new ToolModel(ItemName.Text, Int32.Parse(ItemDurability.Text),
                ItemDescription.Text, workbenches, CompleteItemDiscriminator, Int32.Parse(ItemAttack.Text));
            
        }

        if (CompleteItemDiscriminator == "armors")
        {
            completeItemModelToCreate = new ArmorModel(ItemName.Text, Int32.Parse(ItemDurability.Text),
                ItemDescription.Text, workbenches, CompleteItemDiscriminator, Int32.Parse(ItemArmor.Text));
        }

        _completeItemRequestManager.Add(completeItemModelToCreate);
        
        CompleteItemsList.CompleteItemsModels.Add(completeItemModelToCreate);
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        LoadData();
    }

    //TODO: mettre une TASK 
    public async void LoadData()
    {
        var completeItemModels = await _completeItemRequestManager.GetAll();

        CompleteItemsList.CompleteItemsModels = new ObservableCollection<CompleteItemModel>(completeItemModels);

        var itemModels = await _itemDataManager.GetAll();

        ItemsList.Items = new ObservableCollection<ItemModel>(itemModels);
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBox comboBox = sender as ComboBox;

        var position = Int32.Parse(comboBox.SelectedValuePath);

        _currentItemWorbenches[position] = comboBox.SelectedItem;
        //TODO binding ? 
    }

    private void OnSelectionChangeCompleteItemList(object sender, SelectionChangedEventArgs e)
    {

        //TODO trop complexe
        _currentItemWorbenches.Clear();

        if (CompleteItemsList.CurrentCompleteItem != null)
        {
            foreach (var workbench in CompleteItemsList.CurrentCompleteItem.Workbenches)
            {
                _currentItemWorbenches.Add(workbench.Position, workbench.Item);
            }
        
            if (CompleteItemsList.CurrentCompleteItem.GetType() == typeof(ToolModel))
            {
                var tool = CompleteItemsList.CurrentCompleteItem as ToolModel;
                ItemAttack.Text = tool.AttackPoint.ToString();
            }
            
            if (CompleteItemsList.CurrentCompleteItem.GetType() == typeof(ArmorModel))
            {
                var armor = CompleteItemsList.CurrentCompleteItem as ArmorModel;
                ItemArmor.Text = armor.ArmorPoint.ToString();
            }
        
            for (var i = 1; i < 10; i++)
            {
                var itemFilled = false;
                var comboBox = StackPanelWorkbenches.FindName($"Workbench{i}") as ComboBox;
            
                foreach (var workbench in CompleteItemsList.CurrentCompleteItem.Workbenches)
                {
                    if (workbench.Position == i)
                    {
                        foreach (var item in ItemsList.Items)
                        {
                            if (item.Id == workbench.Item.Id)
                            {
                                comboBox.SelectedItem = item;
                            }
                        }

                        itemFilled = true;
                    }
                }

                if (itemFilled)
                {
                    itemFilled = false;
                    continue;
                }

                comboBox.SelectedItem = null;
            }

            CompleteItemDiscriminator = CompleteItemsList.CurrentCompleteItem.CompleteItemType;
        }
        
    }

    private void UpdateCompleteItem(object sender, RoutedEventArgs e)
    {

        //TODO : trop complexe
        var workbenches = new List<WorkbenchModel>();
        
        foreach (KeyValuePair<int, object> entry in _currentItemWorbenches) {
            ItemModel item = entry.Value as ItemModel;
            workbenches.Add(new WorkbenchModel(entry.Key, item.Id));
        }

        foreach (var workbenchCurrentItem in CompleteItemsList.CurrentCompleteItem.Workbenches)
        {
            foreach (var workbench in workbenches)
            {
                if (workbench.Position == workbenchCurrentItem.Position)
                {
                    workbench.Id = workbenchCurrentItem.Id;
                }
            }
        }

        CompleteItemModel completeItemModelToUpdate = null;
        
        //TODO : enum ? 
        if (CompleteItemDiscriminator == "tools")
        {
            completeItemModelToUpdate = new ToolModel(CompleteItemsList.CurrentCompleteItem.Id, ItemName.Text, Int32.Parse(ItemDurability.Text),
                ItemDescription.Text, workbenches, CompleteItemDiscriminator, Int32.Parse(ItemAttack.Text));
        }

        if (CompleteItemDiscriminator == "armors")
        {
            completeItemModelToUpdate = new ArmorModel(CompleteItemsList.CurrentCompleteItem.Id, ItemName.Text, Int32.Parse(ItemDurability.Text),
                ItemDescription.Text, workbenches, CompleteItemDiscriminator, Int32.Parse(ItemArmor.Text));
        }

        _completeItemRequestManager.Update(completeItemModelToUpdate, CompleteItemsList.CurrentCompleteItem.Id);

        CompleteItemsList.CurrentCompleteItem = completeItemModelToUpdate;
    }

    private void DeleteCompleteItem(object sender, RoutedEventArgs e)
    {
        _completeItemRequestManager.Delete(CompleteItemsList.CurrentCompleteItem.Id);

        CompleteItemsList.CompleteItemsModels.Remove(CompleteItemsList.CurrentCompleteItem);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}