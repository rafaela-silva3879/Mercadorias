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
    public class SaidaMap : IEntityTypeConfiguration<Saida>
    {

        public void Configure(EntityTypeBuilder<Saida> builder)
        {
            builder.HasKey(s => s.IdSaida);

            builder.Property(s => s.QuantidadeSaida)
                .IsRequired();

            builder.Property(s => s.DataHoraSaida)
                .IsRequired();

            builder.Property(s => s.LocalSaida)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(s => s.Mercadoria)
                .WithMany(m => m.Saidas)
                .HasForeignKey(s => s.IdSaida)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
