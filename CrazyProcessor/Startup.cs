using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyProcessor.App;
using CrazyProcessor.Auth;
using CrazyProcessor.Processor;
using Microsoft.Extensions.DependencyInjection;

namespace CrazyProcessor
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IAppService, AppService>()
                .AddSingleton<IConsoleAdapter, ConsoleAdapter>()
                .AddSingleton<IAuthService, AuthService>()
                .AddSingleton<IFileProvider, FileProvider>()
                .AddSingleton<ITextProcessor, TextProcessor>();
        }
    }
}
