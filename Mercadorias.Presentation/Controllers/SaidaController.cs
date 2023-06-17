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
using Newtonsoft.Json;

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
        //[Consumes("application/json")]
        //public JsonResult AddSaida([FromBody] SaidaCreateModel sm)
        public JsonResult AddSaida(string json)
        {
            var erro = new ErrorModel();
            try
            {
                dynamic dyn = JsonConvert.DeserializeObject(json);

                var s = new Saida();

                s.IdSaida = Guid.NewGuid();
                s.DataHoraSaida = Convert.ToDateTime(dyn.DataHoraSaida);
                s.LocalSaida = dyn.LocalSaida;
                s.QuantidadeSaida = Convert.ToInt32(dyn.QuantidadeSaida);
                var Id = (Guid)dyn.IdMercadoria;
                s.IdMercadoria = Id;

                _saidaapplicationservice.Create(s);
                ModelState.Clear();
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



    }
}
