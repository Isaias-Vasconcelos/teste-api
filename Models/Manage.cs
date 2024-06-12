namespace TesteAPI.Models
{
    public class Manage
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string[] Roles { get; set; }
    }
}