# In-Play api-client-dotnet

We have two types of API Clients: 

## Direct API Client 

You can use direct api for your enduser (you should have user account on in-play.io web site). With this api you can get/change all information about user, make orders, and so on.

[In-Play](https://in-play.io) Direct API client library wrapper for C# (.NET 4.6).

## B2B API Client

[In-Play](https://in-play.io) B2B API client library wrapper for C# (.NET 4.6). For more information on the In-Play API check the [In-Play Developer Portal](developer.in-play.io). 

## Installation
This library is distributed on `Nuget`. In order to add to your visual studio project, open the nuget package manager console and use the command:

```
PM> Install-Package In-Play.Api.Client 
```

## Authentication for B2B API services

You can find your api keys in the [In-Play Developer Portal](developer.in-play.io. See [Usage](#Usage) for implementation details.

## Authentication for Direct API services

You need to have your credentials for main [In-Play](https://in-play.io) Web site.

## Usage B2B API services
In this simple example we authenticate the `MLBExchangesClient` client with its key get exchanges list and just output some information about it to the console. Be sure to replace `<license key>` with your API key for this client.
``` cs
// Connect to client and get data
var client = new MLBExchangesClient("<license key>");
var exchanges = client.GetExchanges().toList();

// Write data to console
foreach (var exchange in exchanges)
{
	Console.WriteLine($"{exchange.FullName} - {exchange.EventId}");
}
```

## Usage Direct API services
In this sample client we authenticate the `AccountClient` with main personal credentials (just regular credentials on in-play.io). And get User info.

var directAccountClient= new AccountClient(new ClientCredentials()
                        {
                            UserName = "username",
                            Password = "xxxxx",
                        });
	

//write `UserInfo` data to console: 
Console.WriteLine($"{directAccountClient.GetUserInfo().Result.UserInfo.UserName}");

## Documentation
* [In-play Developer Portal](developer.in-play.io)
* [Integration Guide](https://developer.in-play.io/integration)
* [Data Dictionary](https://developer.in-play.io/developer)
* [Find your license keys](https://developer.in-play.io/developer)
