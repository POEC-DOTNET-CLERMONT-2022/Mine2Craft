using System.Net.Http.Json;
using System.Text.Json;
using AutoMapper;
using Dtos;
using Models;
using Newtonsoft.Json;

namespace ApiRequest;

public class RequestManager<TModel, TDto> : IRequestManager<TModel, TDto>   where TModel : class 
                                                                            where TDto : class
{
    private HttpClient HttpClient { get; }
    private IMapper Mapper { get; }
    private string ServerUrl { get; }
    private string ResourceUrl { get; }
    private Uri Uri { get; }
    
    public RequestManager(HttpClient client, IMapper mapper, string serverUrl, string resourceUrl)
    {
        HttpClient = client;
        Mapper = mapper;
        ServerUrl = serverUrl;
        ResourceUrl = resourceUrl;
        Uri = new Uri(ServerUrl + ResourceUrl); 
    }
    
    public async Task<IEnumerable<TModel>> GetAll()
    {
        var httpResponse = await HttpClient.GetAsync(Uri);
        var responseAsString = await httpResponse.Content.ReadAsStringAsync();

        var dtos = JsonConvert.DeserializeObject<IEnumerable<TDto>>(responseAsString,
            new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Auto});

        return Mapper.Map<IEnumerable<TModel>>(dtos);
    }
    
    public async Task CreateCompleteItem(string name, int durability, string description)
    {
        /*var request = new HttpRequestMessage(HttpMethod.Post,
            "https://localhost:7204/api/CompleteItem");
            
        postRequest.Content = new StringContent(dtoString, System.Text.Encoding.UTF8, "application/json-patch+json");

        request.Content = JsonContent.Create(new { Id = Guid.NewGuid(), Name = name, Durability = durability, Description = description });

        await _httpClient.SendAsync(request);*/

    }
}