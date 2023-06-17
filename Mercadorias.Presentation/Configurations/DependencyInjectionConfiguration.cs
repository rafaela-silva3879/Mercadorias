using Mercadorias.Application.Interfaces;
using Mercadorias.Application.Services;
using Mercadorias.Domain.Interfaces.Repositories;
using Mercadorias.Domain.Interfaces.Services;
using Mercadorias.Domain.Services;
using Mercadorias.Infra.Repository.Contexts;
using Mercadorias.Infra.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mercadorias.Presentation.Configurations
{
    public class DependencyInjectionConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //capturar a connectionstring do banco de dados (appsettings.json)
            var connectionstring = configuration.GetConnectionString("Conexao");

            //mapear a injeção de dependência para a classe 'SqlServerContext' localizada
            //no projeto Repository (classe que irá fazer a conexão com o banco de dados)
            services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionstring));

            //mapear a injeção de dependencia das demais classes e interfaces do sistema
            services.AddTransient<IMercadoriaApplicationService, MercadoriaApplicationService>();
            services.AddTransient<IMercadoriaDomainService, MercadoriaDomainService>();
            services.AddTransient<IMercadoriaRepository, MercadoriaRepository>();

            services.AddTransient<IEntradaApplicationService, EntradaApplicationService>();
            services.AddTransient<IEntradaDomainService, EntradaDomainService>();
            services.AddTransient<IEntradaRepository, EntradaRepository>();


            services.AddTransient<ISaidaApplicationService, SaidaApplicationService>();
            services.AddTransient<ISaidaDomainService, SaidaDomainService>();
            services.AddTransient<ISaidaRepository, SaidaRepository>();
        }

    }
}
