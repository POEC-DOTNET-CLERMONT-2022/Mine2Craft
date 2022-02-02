using System;
using System.Collections.Generic;
using System.Linq;
using Dtos;
using Entities;
using Mine2CraftApi.Controllers;
using Persistance;
using Xunit;

namespace Mine2CraftTest
{
    public class CompleteItemTest
    {
        private CompleteItemController CompleteItemController{ get; }

        /*public CompleteItemTest()
        {
            CompleteItemController = new CompleteItemController(new FakeCompleteItemManager());
        }

        [Fact]
        public void GetAllCompleteItemTest()
        {
            //Arrange
            IEnumerable<CompleteItemDto> completeItemDtos = new List<CompleteItemDto>();

            //Action
            completeItemDtos = CompleteItemController.Get();

            //Assert
            Assert.NotEmpty(completeItemDtos);
            Assert.True(completeItemDtos.Count() == 10);
        }

        [Fact]
        public void CreateCompleteItemTest()
        {
            //Arrange
            CompleteItemDto completeItemToCreate = new CompleteItemDto
                {Description = "test", Durability = 50, Id = Guid.NewGuid(), Name = "test"};

            //Action
            var entitiesCount = CompleteItemController.Post(completeItemToCreate);

            //Assert
            Assert.True(entitiesCount == 11);
        }

        [Fact]
        public void DeleteCompleteItemTest()
        {
            //Action
            var entitiesCount = CompleteItemController.Delete(Guid.NewGuid());

            //Assert
            Assert.True(entitiesCount == 10);
        }*/
    }
}