using AutoFixture;
using Mine2CraftWebApp.CompleteItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;
using Mine2CraftWebApp.Factories;

namespace Mine2CraftWebApp.Managers
{
    public class CompleteItemManager
    {

        public IEnumerable<CompleteItemDto> GetCompleteItems(IEnumerable<Models.CompleteItem> completeItems)
        {

            foreach(var completeItem in completeItems)
            {
                yield return completeItem.ToDto();
            }
            
        }

        
    }
}