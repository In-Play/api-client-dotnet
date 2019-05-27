using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Reflection;
using In_Play.Api.Client.Models;

namespace In_Play.Api.Client.Credentials
{
    public class Configuration
    {
        public Configuration()
        {
        }

        public static string ClientId { get { return GetSettings("ClientId", "DirectApiCredentials"); } }

        public static string ClientSecret { get { return GetSettings("ClientSecret", "DirectApiCredentials"); } }

        public static string UserName { get { return GetSettings("UserName", "DirectApiCredentials"); } }

        public static string Password { get { return GetSettings("Password", "DirectApiCredentials"); } }
       
       //http://stackoverflow.com/a/283917
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static string ExecutingAssembly
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return new FileInfo(path).FullName;
            }
        }

        private static string GetSettings(string key, string sectionName = "appSettings")
        {
            NameValueCollection settings = (NameValueCollection)ConfigurationManager.GetSection(sectionName);

            if (settings != null)
                if (settings[key] != null)
                    return settings[key];
            throw new Exception(sectionName + "/" + key + " missing from config file in assembly (DOUBLE CHECK THIS PATH): " + ExecutingAssembly);
        }

        /// <summary>
        /// Get an appsetting but does NOT throw an error if settings does not exist.
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
            return new ClientCredentials()
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                Password = Password,
                UserName = UserName
            };
        }
    }
}