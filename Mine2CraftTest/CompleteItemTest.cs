using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Persistance;
using Xunit;

namespace Mine2CraftTest
{
    public class CompleteItemTest
    {
        private InMemoryCompleteItem InMemoryCompleteItem{ get; }

        public CompleteItemTest()
        {
            InMemoryCompleteItem = new InMemoryCompleteItem();
        }

        [Fact]
        public void GetAllCompleteItemTest()
        {
            //Arrange
            IEnumerable<CompleteItemEntity> completeItemEntities = new List<CompleteItemEntity>();

            //Action
            completeItemEntities = InMemoryCompleteItem.GetAllCompleteItems();

            //Assert
            Assert.NotEmpty(completeItemEntities);
            Assert.True(completeItemEntities.Count() == 10);
        }

        [Fact]
        public void GetCompleteItemTest()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            //Action
            CompleteItemEntity completeItemEntitySelected = InMemoryCompleteItem.GetSingleCompleteItem(id);

            //Assert
            Assert.NotNull(completeItemEntitySelected);
            Assert.Equal(completeItemEntitySelected.Id, id);
        }
    }
}