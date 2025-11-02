using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LyrionControl.JsonRpcClient
{
    public class RpcClient
    {
        private readonly HttpClient httpClient;

        public RpcClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<T> MakeRequest<T>(IRequest request)
        {
            var response = await httpClient.PostAsJsonAsync(RequestUri.Uri, request);
            var data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
            };
            options.Converters.Add(new ArrayListJsonConverter());

            return JsonSerializer.Deserialize<T>(data, options);
        }
    }
}
