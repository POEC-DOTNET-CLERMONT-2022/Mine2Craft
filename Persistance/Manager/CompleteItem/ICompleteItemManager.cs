using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dtos;
using Entities;

namespace Persistance.Manager.CompleteItem
{
    public interface ICompleteItemManager
    { 
        public IMapper Mapper { get; set; }

        IEnumerable<CompleteItemDto> GetAllCompleteItems();

        CompleteItemDto GetSingleCompleteItem(Guid id);
        int CreateCompleteItem(CompleteItemDto completeItemDto);

        int DeleteCompleteItem(Guid id);
    }
}
