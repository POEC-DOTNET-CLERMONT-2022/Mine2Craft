using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using AutoMapper;
using Dtos;
using Models;

namespace Mine2CraftWinApp.Request
{
    public class CompleteItemRequest
    {
        private HttpClient _httpClient;

        public IEnumerable<CompleteItemModel>? CompleteItems { get; private set; } = new List<CompleteItemModel>();
        
        private readonly IMapper _mapper
            = ((App)Application.Current).Mapper;

        public CompleteItemRequest()
        {
            _httpClient = new HttpClient();
        }

        public async Task GetCompleteItems()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:7204/api/CompleteItem");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var completeItemsDtos = await JsonSerializer.DeserializeAsync<IEnumerable<CompleteItemDto>>(responseStream);
                CompleteItems = _mapper.Map<IEnumerable<CompleteItemModel>>(completeItemsDtos);
            }
        }

        public async Task CreateCompleteItem(string name, int durability, string description)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
                "https://localhost:7204/api/CompleteItem");

            request.Content = JsonContent.Create(new { Id = Guid.NewGuid(), Name = name, Durability = durability, Description = description });

            await _httpClient.SendAsync(request);

        }

        public async Task DeleteCompleteItem(Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete,
                $"https://localhost:7204/api/CompleteItem/{id}");

            await _httpClient.SendAsync(request);
        }
    }
}
