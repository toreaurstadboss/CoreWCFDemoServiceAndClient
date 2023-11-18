using EchoService;
using Microsoft.Extensions.Configuration;
using System.ServiceModel;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json");

var config = configuration.Build();

//var client = new EchoServiceClient(EchoServiceClient.EndpointConfiguration.BasicHttpBinding_IEchoService, "http://localhost:5000/EchoService/basicHttp");

var client = new EchoServiceClient(EchoServiceClient.EndpointConfiguration.WSHttpBinding_IEchoService, config["CoreWCFEndpointBasicWsHttpBinding"]);

var simpleResult = await client.EchoAsync("Hello from a simple string variable");
Console.WriteLine(simpleResult);

var msg = new EchoMessage { Text = "Hello inside complex object (class EchoMessage instance)" };
var msgResult = await client.ComplexEchoAsync(msg);
Console.WriteLine(msgResult);

try
{
    var faultErr = await client.FailEchoAsync("Lets crash some faultexception stuff");
}
catch (FaultException<EchoFault> ferr)
{
    Console.WriteLine("Got this FaultException with payload details: " + ferr.Detail.Text);
}

Console.WriteLine("Hit the any key..");


Console.ReadKey();

