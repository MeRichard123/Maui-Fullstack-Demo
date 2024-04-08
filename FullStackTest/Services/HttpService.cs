using System.Net.Http.Json;

namespace FullStackTest.Services
{
    // SINGLETON PATTERN
    public interface IHttpService
    {
        Task<List<Product>> GetPizzas();
    }

    class HttpService : IHttpService
    {
        private static readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://10.0.2.2:5141/api/")
        };

        public HttpService()
        {
            
        }

        public async Task<List<Product>> GetPizzas()
        {
            try
            {
                using HttpResponseMessage response = await _httpClient.GetAsync("pizza");

                response.EnsureSuccessStatusCode();

                var jsonResponse = await (response.Content.ReadFromJsonAsync<List<Product>>());

                if (jsonResponse != null)
                {
                    return jsonResponse;
                }
                else
                {
                    return new List<Product>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Product>();
            }
        }
    }
}
