

using GEPTS.Application.Services;
using GEPTS.Features.Contrats.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GETPS.Extensions
{
    public static class ControllerServiceRegistration
    {
        public static IServiceCollection ConfigureControllerServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceDeMatiere, ServiceDeMatiere>();
            services.AddScoped<IServiceDeProgrammation, ServiceDeProgrammation>();

            return services;
        }
    }
}
