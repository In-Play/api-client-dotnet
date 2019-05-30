using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using In_Play.Api.Client.Credentials;
using In_Play.Api.Client.Internals;
using NameValuePair = System.Collections.Generic.KeyValuePair<string, string>;

namespace In_Play.Api.Client.Clients
{
    /// <summary>
    ///     Abstract token endpoint client able to handle custom token endpoint grants
    /// </summary>
    public sealed class CustomGrantTokenClient : IDisposable
    {
        private readonly IClientCredentials _clientCredentials;
        private readonly TokenEndpointHttpClient _tokenEndpointHttpClient;

        private bool _disposed;

        /// <summary>
        ///     Create new CustomGrantTokenClient
        /// </summary>
        /// <param name="tokenEndpointUri">OAuth2 token endpoint URI</param>
        /// <param name="clientCredentials">Client credentials</param>
        /// <param name="grantType">OAuth2 grant_type</param>
        public CustomGrantTokenClient(string tokenEndpointUri, IClientCredentials clientCredentials, string grantType)
        {
            _tokenEndpointHttpClient = new TokenEndpointHttpClient(tokenEndpointUri);
            _clientCredentials = clientCredentials;
            GrantType = grantType;
        }

        /// <summary>
        ///     Grant type (i.e. "client_credentials")
        /// </summary>
        public string GrantType { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Retrieve access token for the configured "client_id" and specified scopes. Request to the server is only performed
        ///     if matching valid token is not in the cache
        /// </summary>
        /// <param name="parameters">Grant-specific parameters</param>
        /// <param name="scopes">OAuth2 scopes to request</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Access token</returns>
        public async Task<Tuple<string, TimeSpan>> GetTokenInternalAsync(IList<NameValuePair> parameters,
            string[] scopes, CancellationToken token)
        {
            var scopeString = ScopeHelper.ToScopeString(scopes);

            var form = new List<NameValuePair>
            {
                new NameValuePair("grant_type", GrantType)
            };

            form.AddRange(_clientCredentials.PostParams);

            if (scopeString != null) form.Add(new NameValuePair("scope", scopeString));

            form.AddRange(parameters);

            var result = await _tokenEndpointHttpClient.GetToken(form, token).ConfigureAwait(false);

            return result;
        }

        ~CustomGrantTokenClient()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _tokenEndpointHttpClient.Dispose();

                _disposed = true;
            }
        }
    }
}