using webAPI.Repository.Extentions;
using Microsoft.Extensions.DependencyInjection;
using webAPI.Bussiness.Processor.Interface;

namespace webAPI.Bussiness.Processor.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessProcessor(this IServiceCollection services, string defaultConnectionString)
        {
            services.AddRepository(defaultConnectionString);
            services.AddScoped<IJobProcessor, JobProcessor>();
        }
    }
}
