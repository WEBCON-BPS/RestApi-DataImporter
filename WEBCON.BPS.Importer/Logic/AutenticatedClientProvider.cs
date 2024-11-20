using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WEBCON.BPS.Importer.Model;

namespace WEBCON.BPS.Importer.Logic
{
    public class AutenticatedClientProvider
    {
        private readonly Configuration _config;
        private HttpClient _client;

        public AutenticatedClientProvider(Configuration config)
        {
            _config = config;
        }

        public async Task<HttpClient> GetClientAsync()
        {
            if (_client == null)
                _client = await PrepareClient();

            return _client;
        }

        private async Task<HttpClient> PrepareClient()
        {
            var client = new HttpClient();
            client.BaseAddress = GetFixedTrailingSlashBaseAddress();
            var auth = new LoginModel(_config.ClientId, _config.ClientSecret);
            var response = await TryGetTokenAsync(client, auth);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new ApiException().CreateEx(result);

            var accessToken = JsonConvert.DeserializeObject<Token>(result).access_token;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            return client;
        }

        private async Task<HttpResponseMessage> TryGetTokenAsync(HttpClient client, LoginModel credentials)
        {
            var parms = new Dictionary<string, string>
            {
                { "client_id", credentials.ClientId },
                { "client_secret", credentials.ClientSecret },
                { "grant_type", "client_credentials" }
            };
            return await client.PostAsync("api/oauth2/token", new FormUrlEncodedContent(parms));
        }

        private Uri GetFixedTrailingSlashBaseAddress()
        {
            var url = _config.PortalUrl.EndsWith("/") ? _config.PortalUrl : $"{_config.PortalUrl}/";
            return new Uri(url);
        }

        internal struct Token
        {
            public string access_token { get; set; }
        }
    }
}
