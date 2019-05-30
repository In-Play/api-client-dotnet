using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace In_Play.Api.Client.Clients.B2BClients
{
    public abstract class BaseClient
    {
        protected BaseClient(string apiKey)
        {
            Host = "in-play.azure-api.net";
            ApiKey = apiKey.Replace("-", "").ToLower();
            Https = true;
            Encoding = new UTF8Encoding();
        }

        protected BaseClient(Guid apiKey) : this(apiKey.ToString())
        {
        }

        /// <summary>
        ///     The host name for making API calls.
        /// </summary>
        /// <value>Default value is in-play.azure-api.net</value>
        public string Host { get; set; }

        /// <summary>
        ///     The client license key used to make API calls.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        ///     Indicates whether API calls will be made over secure https connection.
        /// </summary>
        /// <value>Default value is true</value>
        public bool Https { get; set; }

        /// <summary>
        ///     The encoding type to be used in the WebClient for data pulled
        /// </summary>
        /// <value>Default is UTF8</value>
        public Encoding Encoding { get; set; }

        private string Scheme => Https ? "https" : "http";

        protected T Get<T>(string apiCall)
        {
            return Get<T>(apiCall, null);
        }

        protected T Get<T>(string apiCall, IList<KeyValuePair<string, string>> parameters)
        {
            using (var client = new WebClient())
            {
                var res = default(T);
                var url = string.Empty;

                try
                {
                    // Add api key
                    client.Headers.Add("Ocp-Apim-Subscription-Key", ApiKey);

                    // Construct url
                    var uri = new UriBuilder(Scheme, Host);
                    uri.Path = apiCall;
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
    }
}