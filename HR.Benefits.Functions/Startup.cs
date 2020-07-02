using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using HR.Benefits.Functions.Interfaces;
using HR.Benefits.Functions.Implementation;

[assembly: FunctionsStartup(typeof(HR.Benefits.Functions.Startup))]

namespace HR.Benefits.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {            
            builder.Services.AddSingleton<IProcessorFactory, ProcessorFactory>();            
        }
    }
}
