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
using Newtonsoft.Json;

namespace Mercadorias.Presentation.Controllers
{
    public class EntradaController : Controller
    {
        private readonly IEntradaApplicationService _Entradaapplicationservice;
        private readonly IMercadoriaApplicationService _Mercadoriaapplicationservice;


        public EntradaController(IEntradaApplicationService Entradaapplicationservice,            
            IMercadoriaApplicationService Mercadoriaapplicationservice)
        {

            _Entradaapplicationservice = Entradaapplicationservice;
            _Mercadoriaapplicationservice = Mercadoriaapplicationservice;
        }

        public IActionResult Create()
        {
            return View();

        }

  

        [HttpPost]
        //[Consumes("application/json")]
        //public JsonResult AddEntrada([FromBody] EntradaCreateModel em)
        public JsonResult AddEntrada(string json)
        {
            var erro = new ErrorModel();
            try
            {
                //if (ModelState.IsValid)
                //{
                dynamic dyn = JsonConvert.DeserializeObject(json);
                var e = new Entrada();
                    e.IdEntrada = Guid.NewGuid();
                    e.DataHoraEntrada = dyn.DataHoraEntrada;
                    e.LocalEntrada = dyn.LocalEntrada;
                    e.QuantidadeEntrada = dyn.QuantidadeEntrada;
                    e.IdMercadoria = dyn.IdMercadoria;
                    
                    _Entradaapplicationservice.Create(e);

                    ModelState.Clear();

                //}
                return Json("Entrada salva com sucesso.");


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
