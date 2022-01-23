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
        private IService database;
        public UnidadesController(IService database)
        {
            this.database = database;
        }

        [HttpGet]
        public ActionResult<List<Unidade>> Index()
        {
            return View("Index", database.GetUnidades());
        }

        [HttpGet("unidades/registrar")]
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost("unidades/registrar")]
        public ActionResult Registrar(Unidade unidades)
        {
            if (ModelState.IsValid)
            {
                database.InsertUnidade(unidades);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Registrar");
            }
        }
    }
}

