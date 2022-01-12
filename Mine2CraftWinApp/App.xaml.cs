using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Persistance;

namespace Mine2CraftWinApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ICompleteItemRepository CompleteItemManager { get; set; } = new BddCompleteItemManager();
    }
}
