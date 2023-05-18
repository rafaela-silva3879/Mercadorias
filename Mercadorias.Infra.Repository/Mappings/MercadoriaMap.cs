using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mercadorias.Domain.Entities;
namespace Mercadorias.Infra.Repository.Mappings
{
    public class MercadoriaMap : IEntityTypeConfiguration<Mercadoria>
    {
        public void Configure(EntityTypeBuilder<Mercadoria> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.NumeroRegistro)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(m => m.Fabricante)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Tipo)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(m => m.Descricao)
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}