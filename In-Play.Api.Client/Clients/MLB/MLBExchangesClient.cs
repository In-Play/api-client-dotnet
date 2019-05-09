using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using In_Play.Api.Client.Models.MLB;

namespace In_Play.Api.Client.Clients.MLB
{
    public class MLBExchangesClient : BaseClient
    {
        public MLBExchangesClient(string apiKey) : base(apiKey) { }
        public MLBExchangesClient(Guid apiKey) : base(apiKey) { }

        public Task<List<Exchange>> GetExchanges()
        {
                return Task.Run<List<Exchange>>(() =>
                base.Get<List<Exchange>>("/mlb/exchange/getexchanges")
            );
        }

        public Task<Lineup> GetLineupAsync(string exchangeName)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("exchangeName", exchangeName)
            };

            return Task.Run<Lineup>(() =>
                base.Get<Lineup>("/mlb/exchange/getlineup/{exchangeName}", parameters)
            );
        }

        public Task<Lineup> GetMarketById(string id)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("id", id)
            };

            return Task.Run<Lineup>(() =>
                base.Get<Lineup>("mlb/exchange/getsymbolbyid/{id}", parameters)
            );
        }

        public Task<Lineup> GetPlays(int eventId)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("eventId", eventId.ToString())
            };

            return Task.Run<Lineup>(() =>
                base.Get<Lineup>("mlb/exchange/getPlays/{eventId}", parameters)
            );
        }

    }
}
