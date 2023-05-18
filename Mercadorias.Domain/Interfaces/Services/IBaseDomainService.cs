using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadorias.Domain.Interfaces.Services
{
    public interface IBaseDomainService<T> where T : class
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);
        T GetById(Guid id);

        List<T> GetAll();
    }
}
