namespace WEBCON.BPS.Importer.Model
{
    public class LoginModel
    {
        public LoginModel (string clientId, string clientSecret, string login = null)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;

            if (!string.IsNullOrEmpty(login))
                this.impersonation = new Impersonation() { login = login };
        }

        public string clientId { get; set; }
        public string clientSecret { get; set; }
        public Impersonation impersonation { get; set; }
    }

    public class Impersonation
    {
        public string login { get; set; }
    }
}
