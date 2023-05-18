using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mercadorias.Presentation.Models;
using Mercadorias.Application.Interfaces;
using System.Text;
using Mercadorias.Domain.Entities;
using Mercadorias.Domain.Interfaces.Services;
using Mercadorias.Application.Services;

namespace Mercadorias.Presentation.Controllers
{
    public class SaidaController : Controller
    {
        private readonly ISaidaApplicationService _saidaapplicationservice;
        //private readonly
        private readonly IEntradaApplicationService _entradaapplicationService;

        public SaidaController(ISaidaApplicationService saidaapplicationservice, IEntradaApplicationService entradaapplicationService)
        {
            _saidaapplicationservice = saidaapplicationservice;
            _entradaapplicationService = entradaapplicationService;
        }

        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [Consumes("application/json")]
        public JsonResult AddSaida([FromBody] SaidaCreateModel sm)
        {
            var erro = new ErrorModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var s = new Saida();
                    s.IdSaida = Guid.NewGuid();
                    s.DataHoraSaida = sm.DataHoraSaida;
                    s.LocalSaida = sm.LocalSaida;
                    s.QuantidadeSaida = sm.QuantidadeSaida;
                    s.IdMercadoria = sm.IdMercadoria;

                    _saidaapplicationservice.Create(s);

                    ModelState.Clear();

                }
                return Json("Saída salva com sucesso.");


            }
            catch (Exception e)
            {
                //ViewBag.MensagemErro = e.Message;
                erro = new ErrorModel();
                erro.ErrorStr = e.Message;
                return Json(erro);

            }
            //return View("Create");
        }



        //método para abrir a página /Saida/Search
        public IActionResult Search()
        {

            return View();
        }
        [HttpPost]
        [Consumes("application/json")]
        public JsonResult SearchSaidaMercadoria([FromBody] SaidaSearchModel model)
        {
            ErrorModel erro;
            var lista = new List<SaidaSearchModel>();
            if (ModelState.IsValid)
            {
                try
                {

                    if (String.IsNullOrEmpty(model.DataMin) || String.IsNullOrEmpty(model.DataMax))
                        return Json("Por favor, entre os campos requeridos");


                    var datamin = DateTime.Parse(model.DataMin);
                    var datamax = DateTime.Parse(model.DataMax);


                    var result = _saidaapplicationservice.GetByDataSaida(datamin, datamax);

                    if (result != null && result.Count > 0)
                    {

                        foreach (var item in result)
                        {
                            var x = new SaidaSearchModel();

                            x.DataHora = item.DataHoraSaida.ToString("dd'/'MM'/'yyyy");
                            x.Quantidade = item.QuantidadeSaida;
                            x.Local = item.LocalSaida;
                            x.Id = item.IdSaida;

                            x.NomeMercadoria = item.Mercadoria.Nome;
                            x.NumeroRegistro = item.Mercadoria.NumeroRegistro;                            
                           
                            lista.Add(x);
                        }
                    }
                }
                catch (Exception e)
                {

                    // ViewBag.MensagemErro1 = e.Message.ToString();
                    erro = new ErrorModel();
                    erro.ErrorStr = e.Message;
                    return Json(erro);
                }

            }
            return Json(lista); //devolver a 'model' para a página

        }
    }
}
