using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Mine2CraftWebApp.CompleteItem;
using Mine2CraftWebApp.Factories;
using Persistance;

namespace Mine2CraftWebApp.Service.CompleteItem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CompleteItemService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CompleteItemService.svc or CompleteItemService.svc.cs at the Solution Explorer and start debugging.
    public class CompleteItemService : ICompleteItemService
    {
        private readonly BddCompleteItemManager _bddCompleteItemManager;

        public CompleteItemService(BddCompleteItemManager bddCompleteItemManager)
        {
            _bddCompleteItemManager = bddCompleteItemManager;
        }

        public IEnumerable<CompleteItemDto> GetCompleteItems()
        {
            return _bddCompleteItemManager.GetAllCompleteItems().ToDto();
        }

        public IEnumerable<CompleteItemDto> CreateCompleteItem(string name, int durability, string description)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompleteItemDto> DeleteCompleteItem(CompleteItemDto completeItemDto)
        {
            throw new NotImplementedException();
        }
    }
}
