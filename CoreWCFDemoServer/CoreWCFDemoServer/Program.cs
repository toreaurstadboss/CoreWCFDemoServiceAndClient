using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using CoreWCFDemoServer;
using CoreWCFDemoServer.CoreWCfDemoServer;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.AllowSynchronousIO = true;
});

// Add WSDL support 
builder.Services.AddServiceModelServices().AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

var app = builder.Build();

// Configure an explicit none credential type for WSHttpBinding as it defaults to Windows which requires extra configuration in
var myWSHttpBinding = new WSHttpBinding(SecurityMode.Transport);
myWSHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

app.UseServiceModel(builder =>
{
    builder
        .AddService<EchoService>((serviceOptions) => { })
        .AddServiceEndpoint<EchoService, IEchoService>(new BasicHttpBinding(), "/EchoService/basichttp")
        .AddServiceEndpoint<EchoService, IEchoService>(myWSHttpBinding, "/EchoService/WSHttps");
});

var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
serviceMetadataBehavior.HttpGetEnabled = true;
serviceMetadataBehavior.HttpsGetEnabled = true;

app.MapGet("/", () => "Hello World!");

app.Run();
