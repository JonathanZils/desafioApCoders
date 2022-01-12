﻿using Microsoft.AspNetCore.Http;
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
        private IServiceInquilino _database;
        public InquilinosController(IServiceInquilino database)
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
    }
}
