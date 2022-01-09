using AutoFixture;
using Mine2CraftWebApp.CompleteItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mine2CraftWebApp.Managers
{
    public class CompleteItemManager
    {

        private Fixture _fixture = new Fixture();
        private List<CompleteItem> _completeItems = new List<CompleteItem>();

        private static CompleteItemManager _instance = null;

        public CompleteItemManager()
        {
            // fill the list with auto generated complete items
            CompleteItems = _fixture.CreateMany<CompleteItem>(10).ToList(); 
        }

        public static CompleteItemManager GetInstance()
        {
            if(_instance == null)
            {
                _instance = new CompleteItemManager();
            }
            return _instance;
        }
        
        public List<CompleteItem> CompleteItems 
        { 
            get => _completeItems;

            set => _completeItems = value;
        }

        public IEnumerable<CompleteItemDto> GetCompleteItems()
        {

            var completeItems = CompleteItems;

            foreach(var completeItem in completeItems)
            {
                yield return new CompleteItemDto { Id = completeItem.Id, Name = completeItem.Name, Description = completeItem.Description, Durability = completeItem.Durability };
            }
            
        }

        internal void DeleteCompleteItem(CompleteItemDto completeItemDto)
        {
            
            var completeItemToDelete = new CompleteItem(completeItemDto.Id, completeItemDto.Name, completeItemDto.Durability, completeItemDto.Description);

            CompleteItems.Remove(completeItemToDelete);

        }

        internal void CreateCompleteItem(String name, int durability, String description)
        {

            var completeItemToCreate = new CompleteItem(new Guid(), name, durability, description);

            CompleteItems.Add(completeItemToCreate);
        }
    }
}