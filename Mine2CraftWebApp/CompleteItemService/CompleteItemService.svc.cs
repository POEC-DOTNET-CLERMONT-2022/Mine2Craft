using AutoFixture;
using Mine2CraftWebApp.CompleteItemService;
using Mine2CraftWebApp.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Mine2CraftWebApp.CompleteItem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CompleteItemService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CompleteItemService.svc or CompleteItemService.svc.cs at the Solution Explorer and start debugging.
    public class CompleteItemService : ICompleteItemService
    {
        private readonly CompleteItemManager _completeItemManager;

        public CompleteItemService()
        {
            _completeItemManager = CompleteItemManager.GetInstance();
        }

        public IEnumerable<CompleteItemDto> GetCompleteItems()
        {
            return _completeItemManager.GetCompleteItems();
        }

        public IEnumerable<CompleteItemDto> DeleteCompleteItem(CompleteItemDto completeItemDto)
        {
            
            _completeItemManager.DeleteCompleteItem(completeItemDto);
            
            return GetCompleteItems();
        }

        public IEnumerable<CompleteItemDto> CreateCompleteItem(String name, int durability, String description)
        {
            _completeItemManager.CreateCompleteItem(name, durability, description);

            return GetCompleteItems();
        }
    }
}
