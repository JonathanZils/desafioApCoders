using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;


namespace desafioApCoders.Controllers
{
    public class InquilinosController : Controller
    {
        private IService _database;
        public InquilinosController(IService database)
        {
            this._database = database;
        }

        [HttpGet]
        public ActionResult<List<Inquilinos>> Index()
        {
            return View("Index", _database.Get());
        }

        [HttpGet("inquilinos/registrar")]
        public ActionResult Registrar() 
        { 
            return View();
        }

        [HttpPost("inquilinos/registrar")]
        public ActionResult Registrar(Inquilinos inquilinos)
        {
            if (ModelState.IsValid)
            {
                _database.Insert(inquilinos);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Registrar");
            }
        }

        // GET: InquilinosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InquilinosController/Edit/5
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

        // GET: InquilinosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InquilinosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
