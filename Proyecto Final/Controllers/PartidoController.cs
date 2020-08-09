using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Database.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository;
using ViewModels.Viewmodels;

namespace Proyecto_Final.Controllers
{
    public class PartidoController : Controller
    {
        private readonly proyectoFinalContext _context;
        private readonly PartidoRepository _partidoRepository;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IMapper _mapper;
        public PartidoController(PartidoRepository partidoRepository, proyectoFinalContext context,IWebHostEnvironment hostEnvironment, IMapper mapper)
        {
            _partidoRepository = partidoRepository;
            _context = context;
            this.hostEnvironment = hostEnvironment;
            this._mapper = mapper;
        }
        // GET: Partido
        public ActionResult IndexPartido()
        {
            var partidos = _partidoRepository.Getpartidos();
            return View(partidos);
        }

        // GET: Partido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Partido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Partido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( PartidoViewModel partidoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string uniqueName = null;
                    if (partidoViewModel.fotoPartido != null)
                    {
                        var folderPath = Path.Combine(hostEnvironment.WebRootPath, "images/partido");
                        uniqueName = Guid.NewGuid().ToString() + "_" + partidoViewModel.fotoPartido.FileName;
                        var filePath = Path.Combine(folderPath, uniqueName);
                        if (filePath != null)
                        {
                            var stream = new FileStream(filePath, mode: FileMode.Create);
                            partidoViewModel.fotoPartido.CopyTo(stream);
                            stream.Flush();
                            stream.Close();
                        }
                    }
                    await _partidoRepository.AddPartido(partidoViewModel, uniqueName);
                }

                return RedirectToAction(nameof(IndexPartido));
            }
            catch
            {
                return View();
            }
        }

        // GET: Partido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Partido/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(IndexPartido));
            }
            catch
            {
                return View();
            }
        }

        // GET: Partido/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await _partidoRepository.Delete(id);
            return RedirectToAction(nameof(IndexPartido));
          
        }

        // POST: Partido/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(IndexPartido));
            }
            catch
            {
                return View();
            }
        }
    }
}