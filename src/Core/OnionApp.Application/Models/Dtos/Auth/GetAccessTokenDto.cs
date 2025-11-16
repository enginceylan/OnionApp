namespace OnionApp.Application.Models.Dtos.Auth
{
    public class GetAccessTokenDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
