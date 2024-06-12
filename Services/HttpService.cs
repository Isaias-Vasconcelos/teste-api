using System.Text;
using System.Text.Json;
using TesteAPI.Models;

namespace TesteAPI.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> Post(Credentials credentials)
        {
            try
            {
                StringContent jsonBody = new(JsonSerializer.Serialize(new
                {
                    email = credentials.Email,
                    password = credentials.Password
                }),
                Encoding.UTF8,
                "application/json");

                var request = await _httpClient.PostAsync("/auth/Login", jsonBody);

                if (!request.IsSuccessStatusCode) throw new Exception("Deu erro na api!");

                var response = await request.Content.ReadFromJsonAsync<Auth>();

                Console.WriteLine(response);

                return new Response
                {
                    IsSuccess = true,
                    Message = "Autenticado",
                    Token = response.Token
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
