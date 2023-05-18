using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mercadorias.Domain.Interfaces.Repositories;
using Mercadorias.Infra.Repository.Contexts;

namespace Mercadorias.Infra.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
            where T : class
    {
        private readonly SqlServerContext _context;

        public BaseRepository(SqlServerContext context)
        {
            _context = context;
        }
        public virtual void Create(T obj)
        {
            _context.Entry(obj).State = EntityState.Added;
            _context.SaveChanges();
        }

        public virtual void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delete(T obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
