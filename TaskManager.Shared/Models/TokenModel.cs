namespace TaskManager.Shared.Models
{
    public class TokenModel
    {
        public required string Token { get; set; }
        public DateTime Expiracao { get; set; }
    }

    public class JwtSettings
    {
        public required string Key { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
    }
}
