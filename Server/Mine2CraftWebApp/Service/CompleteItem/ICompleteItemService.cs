using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Dtos;

namespace Mine2CraftWebApp.Service.CompleteItem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICompleteItemService" in both code and config file together.
    [ServiceContract]
    public interface ICompleteItemService
    {
        [OperationContract]
        IEnumerable<CompleteItemDto> GetCompleteItems();

        [OperationContract]
        IEnumerable<CompleteItemDto> CreateCompleteItem(string name, int durability, string description);

        [OperationContract]
        IEnumerable<CompleteItemDto> DeleteCompleteItem(CompleteItemDto completeItemDto);
    }
}
