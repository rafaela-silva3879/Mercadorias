using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercadorias.Domain.Entities;
using Mercadorias.Infra.Repository.Mappings;
namespace Mercadorias.Infra.Repository.Contexts
{
    public class SqlServerContext : DbContext
    {
        //construtor para inicializar a classe por meio de injeção de dependência
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }

        //declarar uma propriedade DbSet para cada entidade
        public DbSet<Mercadoria> Mercadoria { get; set; }
        public DbSet<Entrada> Entrada { get; set; }
        public DbSet<Saida> Saida { get; set; }

        //adicionar cada classe de mapeamento feita no projeto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new MercadoriaMap());
            modelBuilder.ApplyConfiguration(new EntradaMap());
            modelBuilder.ApplyConfiguration(new SaidaMap());
            
            
        }
       
    }
}
