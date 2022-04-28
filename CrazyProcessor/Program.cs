// See https://aka.ms/new-console-template for more information

using CrazyProcessor;
using CrazyProcessor.App;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
Startup.ConfigureServices(services);
var appService = services
    .BuildServiceProvider()
    .GetService<IAppService>();

if (appService == null)
{
    throw new NullReferenceException(nameof(appService));
}

appService.StartApp();
