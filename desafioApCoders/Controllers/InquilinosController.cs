using Microsoft.AspNetCore.Mvc;
using Core;
using System.Collections.Generic;

namespace desafioApCoders.Controllers
{
    public class InquilinosController : Controller
    {
        private readonly IService database;

        public InquilinosController(IService database)
        {
            this.database = database;
        }

        [HttpGet]
        public ActionResult<List<Inquilino>> Index()
        {
            return View("Index", database.GetInquilinos());
        }

        [HttpGet("inquilinos/registrar")]
        public ActionResult Registrar() 
        { 
            return View();
        }

        [HttpPost("inquilinos/registrar")]
        public ActionResult Registrar(Inquilino inquilinos)
        {
            if (ModelState.IsValid)
            {
                database.InsertInquilino(inquilinos);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Registrar");
            }
        }       
    }
}
