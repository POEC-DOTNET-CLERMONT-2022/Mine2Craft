using AutoMapper;
using Dtos;
using Models;

namespace ApiRequest;

public class CompleteItemRequestManager : RequestManager<CompleteItemModel, CompleteItemDto>
{
    public CompleteItemRequestManager(HttpClient client, IMapper mapper, string serverUrl) : base(client, mapper, serverUrl, "/api/completeItem")
    {
    }
}