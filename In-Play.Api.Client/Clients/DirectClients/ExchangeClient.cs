using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using In_Play.Api.Client.Models;
using In_Play.Api.Client.Models.Direct;

namespace In_Play.Api.Client.Clients.DirectClients
{
    public class ExchangeClient : BaseClient
    {
        public ExchangeClient(ClientCredentials credentials) : base(credentials)
        {
        }

        public Task<SymbolExchanges> GetExchanges()
        {
            return Task.Run(() => Get<SymbolExchanges>("/home/GetExchanges"));
        }


        public Task<SymbolExchanges> OrderCreate(OrderRequest req)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("symbolId", req.SymbolId),
                new KeyValuePair<string, string>("Quantity", req.Quantity.ToString()),
                new KeyValuePair<string, string>("LimitPrice", req.LimitPrice.ToString()),
                new KeyValuePair<string, string>("Side", req.Side.ToString())
            };

            return Task.Run(() => Post<SymbolExchanges>("/order/Create", parameters, new CancellationToken()));
        }
    }
}