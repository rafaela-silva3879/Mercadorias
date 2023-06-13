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
    public class EntradaMap : IEntityTypeConfiguration<Entrada>
    {
            public void Configure(EntityTypeBuilder<Entrada> builder)
            {
                builder.HasKey(e => e.IdEntrada);

                // Mapeamento das propriedades
                builder.Property(e => e.QuantidadeEntrada)
                    .IsRequired();

                builder.Property(e => e.DataHoraEntrada)
                    .IsRequired();

                builder.Property(e => e.LocalEntrada)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.HasOne(s => s.Mercadoria)
             .WithMany(m => m.Entradas)
             .HasForeignKey(s => s.IdMercadoria)
             .OnDelete(DeleteBehavior.NoAction);
        }
        }
    }

