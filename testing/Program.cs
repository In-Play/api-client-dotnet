using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using In_Play.Api.Client.Clients.B2BClients.MLB;
using In_Play.Api.Client.Clients.DirectClients;
using In_Play.Api.Client.Credentials;
using In_Play.Api.Client.Models;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {

            //------------ sample B2B Client : 
            var b2bClient = new MLBExchangesClient("d3cb4727cac14176ba67d97805f15588");
            var exchanges = b2bClient.GetExchanges().Result.ToList();


            foreach (var exchange in exchanges)
            {
                Console.WriteLine($"{exchange.FullName} - {exchange.EventId}");
            }

           // Console.ReadKey();

            //--------------sample Direct Client-------------------------

            
            var directAccountClient= new AccountClient(new ClientCredentials()
            {
                UserName = "user",
                Password = "11111111",
            });

            //or you can use 'get credentials':
            //var directAccountClient = new AccountClient(Configuration.GetCredentials());


            Console.WriteLine($"{directAccountClient.GetUserInfo().Result.UserInfo.UserName}");
            
            Console.ReadKey();




        }
    }
}
