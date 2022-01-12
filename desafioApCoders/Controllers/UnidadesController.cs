using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;

namespace desafioApCoders.Controllers
{
    public class UnidadesController : Controller
    {
        private IServiceUnidades _database;
        public UnidadesController(IServiceUnidades database)
        {
            this._database = database;
        }

        [HttpGet]
        public ActionResult<List<Unidades>> Index()
        {
            return View("Index", _database.Get());
        }

        [HttpGet("unidades/registrar")]
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost("unidades/registrar")]
        public ActionResult Registrar(Unidades unidades)
        {
            if (ModelState.IsValid)
            {
                _database.Insert(unidades);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Registrar");
            }
        }
    }
}

