using System.Net.Http.Json;
using System.Text.Json;
using AutoMapper;

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
        var request = new HttpRequestMessage(HttpMethod.Get, Uri);
        
        var response = await HttpClient.SendAsync(request);
        using var responseStream = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<IEnumerable<TDto>>(responseStream);
        return Mapper.Map<IEnumerable<TModel>>(result);
    }
    
    public async Task CreateCompleteItem(string name, int durability, string description)
    {
        /*var request = new HttpRequestMessage(HttpMethod.Post,
            "https://localhost:7204/api/CompleteItem");

        request.Content = JsonContent.Create(new { Id = Guid.NewGuid(), Name = name, Durability = durability, Description = description });

        await _httpClient.SendAsync(request);*/

    }
}