using AutoMapper;
using Dtos;
using Models;

namespace ApiRequest;

public class ToolRequestManager : RequestManager<ToolModel, ToolDto>
{
    public ToolRequestManager(HttpClient client, IMapper mapper, string serverUrl) : base(client, mapper, serverUrl, "/api/Tool")
    {
    }
}