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


            //            var client = new MLBExchangesClient("d3cb4727cac14176ba67d97805f15588");
            //            var res = client.GetExchanges().Result;


            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("date", "date")
            };



            //            var directClient1 = new AccountClient(Configuration.GetCredentials()).GetCountries().Result;

            var directAccountClient= new AccountClient(new ClientCredentials()
            {
                UserName = "user",
                Password = "admin1234",
                ClientSecret = "in-play",
                ClientId = "DesktopApp"
            });//.GetCountries().Result;

            var directExchangeClient = new ExchangeClient(Configuration.GetCredentials());

            var re = directAccountClient.GetUserInfo().Result;
            var exchanges = directExchangeClient.GetExchanges().Result;

//            Console.WriteLine("result:" + res.FirstOrDefault().StatusExchange);
            Console.WriteLine("First country name:" + re);




            Console.ReadKey();




        }
    }
}
