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
    public class MercadoriaApplicationService : IMercadoriaApplicationService
    {
        private readonly IMercadoriaDomainService _mercadoriaDomainService;

        public MercadoriaApplicationService(IMercadoriaDomainService mercadoriaDomainService)
        {
            _mercadoriaDomainService = mercadoriaDomainService;
        }

        public void Create(Mercadoria obj)
        {
            try
            {
                _mercadoriaDomainService.Create(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Mercadoria obj)
        {
            try
            {
                var m = _mercadoriaDomainService.GetById(obj.Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Mercadoria> GetAll()
        {
            try
            {
                var lista = new List<Mercadoria>();
                var all = _mercadoriaDomainService.GetAll();
                foreach (var item in all)
                {
                    var m = new Mercadoria();
                    m.Descricao = item.Descricao;
                    m.Fabricante = item.Fabricante;
                    m.Id = item.Id;
                    m.Nome = item.Nome;
                    m.NumeroRegistro = item.NumeroRegistro;
                    m.Tipo = item.Tipo;

                    lista.Add(m);
                }

                return lista;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public Mercadoria GetById(Guid id)
        {
            try
            {
                return _mercadoriaDomainService.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Mercadoria obj)
        {
            try
            {
                var m = _mercadoriaDomainService.GetById(obj.Id);
                m.Descricao = obj.Descricao;
                m.Fabricante = obj.Fabricante;
                m.Nome = obj.Nome;
                m.NumeroRegistro = obj.NumeroRegistro;
                m.Tipo = obj.Tipo;

                _mercadoriaDomainService.Update(m);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
