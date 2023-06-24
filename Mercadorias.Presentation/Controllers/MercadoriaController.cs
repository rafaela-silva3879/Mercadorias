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
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Mercadorias.Reports.Pdf;
using Mercadorias.Application.Responses;
using System.IO;
using iText.Kernel.Geom;
using Microsoft.AspNetCore.StaticFiles;
using System.Net.Mime;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using iText.Kernel.XMP.Impl.XPath;

namespace Mercadorias.Presentation.Controllers
{
    public class MercadoriaController : Controller
    {
        private readonly IMercadoriaApplicationService _mercadoriaApplicationService;
        private readonly IEntradaApplicationService _entradaApplicationService;
        private readonly ISaidaApplicationService _saidaApplicationService;

        // Required to obtain physical path
        private readonly IWebHostEnvironment _hostingEnvironment;

        public MercadoriaController(IMercadoriaApplicationService mercadoriaApplicationService, IEntradaApplicationService entradaApplicationService, ISaidaApplicationService saidaApplicationService, IWebHostEnvironment hostingEnvironment)
        {
            _mercadoriaApplicationService = mercadoriaApplicationService;
            _entradaApplicationService = entradaApplicationService;
            _saidaApplicationService = saidaApplicationService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Create()
        {

            return View();

        }
        // GET: StateController
        public JsonResult GetMercadoria()
        {
            var listaModel = new List<MercadoriaCreateModel>();
            var listaEntidade = _mercadoriaApplicationService.GetAll().OrderBy(x => x.Nome);

            foreach (var item in listaEntidade)
            {
                var m = new MercadoriaCreateModel();
                m.Nome = item.Nome;
                m.Id = item.Id;
                listaModel.Add(m);
            }

            return Json(listaModel);

        }

        // GET: 
        public JsonResult GetMes()
        {
            var listaModel = new List<MesModel>();
            listaModel.Add(new MesModel { Id = 1, Mes = "Janeiro" });
            listaModel.Add(new MesModel { Id = 2, Mes = "Fevereiro" });
            listaModel.Add(new MesModel { Id = 3, Mes = "Março" });
            listaModel.Add(new MesModel { Id = 4, Mes = "Abril" });
            listaModel.Add(new MesModel { Id = 5, Mes = "Maio" });
            listaModel.Add(new MesModel { Id = 6, Mes = "Junho" });
            listaModel.Add(new MesModel { Id = 7, Mes = "Julho" });
            listaModel.Add(new MesModel { Id = 8, Mes = "Agosto" });
            listaModel.Add(new MesModel { Id = 9, Mes = "Setembro" });
            listaModel.Add(new MesModel { Id = 10, Mes = "Outubro" });
            listaModel.Add(new MesModel { Id = 11, Mes = "Novembro" });
            listaModel.Add(new MesModel { Id = 12, Mes = "Dezembro" });
            return Json(listaModel.OrderBy(x => x.Id));

        }

        // GET: 
        public JsonResult GetAno()
        {
            var listaModel = new List<AnoModel>();

            for (int i = 2000; i < 2060; i++)
            {
                listaModel.Add(new AnoModel { Ano = i });
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


                    _mercadoriaApplicationService.Create(m);
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



        public List<RelatorioMensalModel> GetDadosRelatorio(int mes, int ano)
        {
            try
            {
               
                var listarel = new List<RelatorioMensalModel>();

                var entradasMes = _entradaApplicationService.GetAll().Where(x => x.DataHoraEntrada.Month == mes && x.DataHoraEntrada.Year == ano);
                var saidasMes = _saidaApplicationService.GetAll().Where(x => x.DataHoraSaida.Month == mes && x.DataHoraSaida.Year == ano);

                var listaIdMercadoriasAux = new List<Guid>();
                listaIdMercadoriasAux.AddRange(entradasMes.Select(x => x.IdMercadoria).Distinct());
                listaIdMercadoriasAux.AddRange(saidasMes.Select(x => x.IdMercadoria).Distinct());





                if (listaIdMercadoriasAux ==null || listaIdMercadoriasAux.Count == 0)
                {
                    throw new ArgumentException("Não há dados no período informado.");
                }

                var listaIdMercadorias = new List<Guid>();

                listaIdMercadorias.AddRange(listaIdMercadoriasAux.Distinct());


                RelatorioMensalModel rel;
                foreach (var id in listaIdMercadorias)
                {
                    rel = new RelatorioMensalModel();

                    rel.IdMercadoria = Convert.ToString(id);
                    var mercadoria = _mercadoriaApplicationService.GetById(id);

                    rel.Mes = mes;
                    rel.Ano = ano;
                    rel.NomeMercadoria = mercadoria.Nome;
                    rel.NumeroRegistro = mercadoria.NumeroRegistro;
                    rel.QuantidadeEntrada = entradasMes.Where(x => x.IdMercadoria == id).Sum(x => x.QuantidadeEntrada);
                    rel.QuantidadeSaida = saidasMes.Where(x => x.IdMercadoria == id).Sum(x => x.QuantidadeSaida);
                    rel.QuantidadeRestante = _entradaApplicationService.GetAll().Where(x => x.DataHoraEntrada.Month <= mes && x.DataHoraEntrada.Year <= ano && x.IdMercadoria == id).Sum(x => x.QuantidadeEntrada) - _saidaApplicationService.GetAll().Where(x => x.DataHoraSaida.Month <= mes && x.DataHoraSaida.Year <= ano && x.IdMercadoria == id).Sum(x => x.QuantidadeSaida);

                    listarel.Add(rel);
                }
                return listarel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult RelatorioMensal()
        {
            return View();
        }

        [HttpPost]
        [Consumes("application/json")]
        public JsonResult RelatorioMensal([FromBody] MesAnoModel model)
        {
            ErrorModel erro;
            var listarel = new List<RelatorioMensalModel>();
            if (ModelState.IsValid)
            {
                try
                {
                    var mesAux = Convert.ToInt32(model.Mes);
                    var anoAux = Convert.ToInt32(model.Ano);


                    listarel = GetDadosRelatorio(mesAux, anoAux);

                    //x.DataHora = item.DataHoraSaida.ToString("dd'/'MM'/'yyyy");

                }
                catch (ArgumentException ex)
                {
                    // Tratar a exceção ArgumentException aqui
                    erro = new ErrorModel();
                    erro.ErrorStr = ex.Message;
                    return Json(erro);
                }
                catch (Exception e)
                {

                    // ViewBag.MensagemErro1 = e.Message.ToString();
                    erro = new ErrorModel();
                    erro.ErrorStr = e.Message;
                    return Json(erro);
                }
            }
            return Json(listarel); //devolver a 'model' para a página
        }


        [HttpPost]
        public IActionResult ExcluirArquivo(string filePath)
        {

            //excluir o arquivo temporário
            System.IO.File.Delete(filePath);
            return Ok();
        }


        [HttpPost]
        public IActionResult RelatorioPdf([FromBody] MesAnoModel model)
        {
            try
            {
                var erro = new ErrorModel();

                if (String.IsNullOrEmpty(model.Mes.ToString()) || String.IsNullOrEmpty(model.Ano.ToString()))
                {
                    erro.ErrorStr = "Por favor, escolha o mês e o ano.";
                    return Json(erro);
                }

                var mercadorias = GetDadosRelatorio(model.Mes, model.Ano);
                //gerando um relatorio de tarefas em arquivo PDF
                var mercadoriasReportPdf = new MercadoriasReportPdf();
                byte[] pdfBytes = mercadoriasReportPdf.GerarRelatorio(mercadorias);

                // Define o nome do arquivo PDF para download
                string fileName = Guid.NewGuid().ToString() + ".pdf";

                string filePath = System.IO.Path.Combine("wwwroot", "PDFs", fileName);
                System.IO.File.WriteAllBytes(filePath, pdfBytes);

                string downloadLink = Url.Content("~/PDFs/" + fileName);

                return Ok(new { downloadLink });

            }
            catch (ArgumentException ex)
            {
                // Tratar a exceção ArgumentException aqui
                var erro = new ErrorModel();
                erro.ErrorStr = ex.Message;
                return Json(erro);
            }
            catch (Exception e)
            {

                // ViewBag.MensagemErro1 = e.Message.ToString();
               var erro = new ErrorModel();
                erro.ErrorStr = e.Message;
                return Json(erro);
            }

        }
    }
}

