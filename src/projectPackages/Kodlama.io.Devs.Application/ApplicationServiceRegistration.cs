using Core.Application.Pipelines.Validation;
using Kodlama.io.Devs.Application.Features.Languages.Rules;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Kodlama.io.Devs.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<LanguageBusinessRules>();
            services.AddScoped<LanguageTechnologyBusinessRules>();


            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));


            return services;
        }
    }
}
