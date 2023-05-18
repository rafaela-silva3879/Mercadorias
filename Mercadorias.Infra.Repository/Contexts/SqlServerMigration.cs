using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadorias.Infra.Repository.Contexts
{
    /// <summary>
    /// Classe para executar o MIGRATIONS do EF na base de dados
    /// </summary>
    public class SqlServerMigration : IDesignTimeDbContextFactory<SqlServerContext>
    {
        public SqlServerContext CreateDbContext(string[] args)
        {
            //conectar no banco de dados utilizando a connectionstring
            //mapeada no arquivo appsettings.json e então executar as alterações
            //na base conforme o mapeamento das entidades
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            var connectionstring = root.GetSection("ConnectionStrings")
                .GetSection("Conexao").Value;

            var builder = new DbContextOptionsBuilder<SqlServerContext>();
            builder.UseSqlServer(connectionstring);

            return new SqlServerContext(builder.Options);
        }
    }
}
