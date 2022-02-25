using AutoMapper;
using Entities;
using Persistance;
using Xunit;
using Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using Mine2CraftApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using System.Linq;
using Mine2Craft.Profile;

namespace Mine2CraftApiTest
{
    public class ItemControllerTest
    {
        private ItemController ItemController { get; set; }

        public IRepositoryGeneric<ItemEntity> ItemRepository { get; set; } = new FakeRepositoryGeneric<ItemEntity>();

        public Mock<IRepositoryGeneric<ItemEntity>> MockItemRepository { get; set; }

        public IMapper Mapper { get; set; }

        
        public ItemControllerTest()
        {
            //var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(ItemProfile)));
            //Mapper = new Mapper(configuration);
        }

        [TestInitialize]
        public void InitTest()
        {
            ItemController = new ItemController(ItemRepository, Mapper);
        }

        [Fact]
        public void GetAll_ReturnAllElement_True()
        {
            // Arrange

            // Act
            var result = ItemRepository.GetAll();


            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            var entities = okResult?.Value as IEnumerable<ItemEntity>;
            entities.Should().NotBeNull();
            entities.Count().Should().Be(15);
        }
    }
}