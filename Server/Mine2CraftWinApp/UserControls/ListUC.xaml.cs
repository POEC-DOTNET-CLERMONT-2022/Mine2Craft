using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Models;

namespace Mine2CraftWinApp.UserControls
{
    /// <summary>
    /// Interaction logic for ListUC.xaml
    /// </summary>
    public partial class ListUC : UserControl
    {

        private static readonly DependencyProperty ListCraftProperty = 
            DependencyProperty.Register("ListCraft", typeof(CompleteItemsList), typeof(ListUC));

        private CompleteItemsList listCraft;

        public CompleteItemsList? ListCraft
        {
            get { return GetValue(ListCraftProperty) as CompleteItemsList; }
            set
            {
                if (listCraft != value)
                {
                    SetValue(ListCraftProperty, value);
                }
            }
        }
        
        public ListUC()
        {
            InitializeComponent();
        }
    }
}
