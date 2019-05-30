using System;
using System.Collections.Specialized;
//using System.Configuration.ConfigurationManager;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using System.Reflection;
using In_Play.Api.Client.Models;
using Microsoft.Extensions.Configuration;

namespace In_Play.Api.Client.Credentials
{
    public class Configuration
    {
        public static string ClientId => GetSettings("ClientId", "DirectApiCredentials");

        public static string ClientSecret => GetSettings("ClientSecret", "DirectApiCredentials");

        public static string UserName => GetSettings("UserName", "DirectApiCredentials");

        public static string Password => GetSettings("Password", "DirectApiCredentials");

        //http://stackoverflow.com/a/283917
        public static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static string ExecutingAssembly
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return new FileInfo(path).FullName;
            }
        }

        private static string GetSettings(string key, string sectionName = "appSettings")
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Directory where the json files are located
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Use configuration as in every web project
            var settings = configuration.GetSection("MyOptions");//.Get<ClientCredentials>();

//            var settings = (NameValueCollection) ConfigurationManager.GetSection(sectionName);

            if (settings != null)
                if (settings[key] != null)
                    return settings[key];
            throw new Exception(sectionName + "/" + key +
                                " missing from config file in assembly (DOUBLE CHECK THIS PATH): " + ExecutingAssembly);
        }

        /// <summary>
        ///     Get an appsetting but does NOT throw an error if settings does not exist.
        /// </summary>
        public static bool TryGetSettings(string key, out string value)
        {
            try
            {
                value = GetSettings(key);
                return true;
            }
            catch
            {
                value = "";
                return false;
            }
        }

        public static ClientCredentials GetCredentials()
        {
            return new ClientCredentials
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                Password = Password,
                UserName = UserName
            };
        }
    }
}