using AutoMapper;
using Dtos;
using Models;

namespace ApiRequest;

public class ItemDataManager : RequestManager<ItemModel, ItemDto>
{
    public ItemDataManager(HttpClient client, IMapper mapper, string serverUrl) 
        : base(client, mapper, serverUrl, "/api/item")
    {
    }
}

