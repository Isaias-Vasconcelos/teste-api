namespace TesteAPI.Models
{
    public class Auth
    {
        public string Token { get; set; }
        public string RedirectUrl { get; set; }
        public DateTime Expiration { get; set; }
    }
}
