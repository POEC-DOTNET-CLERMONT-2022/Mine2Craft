using AutoMapper;
using Dtos;
using Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mine2CraftApi.Controllers;
using Moq;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject1
{
    [TestClass]
    public class ItemControllerTest
    {
        private ItemController ItemController { get; set; }

        public IRepositoryGeneric<ItemEntity> ItemRepository { get; set; } = new FakeRepositoryGeneric<ItemEntity>();

        //public Mock<IRepositoryGeneric<ItemEntity>> MockItemRepository { get; set; }

        public IMapper _mapper { get; set; }


        public ItemControllerTest()
        {

        }   

        [TestInitialize]
        public void InitTest()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CompleteItemEntity, CompleteItemDto>()
                        .IncludeAllDerived();

                cfg.CreateMap<CompleteItemDto, CompleteItemEntity>()
                    .IncludeAllDerived();

                cfg.CreateMap<ArmorEntity, ArmorDto>().ReverseMap();
                cfg.CreateMap<ToolEntity, ToolDto>().ReverseMap();

                cfg.CreateMap<ItemEntity, ItemDto>().ReverseMap();

                cfg.CreateMap<WorkbenchEntity, WorkbenchDto>().ReverseMap();
            }
               );

            Mapper _mapper = new Mapper(configuration);

            ItemController = new ItemController(ItemRepository, _mapper);
        }

        [TestMethod]
        public void GetAll_ReturnAllElement_True()
        {
            // Arrange
            

            // Act
            var result = ItemController.Get();

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            var entities = okResult.Value as IEnumerable<ItemDto>;
            entities.Should().NotBeNull();
            entities.Count().Should().Be(15);
        }

        [TestMethod]
        public void Delete_DeleteAnItem_NotFound()
        {
            // Arrange
            var guid = new Guid();

            // Act
            var result = ItemController.Delete(guid);

            // Assert
            var notFoundResult = result as NotFoundResult;
            notFoundResult.Should().NotBeNull();
        }
    }
}