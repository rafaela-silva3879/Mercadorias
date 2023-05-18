using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercadorias.Domain.Entities;
using Mercadorias.Domain.Interfaces.Repositories;
using Mercadorias.Domain.Interfaces.Services;
namespace Mercadorias.Domain.Services
{
    public class MercadoriaDomainService : BaseDomainService<Mercadoria>, IMercadoriaDomainService
    {
        private readonly IMercadoriaRepository _mercadoriaRepository;

        public MercadoriaDomainService(IMercadoriaRepository mercadoriaRepository)
            :base(mercadoriaRepository)
        {
            _mercadoriaRepository = mercadoriaRepository;
        }
    }
}
