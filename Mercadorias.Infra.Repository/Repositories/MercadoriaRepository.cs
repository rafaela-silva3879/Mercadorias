using Mercadorias.Domain.Entities;
using Mercadorias.Domain.Interfaces.Repositories;
using Mercadorias.Infra.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadorias.Infra.Repository.Repositories
{
    public class MercadoriaRepository : BaseRepository<Mercadoria>, IMercadoriaRepository
    {
        private readonly SqlServerContext _context;

        //construtor para inicializar o atributo por meio de injeção de dependência
        public MercadoriaRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
    }
}
