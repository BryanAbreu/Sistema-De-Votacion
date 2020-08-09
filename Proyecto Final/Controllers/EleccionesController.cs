using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository;

namespace Proyecto_Final.Controllers
{
    public class EleccionesController : Controller
    {
        private readonly EleccionesRepository _repository;
        public EleccionesController(EleccionesRepository repository)
        {
            _repository = repository;
        }
        // GET: Elecciones
        public async Task<IActionResult> Index()
        {

            return View(await _repository.Index());
        }

        // GET: Elecciones/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Elecciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Elecciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Elecciones/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Elecciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Elecciones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Elecciones/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}