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

    public async Task Add(TModel model)
    {
        var dto = Mapper.Map<TDto>(model);
        var dtoString = JsonConvert.SerializeObject(dto, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

        var postRequest = new HttpRequestMessage(HttpMethod.Post, Uri.AbsoluteUri);
        postRequest.Headers.Add("Accept", "*/*");
        postRequest.Content = new StringContent(dtoString, System.Text.Encoding.UTF8, "application/json-patch+json");
        var response = await HttpClient.SendAsync(postRequest);
            
        response.EnsureSuccessStatusCode();
    }

    public async Task Delete(Guid guid)
    {
        string sguid = "/" + guid.ToString();
        var uriDelete = new Uri(Uri + sguid);
        await HttpClient.DeleteAsync(uriDelete);
    }

    public async Task Update(TModel model, Guid guid)
    {
        var dto = Mapper.Map<TDto>(model);


        string sguid = "/" + guid.ToString();
        var uriUpdate = new Uri(Uri + sguid);

        await HttpClient.PutAsJsonAsync(uriUpdate, dto);
    }
}