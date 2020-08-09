using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Repository.Repository;
using ViewModels.Viewmodels;

namespace Proyecto_Final.Controllers
{

    public class CandidatoController : Controller
        
    {
        private readonly proyectoFinalContext _context;
        private readonly CandidatoRepository _candidatoRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public CandidatoController(CandidatoRepository candidatoRepository,proyectoFinalContext context,
            IWebHostEnvironment hostingEnvironment)
        {
            _candidatoRepository = candidatoRepository;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: Candidato
        public ActionResult Index()
        {
       
            var vm = _candidatoRepository.GetCadidatos();


            return View(vm);
        }

        // GET: Candidato/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Candidato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidato/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( CadidatoViewModel cadidatoViewModel)
        {
            try
            {
                string uniqueName = null;
                if (cadidatoViewModel.fotoCandidato != null)
                {
                    var folderPath = Path.Combine(_hostingEnvironment.WebRootPath, "images/candidatos");
                    uniqueName = Guid.NewGuid().ToString() + "_" + cadidatoViewModel.fotoCandidato.FileName;
                    var filePath = Path.Combine(folderPath, uniqueName);

                    if (filePath != null)
                    {
                        var stream = new FileStream(filePath, mode: FileMode.Create);
                        cadidatoViewModel.fotoCandidato.CopyTo(stream);
                        stream.Flush();
                        stream.Close();
                    }
                }
                await _candidatoRepository.Addcandidato(cadidatoViewModel,uniqueName);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Candidato/Edit/5
        public ActionResult Editar(int id)
        {
            return View(_candidatoRepository.Editar(id));
        }

        // POST: Candidato/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(CadidatoViewModel viewModel)
        {
            try
            {
                
                    string uniqueName = null;
                    if (viewModel.fotoCandidato != null)
                    {
                        var folderPath = Path.Combine(_hostingEnvironment.WebRootPath, "images/candidatos");
                        uniqueName = Guid.NewGuid().ToString() + "_" + viewModel.fotoCandidato.FileName;
                        var filePath = Path.Combine(folderPath, uniqueName);

                        if (filePath != null)
                        {
                            var stream = new FileStream(filePath, mode: FileMode.Create);
                            viewModel.fotoCandidato.CopyTo(stream);
                            stream.Flush();
                            stream.Close();
                        }
                        
                    
                    
                }
                if(await _candidatoRepository.Edit(viewModel, uniqueName))
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Candidato/Delete/5
        public async Task<ActionResult> Delete(string foto,int id)
        {
            if(await _candidatoRepository.Delete(id) != null)
            {
                var folderPath = Path.Combine(_hostingEnvironment.WebRootPath, "images/partido");
                var filePathDelete = Path.Combine(folderPath, foto);

                var fileInfo = new FileInfo(filePathDelete);
                fileInfo.Delete();
            }

            return RedirectToAction(nameof(Index));
            
        }

        // POST: Candidato/Delete/5
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