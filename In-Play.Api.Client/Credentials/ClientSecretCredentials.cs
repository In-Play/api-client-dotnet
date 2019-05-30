using System.Collections.Generic;

namespace In_Play.Api.Client.Credentials
{
    /// <summary>
    ///     OAuth2 "client_secret" client credentials
    /// </summary>
    public class ClientSecretCredentials : IClientCredentials
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _password;
        private readonly string _userName;

        /// <summary>
        ///     Create new ClientSecretCredentials
        /// </summary>
        public ClientSecretCredentials(string userName, string password)
        {
            _clientId = "DesktopApp";
            _clientSecret = "in-play";
            _userName = userName;
            _password = password;
//            CredentialThumbprint = (clientId + clientSecret).Sha1Hex();
        }

        public List<KeyValuePair<string, string>> PostParams => new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("client_id", _clientId),
            new KeyValuePair<string, string>("client_secret", _clientSecret),
            new KeyValuePair<string, string>("userName", _userName),
            new KeyValuePair<string, string>("password", _password)
        };

        public string CredentialThumbprint { get; }
    }
}