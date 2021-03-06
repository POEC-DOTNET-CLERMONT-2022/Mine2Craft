using System.Net.Http;
using System.Windows;
using ApiRequest;
using AutoMapper;
using Dtos;
using Models;
using Mine2CraftWinApp.Utils;
using Mine2CraftWinApp.UserControls;

namespace Mine2CraftWinApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string SERVER_URL = "https://localhost:7204";
        public IMapper Mapper { get; }
        public HttpClient HttpClient { get; } = new HttpClient();
        public IRequestManager<CompleteItemModel, CompleteItemDto> CompleteItemRequestManager { get; }
        public IRequestManager<ToolModel, ToolDto> ToolRequestManager { get; }
        public IRequestManager<ItemModel, ItemDto> ItemDataManager { get; } 
        public IRequestManager<FurnaceModel, FurnaceDto> FurnaceManager { get; }
        public INavigator Navigator { get; } = new Navigator();


        public App()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(App)));
            Mapper = new Mapper(configuration);
            
            CompleteItemRequestManager = new CompleteItemRequestManager(HttpClient, Mapper, SERVER_URL);
            ToolRequestManager = new ToolRequestManager(HttpClient, Mapper, SERVER_URL);
            ItemDataManager = new ItemDataManager(HttpClient, Mapper, SERVER_URL);
            FurnaceManager = new FurnaceManager(HttpClient, Mapper, SERVER_URL);
        }

        private void App_OnStartup(object sender, StartupEventArgs e) // bind le Startup="App_OnStartup" dans le fichier app.xaml 
        {
            Navigator.RegisterView(new ItemManagerPage());
            Navigator.RegisterView(new CompleteItemManagerPage());
            Navigator.RegisterView(new FurnaceManagerPage());
            Navigator.RegisterView(new ListCraftPage());
            Navigator.RegisterView(new SelectionMenuUC());
            Navigator.RegisterView(new UserConnectionPage());
        }
    }
}
