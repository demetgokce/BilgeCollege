using Bilge.BLManager.Abstract;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BilgeCollege.Model.Static;
using BilgeCollege.Areas.Admin.Models.Dtos;
using AutoMapper;

namespace BilgeCollege.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    public class DersController : Controller
    {


        //Sadece Constructer icerisinde set edilebilir


        private readonly IDersManager manager;
        private readonly IMapper mapper;

        public DersController(IDersManager manager, IMapper mapper)
        {
            ;
            this.manager = manager;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var ders= manager.GetAll(null);

            return View(ders);
        }
        [HttpGet]
        public IActionResult Create()
        {
            DersDto entity = new DersDto();


            return View(entity);
        }
        [HttpPost]
        public IActionResult Create(DersDto bz)
        {
            if (ModelState.IsValid)
            {
                var ders = mapper.Map<DersDto, Ders>(bz);
                manager.Add(ders);
                return RedirectToAction("Index", "Ders");

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
        public IActionResult Update(Ders ders)
        {
            if (ModelState.IsValid)
            {
                manager.Update(ders);
                return RedirectToAction("Index", "Ders");
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
        public IActionResult Delete(Ders ders)
        {
            manager.Delete(ders);
            return RedirectToAction("Index", "Ders");

        }

    }
}
