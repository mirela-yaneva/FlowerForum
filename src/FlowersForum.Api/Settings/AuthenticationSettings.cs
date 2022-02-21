namespace FlowersForum.Api.Settings
{
    public class AuthenticationSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string[] Scopes { get; set; }
        public string Audience { get; set; }
    }
}
