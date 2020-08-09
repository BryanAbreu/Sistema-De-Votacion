using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository;
using ViewModels.Viewmodels;

namespace Proyecto_Final.Controllers
{
    public class PuestoController : Controller
    {
        private readonly PuestoRepository _puestoRepository;

        public PuestoController(PuestoRepository puestoRepository)
        {
            _puestoRepository = puestoRepository;
        }
        // GET: Puesto
        public ActionResult IndexPuesto()
        {
            var puesto = _puestoRepository.GetPuestos();
            return View(puesto);
        }

        // GET: Puesto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Puesto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Puesto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection ,PuestoViewModel puestoViewModel)
        {
            try
            {
               
                await _puestoRepository.AddPuesto(puestoViewModel);

                return RedirectToAction(nameof(IndexPuesto));
            }
            catch
            {
                return View();
            }
        }

        // GET: Puesto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Puesto/Edit/5
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

        // GET: Puesto/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await _puestoRepository.Delete(id);
            return RedirectToAction(nameof(IndexPuesto));
        }

        // POST: Puesto/Delete/5
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