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
    public class EntradaDomainService : BaseDomainService<Entrada>, IEntradaDomainService
    {
        private readonly IEntradaRepository _entradaRepository;

        public EntradaDomainService(IEntradaRepository entradaRepository):base(entradaRepository)
        {
            _entradaRepository = entradaRepository;
        }

        public List<Entrada> GetByDataEntrada(DateTime dataMin, DateTime dataMax)
        {
            try
            {
                #region A data inicial deve ser menor ou igual a data final

                if (dataMin > dataMax)
                    throw new ArgumentException("A data de início deve ser menor ou igual a data de término.");

                #endregion

                #region Executar a consulta e retornar os dados

                return _entradaRepository.GetByDataEntrada(dataMin, dataMax);

                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
