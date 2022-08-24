using AutoMapper;
using Bilge.BLManager.Abstract;
using BilgeCollege.Areas.Admin.Models;
using BilgeCollege.Areas.Admin.Models.Dtos;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BilgeCollege.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class OgretmenController : Controller
    {
        private readonly IOgretmenManager manager;
        private readonly IDersManager dersManager;
        private readonly IMapper mapper;

        public OgretmenController(IOgretmenManager manager
        , IMapper mapper, IDersManager dersManager
           )
        {
            this.manager = manager;
            this.dersManager = dersManager;
            this.mapper = mapper;
        }



        public IActionResult Index()
        {
            List<Ogretmen> ogretmenler = new List<Ogretmen>();
            ogretmenler = manager.GetAll(null);

            if (ogretmenler.Count == 0)
                ogretmenler.Add(new Ogretmen());

            return View(ogretmenler);
        }
        [HttpGet]
        public IActionResult Create()
        {
            OgretmenCreateDto createDto = new OgretmenCreateDto();

            createDto.OgretmenDto = new OgretmenDto();
            //createDto.Sinif = 

            //new SelectList(fruits, "Id", "SinifAdi");
            

            return View(createDto);
        }
        [HttpPost]
        public IActionResult Create(OgretmenCreateDto dto)
        {

            if (ModelState.IsValid)
            {
                var ogretmen = mapper.Map<OgretmenCreateDto, Ogretmen>(dto);
                manager.Add(ogretmen);
                return RedirectToAction("Index", "Ogretmen");
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
        public IActionResult Update(Ogretmen ogretmen)
        {
            if (ModelState.IsValid)
            {
                manager.Update(ogretmen);
                return RedirectToAction("Index", "Ogretmen");
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
        public IActionResult Delete(Ogretmen ogretmen)
        {
            manager.Delete(ogretmen);
            return RedirectToAction("Index", "Ogretmen");

        }


    }
}
