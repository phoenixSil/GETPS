using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MsCommun.Extensions;
using GEPTS.Features.Contrats.Repertoire;
using GEPTS.Datas.Repertoires;
using GEPTS.Datas.Context;

namespace Gdc.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServerDbConfiguration<GetpsDbContext>(configuration);

            services.AddScoped<IPointDaccess, PointDaccess>();
            services.AddScoped<IRepertoireDeProgrammation, RepertoireDeProgrammation>();
            services.AddScoped<IRepertoireDeMatiere, RepertoireDeMatiere>();

            return services;
        }
    }
}
