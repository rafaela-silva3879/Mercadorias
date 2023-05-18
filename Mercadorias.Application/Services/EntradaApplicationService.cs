using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercadorias.Application.Interfaces;
using Mercadorias.Domain.Entities;
using Mercadorias.Domain.Interfaces.Services;
using Mercadorias.Domain.Services;

namespace Mercadorias.Application.Services
{
    public class EntradaApplicationService : IEntradaApplicationService
    {
        private readonly IEntradaDomainService _entradaDomainService;

        public EntradaApplicationService(IEntradaDomainService entradaDomainService)
        {
            _entradaDomainService = entradaDomainService;
        }

        public void Create(Entrada obj)
        {
            try
            {
                _entradaDomainService.Create(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Entrada obj)
        {
            try
            {
                var e = _entradaDomainService.GetById(obj.IdEntrada);
                _entradaDomainService.Delete(e);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Entrada> GetAll()
        {
            try
            {
                var lista = new List<Entrada>();
                var all = _entradaDomainService.GetAll();
                foreach(var item in all)
                {
                    var x = new Entrada();
                    x.DataHoraEntrada = item.DataHoraEntrada;
                    x.IdEntrada = item.IdEntrada;
                    x.LocalEntrada = item.LocalEntrada;
                    x.Mercadoria = item.Mercadoria;
                    x.QuantidadeEntrada = item.QuantidadeEntrada;

                    lista.Add(x);
                }
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Entrada> GetByDataEntrada(DateTime dataMin, DateTime dataMax)
        {
            var lista = new List<Entrada>();
            try
            {
                var ListabyData = _entradaDomainService.GetByDataEntrada(dataMin, dataMax);

                foreach(var item in ListabyData)
                {
                    var x = new Entrada();
                    x.DataHoraEntrada = item.DataHoraEntrada;
                    x.IdEntrada = item.IdEntrada;
                    x.LocalEntrada = item.LocalEntrada;
                    x.Mercadoria = item.Mercadoria;
                    x.QuantidadeEntrada = item.QuantidadeEntrada;

                    lista.Add(x);
                }
                return lista;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public Entrada GetById(Guid id)
        {
            try
            {
               return _entradaDomainService.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Entrada obj)
        {
            try
            {
                var x = _entradaDomainService.GetById(obj.IdEntrada);
                x.DataHoraEntrada = obj.DataHoraEntrada;
                x.IdEntrada = obj.IdEntrada;
                x.LocalEntrada = obj.LocalEntrada;
                x.QuantidadeEntrada = obj.QuantidadeEntrada;

                _entradaDomainService.Update(x);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
