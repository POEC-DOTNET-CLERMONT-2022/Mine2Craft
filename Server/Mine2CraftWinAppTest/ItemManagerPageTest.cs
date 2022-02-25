using ApiRequest;
using AutoMapper;
using Dtos;
using Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Mine2CraftWinAppTest
{
    public class ItemManagerPageTest
    {
        private const string SERVER_URL = "https://localhost:7204";
        public IMapper Mapper { get; }
        public HttpClient HttpClient { get; } = new HttpClient();
        public IRequestManager<ItemModel, ItemDto> ItemDataManager { get; set; }

        public ItemListObservable ItemsList { get; set; } = new ItemListObservable();

        public ItemManagerPageTest(Mapper mapper)
        {
            Mapper = mapper;
        }


        [Fact]
        public async Task GetAll_ReturnAllItem_TrueAsync()
        {
            // Arrange
            ItemDataManager = new ItemDataManager(HttpClient, Mapper, SERVER_URL);

            // Act
            var result = await ItemDataManager.GetAll();


            // Assert

        }
    }
}