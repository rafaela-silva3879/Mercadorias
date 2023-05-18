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

namespace Mercadorias.Presentation.Controllers
{
    public class MercadoriaController : Controller
    {
        private readonly IMercadoriaApplicationService _mercadoriApplicationService;

        public MercadoriaController(IMercadoriaApplicationService mercadoriApplicationService)
        {
            _mercadoriApplicationService = mercadoriApplicationService;
        }

        public IActionResult Create()
        {

            return View();

        }
        // GET: StateController
        public JsonResult GetMercadoria()
        {
            var listaModel = new List<MercadoriaCreateModel>();
            var listaEntidade = _mercadoriApplicationService.GetAll().OrderBy(x => x.Nome);

            foreach (var item in listaEntidade)
            {
                var m = new MercadoriaCreateModel();
                m.Nome = item.Nome;
                m.Id = item.Id;
                listaModel.Add(m);
            }

            return Json(listaModel);

        }


        [HttpPost]
        [Consumes("application/json")]
        public JsonResult AddMercadoria([FromBody] MercadoriaCreateModel mm)
        {
            var erro = new ErrorModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var m = new Mercadoria();
                    m.Id = Guid.NewGuid();
                    m.Descricao = mm.Descricao;
                    m.Fabricante = mm.Fabricante;
                    m.Nome = mm.Nome;
                    m.NumeroRegistro = mm.NumeroRegistro;
                    m.Tipo = mm.Tipo;


                    _mercadoriApplicationService.Create(m);
                    ModelState.Clear();

                }
                return Json("Mercadoria salva com sucesso.");
            }
            catch (Exception e)
            {
                //ViewBag.MensagemErro = e.Message;
                erro = new ErrorModel();
                erro.ErrorStr = e.Message;
                return Json(erro);

            }
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
