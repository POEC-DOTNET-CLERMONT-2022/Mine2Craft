using Mine2CraftWebApp.CompleteItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Mine2CraftWebApp.CompleteItemService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICompleteItemService" in both code and config file together.
    [ServiceContract]
    public interface ICompleteItemService
    {
        [OperationContract]
        IEnumerable<CompleteItemDto> GetCompleteItems();

        [OperationContract]
        IEnumerable<CompleteItemDto> CreateCompleteItem(String name, int durability, String description);

        [OperationContract]
        IEnumerable<CompleteItemDto> DeleteCompleteItem(CompleteItemDto completeItemDto);

    }
}
