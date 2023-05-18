using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercadorias.Domain.Entities;
namespace Mercadorias.Application.Interfaces
{
    public interface ISaidaApplicationService : IBaseApplicationService<Saida>
    {
        List<Saida> GetByDataSaida(DateTime dataMin, DateTime dataMax);
    }
}
