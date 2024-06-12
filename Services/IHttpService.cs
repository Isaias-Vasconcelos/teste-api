using TesteAPI.Models;

namespace TesteAPI.Services
{
    public interface IHttpService
    {
        Task<Manage> Info();
        Task<Response> Post(Credentials credentials);
    }
}
