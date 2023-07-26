using Microsoft.EntityFrameworkCore;
using webAPI.Bussiness.Processor;
using webAPI.Data;
using webAPI.Repository.Interface;

namespace webAPI.Repository.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepository(this IServiceCollection services, string defaultConnectionString)
        {
            services.AddDbContext<ServiceDBContext>(options => options.UseMySql(defaultConnectionString, ServerVersion.AutoDetect(defaultConnectionString)));
            services.AddScoped<IJobRepository, JobRepository>();
        }
    }
}
