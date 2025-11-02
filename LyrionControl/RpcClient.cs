using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LyrionControl.JsonRpcClient
{
    public class RpcClient
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public RpcClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            jsonSerializerOptions = new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
            };
        }
        public async Task<T?> MakeRequestAsync<T>(IRequest request)
        {
            var response = await httpClient.PostAsJsonAsync(RequestUri.Uri, request);
            var data = await response.Content.ReadAsStringAsync();            
            jsonSerializerOptions.Converters.Add(new ArrayListJsonConverter());

            return JsonSerializer.Deserialize<T>(data, jsonSerializerOptions);
        }
    }
}
