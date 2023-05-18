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
    public class SaidaApplicationService : ISaidaApplicationService
    {
        private readonly ISaidaDomainService _SaidaDomainService;

        public SaidaApplicationService(ISaidaDomainService SaidaDomainService)
        {
            _SaidaDomainService = SaidaDomainService;
        }

        public void Create(Saida obj)
        {
            try
            {
                _SaidaDomainService.Create(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Saida obj)
        {
            try
            {
                var e = _SaidaDomainService.GetById(obj.IdSaida);
                _SaidaDomainService.Delete(e);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Saida> GetAll()
        {
            try
            {
                var lista = new List<Saida>();
                var all = _SaidaDomainService.GetAll();
                foreach (var item in all)
                {
                    var x = new Saida();
                    x.DataHoraSaida = item.DataHoraSaida;
                    x.IdSaida = item.IdSaida;
                    x.LocalSaida = item.LocalSaida;
                    x.Mercadoria = item.Mercadoria;
                    x.QuantidadeSaida = item.QuantidadeSaida;

                    lista.Add(x);
                }
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Saida> GetByDataSaida(DateTime dataMin, DateTime dataMax)
        {
            var lista = new List<Saida>();
            try
            {
                var ListabyData = _SaidaDomainService.GetByDataSaida(dataMin, dataMax);

                foreach (var item in ListabyData)
                {
                    var x = new Saida();
                    x.DataHoraSaida = item.DataHoraSaida;
                    x.IdSaida = item.IdSaida;
                    x.LocalSaida = item.LocalSaida;
                    x.Mercadoria = item.Mercadoria;
                    x.QuantidadeSaida = item.QuantidadeSaida;

                    lista.Add(x);
                }
                return lista;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public Saida GetById(Guid id)
        {
            try
            {
                return _SaidaDomainService.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Saida obj)
        {
            try
            {
                var x = _SaidaDomainService.GetById(obj.IdSaida);
                x.DataHoraSaida = obj.DataHoraSaida;
                x.IdSaida = obj.IdSaida;
                x.LocalSaida = obj.LocalSaida;
                x.QuantidadeSaida = obj.QuantidadeSaida;

                _SaidaDomainService.Update(x);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
