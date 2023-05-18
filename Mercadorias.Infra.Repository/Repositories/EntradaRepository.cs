using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercadorias.Domain.Entities;
using Mercadorias.Domain.Interfaces.Repositories;
using Mercadorias.Infra.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
namespace Mercadorias.Infra.Repository.Repositories
{
    public class EntradaRepository : BaseRepository<Entrada>, IEntradaRepository
    {
        private readonly SqlServerContext _context;

        public EntradaRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public List<Entrada> GetByDataEntrada(DateTime dataMin, DateTime dataMax)
        {
            return _context.Entrada
               .Include(x=>x.Mercadoria)
               .Where(x => x.DataHoraEntrada >= dataMin && x.DataHoraEntrada <= dataMax)              
               .OrderBy(x => x.DataHoraEntrada)
               .ToList();
        }

        public override List<Entrada> GetAll()
        {
            return _context.Entrada
                .Include(x => x.Mercadoria)
                .ToList();
        }
    }
}
