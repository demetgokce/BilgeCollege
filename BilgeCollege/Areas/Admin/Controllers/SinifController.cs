using AutoMapper;
using Bilge.BLManager.Abstract;
using BilgeCollege.Areas.Admin.Models;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeCollege.Areas.Admin.Controllers
{
    [Area("Admin")]
 
    public class SinifController : Controller
    {
        private readonly ISiniflarManager manager;
        private readonly IMapper mapper;

        public SinifController(ISiniflarManager manager, IMapper mapper)
        {
            this.manager = manager;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {

            var siniflar = manager.GetAll(null);

            return View(siniflar);

        }
        [HttpGet]
        public IActionResult Create()
        {
            SinifModel entity = new SinifModel();
            

          
            

            return View(entity);
           

        }
        [HttpPost]
        public IActionResult Create(SinifModel dt)
        {

            if (ModelState.IsValid)
            {
                var sinif = mapper.Map<SinifModel, Siniflar>(dt);
                manager.Add(sinif);
                return RedirectToAction("Index", "Sinif");

            }
            return View();

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var entity = manager.Find(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Update(Siniflar sinif)
        {
            if (ModelState.IsValid)
            {
                manager.Update(sinif);
                return RedirectToAction("Index", "Sinif");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = manager.Find(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Delete(Siniflar sinif)
        {
            manager.Delete(sinif);
            return RedirectToAction("Index", "Sinif");

        }
    }
}
