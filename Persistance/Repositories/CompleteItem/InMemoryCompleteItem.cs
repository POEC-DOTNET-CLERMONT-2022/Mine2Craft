using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoFixture;
using Entities;

namespace Persistance
{
    public class InMemoryCompleteItem
    {

        private readonly Fixture _fixture = new Fixture();

        public IEnumerable<CompleteItemEntity> GetAllCompleteItems()
        {
            return _fixture.CreateMany<CompleteItemEntity>(10);
        }

        public CompleteItemEntity GetSingleCompleteItem(Guid id)
        {
            IEnumerable <CompleteItemEntity> completeItemEntities = _fixture.CreateMany<CompleteItemEntity>(10);

            List<CompleteItemEntity> completeItemEntitiesList = completeItemEntities.ToList();

            completeItemEntitiesList.Add(new CompleteItemEntity(id, "test", 20, "test"));

            completeItemEntities = completeItemEntitiesList;

            return completeItemEntities.SingleOrDefault(completeItemEntity => completeItemEntity.Id == id);
        }

        public void CreateCompleteItem(CompleteItemEntity completeItemEntityToCreate)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompleteItem(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
