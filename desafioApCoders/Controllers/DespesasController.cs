using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using desafioApCoders.Models;

namespace desafioApCoders.Controllers
{
    public class DespesasController : Controller
    {
        private IService database;

        public DespesasController(IService database)
        {
            this.database = database;
        }

        [HttpGet]
        public ActionResult<List<Despesa>> Index()
        {
            return View("Index", database.GetDespesas());
        }

        [HttpGet("despesas/registrar")]
        public ActionResult Registrar()
        {
            var viewmodel = new DespesaViewModel();
            var unidades = database.GetUnidades();

            viewmodel.Unidades = new SelectList(unidades, "UnidadeId", "Condominio");

            return View(viewmodel);
        }

        [HttpPost("despesas/registrar")]
        public ActionResult Registrar(AdicionarDespesa adicionarDespesa)
        {
            if (ModelState.IsValid)
            {
                database.InsertDespesa(adicionarDespesa);
                return RedirectToAction("Index");
            }
            else
            {
                return Registrar();
            }
        }

        [HttpGet("/despesas/editar/{despesaId}")]
        public ActionResult Editar(int despesaId)
        {
            var despesas = database.FindData(despesaId);
            return View(despesas);
        }

        [HttpPost("/despesas/editar/{despesaid}")]
        public ActionResult Editar(EditarDespesa despesas, int despesaId)
        {
            if (ModelState.IsValid)
            {
                database.Update(despesas, despesaId);
                return RedirectToAction("Index");
            }
            else
            {
                return Editar(despesaId);
            }
        }

        [HttpGet("/despesas/faturasvencidas")]
        public ActionResult FaturasVencidas()
        {
            return View("faturasvencidas", database.GetFaturaVencida());
        }

        [HttpGet("/despesas/despesas-por-unidade")]
        public ActionResult DespesasPorUnidade()
        {
            var unidades = database.GetUnidades();

            return View("DespesasPorUnidade", new DespesasPorUnidadeViewModel
            {
                Unidades = new SelectList(unidades, "UnidadeId", "Condominio")
            });
        }

        [HttpGet("/despesas/despesas-por-unidade/{unidadeId}")]
        public ActionResult DespesasPorUnidade(int unidadeId)
        {
            var unidades = database.GetUnidades();
            var despesas = database.GetDespesasPorUnidade(unidadeId);

            return View("DespesasPorUnidade", new DespesasPorUnidadeViewModel
            {
                Unidades = new SelectList(unidades, "UnidadeId", "Condominio"),
                Despesas = despesas
            });
        }
    }
}
