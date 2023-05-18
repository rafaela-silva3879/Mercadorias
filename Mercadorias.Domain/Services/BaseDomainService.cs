using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercadorias.Domain.Interfaces.Repositories;
using Mercadorias.Domain.Interfaces.Services;
namespace Mercadorias.Domain.Services
{
    public class BaseDomainService<T> : IBaseDomainService<T>
     where T : class
    {
        //atributo
        private readonly IBaseRepository<T> _baserepository;

        //construtor para inicializar o atributo (injeção de dependência)
        public BaseDomainService(IBaseRepository<T> baserepository)
        {
            _baserepository = baserepository;
        }
        public virtual void Create(T obj)
        {
            _baserepository.Create(obj);
        }

        public virtual void Update(T obj)
        {
            _baserepository.Update(obj);
        }

        public virtual void Delete(T obj)
        {
            _baserepository.Delete(obj);
        }

        public virtual List<T> GetAll()
        {
            return _baserepository.GetAll();
        }

        public virtual T GetById(Guid id)
        {
            return _baserepository.GetById(id);
        }
    }

}
