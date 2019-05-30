using System.Collections.Generic;

namespace In_Play.Api.Client.Credentials
{
    /// <summary>
    ///     OAuth2 client credentials
    /// </summary>
    public interface IClientCredentials
    {
        /// <summary>
        ///     Client credentials token request parameters
        /// </summary>
        List<KeyValuePair<string, string>> PostParams { get; }

        /// <summary>
        ///     Client credentials thumbprint value
        /// </summary>
        string CredentialThumbprint { get; }
    }
}