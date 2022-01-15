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
    

    // GET: DespesasController/Edit/5
    public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DespesasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
    }
}
