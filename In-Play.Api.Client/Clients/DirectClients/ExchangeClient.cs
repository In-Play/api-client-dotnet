using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return Task.Run<SymbolExchanges>(() => base.Get<SymbolExchanges>("/home/GetExchanges"));
        }
    }
}
