using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;

namespace desafioApCoders.Controllers
{
    public class DespesasController : Controller
    {
        private IServiceDespesas _database;
        public DespesasController(IServiceDespesas database)
        {
            this._database = database;
        }

        [HttpGet]
        public ActionResult<List<Despesas>> Index()
        {
            return View("Index", _database.Get());
        }

        [HttpGet("despesas/registrar")]
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost("despesas/registrar")]
        public ActionResult Registrar(Despesas despesas)
        {
            if (ModelState.IsValid)
            {
                _database.Insert(despesas);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Registrar");
            }
        }
   
        [HttpGet("/despesas/editar/{despesas_id}")]
        public ActionResult Editar(int despesas_id)
        {
            var despesas = _database.FindData(despesas_id);
            return View(despesas);
        }

        
        [HttpPost("/despesas/editar/{despesas_id}")]    
        public ActionResult Editar(Despesas despesas,int despesas_id)
        {
            if (ModelState.IsValid)
            {
                _database.Update(despesas,despesas_id);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Editar");
            }
        }
        
    }
}
