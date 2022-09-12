using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Persistence.Context;
using Kodlama.io.Devs.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.io.Devs.Persistence
{
    public static class PersistenceServiceRegistration
    {
        /// <ÖZET>
        /// 
        /// this IServiceCollection services ile extension uygularız yani webAPI deki services ı genişleterek orayı rahatlatmış oluruz
        /// Bu katmandaki servisler burada tanımlanır.
        /// <returns></returns>
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("LanguageProjectConnectionString")));
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILanguageTechnologyRepository, LanguageTechnologyRepository>();



            return services;
        }
    }
}