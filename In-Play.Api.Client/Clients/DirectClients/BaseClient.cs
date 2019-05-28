using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using In_Play.Api.Client.Credentials;
using In_Play.Api.Client.Models;
using Microsoft.Build.Framework.XamlTypes;
using Newtonsoft.Json;

namespace In_Play.Api.Client.Clients.DirectClients
{
    public abstract class BaseClient
    {
        /// <summary>
        /// The host name for making API calls.
        /// </summary>
        /// <value>Default value is in-play.azure-api.net</value>
        private const string Host = "test.in-play.io/api/";

        /// <summary>
        /// Bearer Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Indicates whether API calls will be made over secure https connection.
        /// </summary>
        /// <value>Default value is true</value>
        public bool Https { get; set; }

        /// <summary>
        /// The encoding type to be used in the WebClient for data pulled
        /// </summary>
        /// <value>Default is UTF8</value>
        public Encoding Encoding { get; set; }

        private string Scheme => Https ? "https://" : "http://";

        private readonly HttpClient _httpClient = new HttpClient();

        protected BaseClient(ClientCredentials credentials)
        {

            Https = true;
            Encoding = new UTF8Encoding();

            var _tokenClient = new ClientCredentialsGrantTokenClient($"{Scheme}{Host}/token" , new ClientSecretCredentials(
                    credentials.UserName, 
                    credentials.Password
                ));

            Token = _tokenClient.GetTokenAsync(new[] { "" }).Result;
        }

        protected T Get<T>(string apiCall) { return Get<T>(apiCall, null); }

        protected T Get<T>(string apiCall, IList<KeyValuePair<string, string>> parameters)
        {
            using (var client = new System.Net.WebClient())
            {
                var res = default(T);
                var url = string.Empty;

                try
                {
                    // Add api key
                    client.Headers.Add("Authorization", $"Bearer {Token}");

                    // Construct url
                    var uri = new UriBuilder(this.Scheme, Host) {Path = apiCall};
                    url = uri.Uri.ToString().ToLower().Trim();

                    // Make sure parameters exist and add format=json
                    if (parameters == null) parameters = new List<KeyValuePair<string, string>>();
                    parameters.Add(new KeyValuePair<string, string>("format", "json"));

                    // Add parameters
                    foreach (var parameter in parameters)
                        url = url.Replace("{" + parameter.Key.ToLower() + "}", parameter.Value.ToLower().Trim());

                    // Download json, deserialize it, and return it
                    var json = client.DownloadString(url);
                    var replace = json.Replace("'", "`");

                    res = JsonConvert.DeserializeObject<T>(replace);
                }
                catch (Exception e)
                {
                    Logger.Error($"BaseClientError. url: {url}", e);
                }

                return res;
            }

        }


        protected async Task<T> Post<T>(string path, IList<KeyValuePair<string, string>> parameters, CancellationToken token)
        {

            // Make sure parameters exist and add format=json
            if (parameters == null) parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("format", "json"));

            // Add parameters
//            foreach (var parameter in parameters)
//                url = url.Replace("{" + parameter.Key.ToLower() + "}", parameter.Value.ToLower().Trim());



            // Construct url
            var uri = new UriBuilder(this.Scheme, Host) { Path = path };
            var url = uri.Uri.ToString().ToLower().Trim();

            var requestBody = new FormUrlEncodedContent(parameters);

            //set Authorization header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            var response = await _httpClient.PostAsync(url, requestBody, token).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                throw new TokenEndpointException($"{(int)response.StatusCode} {response.ReasonPhrase}: {content}");
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception e)
            {
                throw new TokenEndpointException("fail", e);
            }
        }


        
    }
}
