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
    public class SaidaRepository : BaseRepository<Saida>, ISaidaRepository
    {
        private readonly SqlServerContext _context;

        public SaidaRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public List<Saida> GetByDataSaida(DateTime dataMin, DateTime dataMax)
        {
            return _context.Saida
                 .Include(x => x.Mercadoria) 
               .Where(x => x.DataHoraSaida >= dataMin && x.DataHoraSaida <= dataMax)
               .OrderBy(x => x.DataHoraSaida)
               .ToList();
        }
    }
}
