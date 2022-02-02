using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using ApiRequest;
using AutoMapper;
using Dtos;
using Models;
using Persistance;

namespace Mine2CraftWinApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string SERVER_URL = "https://localhost:7204"; 

        public HttpClient HttpClient { get; } = new HttpClient();

        public IRequestManager<CompleteItemModel, CompleteItemDto> CompleteItemRequestManager { get; } 
        public IMapper Mapper { get; }

        public App()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(App)));
            Mapper = new Mapper(configuration);
            CompleteItemRequestManager = new CompleteItemRequestManager(HttpClient, Mapper, SERVER_URL);
        }
    }
}
