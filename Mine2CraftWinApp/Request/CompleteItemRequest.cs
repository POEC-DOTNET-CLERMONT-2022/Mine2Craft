using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Documents;
using Dtos;

namespace Mine2CraftWinApp.Request
{
    public class CompleteItemRequest
    {
        private HttpClient _httpClient;

        public IEnumerable<CompleteItemDto>? CompleteItems { get; private set; } = new List<CompleteItemDto>();

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
                CompleteItems = await JsonSerializer.DeserializeAsync<IEnumerable<CompleteItemDto>>(responseStream);
            }

        }

        public async Task CreateCompleteItem(string name, int durability, string description)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
                "https://localhost:7204/api/CompleteItem");

            request.Content = JsonContent.Create(new { Id = new Guid(), Name = name, Durability = durability, Description = description });

            await _httpClient.SendAsync(request);

        }
    }
}
