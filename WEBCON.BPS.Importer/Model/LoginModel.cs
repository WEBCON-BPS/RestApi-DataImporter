namespace WEBCON.BPS.Importer.Model
{
    public class LoginModel
    {
        public LoginModel (string clientId, string clientSecret)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;

        }

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
