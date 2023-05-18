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
    public class SaidaDomainService : BaseDomainService<Saida>, ISaidaDomainService
    {
        private readonly ISaidaRepository _saidaRepository;

        public SaidaDomainService(ISaidaRepository saidaRepository) : base(saidaRepository)
        {
            _saidaRepository = saidaRepository;
        }

        public List<Saida> GetByDataSaida(DateTime dataMin, DateTime dataMax)
        {
            try
            {
                #region A data inicial deve ser menor ou igual a data final

                if (dataMin > dataMax)
                    throw new ArgumentException("A data de início deve ser menor ou igual a data de término.");

                #endregion

                #region Executar a consulta e retornar os dados

                return _saidaRepository.GetByDataSaida(dataMin, dataMax);

                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
