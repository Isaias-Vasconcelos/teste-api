using TesteAPI.Models;

namespace TesteAPI.Services
{
    public interface IHttpService
    {
        Task<Response> Post(Credentials credentials);
    }
}
