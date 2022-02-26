using AutoMapper;
using Dtos;
using Models;

namespace ApiRequest;

public class FurnaceManager : RequestManager<FurnaceModel, FurnaceDto>
{
    public FurnaceManager(HttpClient client, IMapper mapper, string serverUrl) 
        : base(client, mapper, serverUrl, "/api/furnace")
    {
    }
}