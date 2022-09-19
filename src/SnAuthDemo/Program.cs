using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SenseNet.Client;
using SenseNet.Extensions.DependencyInjection;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
    .AddUserSecrets("1587edec-e6f2-487b-b724-9145275cc73f")
    .Build();

// assemble a service container and register the sensenet repository service
var provider = new ServiceCollection()
    .AddSenseNetRepository(options => { config.Bind("sensenet", options); })
    .AddLogging(logging => logging.AddConsole())
    .BuildServiceProvider();

var serverFactory = provider.GetRequiredService<IServerContextFactory>();
var server = await serverFactory.GetServerAsync();

var children = await Content.LoadCollectionAsync("/Root", server);
Console.WriteLine("Children of /Root");
foreach (var content in children)
    Console.WriteLine($"  {content.Name,-20} {content["Type"]}");
