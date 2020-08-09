using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Repository;
using ViewModels.Viewmodels;

namespace Proyecto_Final.Controllers
{
    public class CiudadanoController : Controller
    {
        private readonly proyectoFinalContext _context;
       private readonly CiudadanoRepository _ciudadanoRepository;
        public CiudadanoController(CiudadanoRepository ciudadanoRepository, proyectoFinalContext context)
        {
            _ciudadanoRepository = ciudadanoRepository;
            _context = context;
        }
        // GET: Ciudadano
        public ActionResult IndexCiudadano()
        {
            var cuid = _ciudadanoRepository.GetCiudadanos();
            return View(cuid);
        }

        // GET: Ciudadano/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ciudadano/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ciudadano/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>  Create(IFormCollection collection,CiudadanoViewModel ciudadanoViewModel)
        {
            try
            {

                await _ciudadanoRepository.Addciudadano(ciudadanoViewModel);

                return RedirectToAction(nameof(IndexCiudadano));

              ;
            }
            catch
            {
                return View();
            }
        }

        // GET: Ciudadano/Edit/5
        public async Task<IActionResult> Editar(string cedula)
        {
            var ciudadano = await _context.Ciudadanos.FirstOrDefaultAsync(x => x.Cedula == cedula);
            return View(_ciudadanoRepository.EditView(ciudadano));
        }

        // POST: Ciudadano/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CiudadanoViewModel viewModel)
        {
            try
            {
                await _ciudadanoRepository.Editar(viewModel);

                return RedirectToAction("IndexCiudadano");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ciudadano/Delete/5
        public async Task<IActionResult> Delete(string cedula)
        {
            await _ciudadanoRepository.Deletecuid(cedula);
            return RedirectToAction(nameof(IndexCiudadano));


        }

       
    }
}