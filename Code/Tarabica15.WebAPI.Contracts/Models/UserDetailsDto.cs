namespace Tarabica15.WebAPI.Contracts.Models
{
    public class UserDetailsDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string SessionId { get; set; }
        public string Language { get; set; }
    }
}