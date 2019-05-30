using System.Threading.Tasks;
using In_Play.Api.Client.Models;
using In_Play.Api.Client.Models.Direct;

namespace In_Play.Api.Client.Clients.DirectClients
{
    public class AccountClient : BaseClient
    {
        public AccountClient(ClientCredentials credentials) : base(credentials)
        {
        }

        public Task<CountryCollection> GetCountries()
        {
            return Task.Run(() => Get<CountryCollection>("/account/getcountries"));
        }

        public Task<UserDataModel> GetUserInfo()
        {
            return Task.Run(() => Get<UserDataModel>("/account/getuserInfo"));
        }
    }
}