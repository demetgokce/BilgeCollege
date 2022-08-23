using AutoMapper;
using Bilge.BLManager.Abstract;
using BilgeCollege.Areas.Admin.Models;
using BilgeCollege.Areas.Admin.Models.Dtos;
using BilgeCollege.Model.Static;
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
    [Authorize]

    public class OgrenciController : Controller
    {
        private readonly IOgrenciManager manager;
        private readonly IMapper mapper;
        private readonly ISiniflarManager siniflarManager;
        public OgrenciController(IOgrenciManager manager, IMapper mapper, ISiniflarManager siniflarManager)
        {
            this.siniflarManager = siniflarManager;
            this.manager = manager;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            ogrenciler = manager.GetAll(null);

            if (ogrenciler.Count == 0)
                ogrenciler.Add(new Ogrenci());

            return View(ogrenciler);
        }
        [HttpGet]
        public IActionResult Create()
        {
            OgrenciCreateDto createDto = new OgrenciCreateDto();

            createDto.OgrenciDto = new OgrenciDto();
            //createDto.Sinif = 

            //new SelectList(fruits, "Id", "SinifAdi");
            var sinif = siniflarManager.GetAll(null);
            var sinifSelect = mapper.Map<List<Siniflar>, List<SinifModel>>(sinif);
            createDto.Sinif = new SelectList(sinifSelect, "Id", "SinifAdi");

            return View(createDto);
        }
        [HttpPost]
        public IActionResult Create(OgrenciCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                // Kayit sirasinda amele yontemi 

                //Ogrenci og = new Ogrenci();
                //og.Adi = dto.Adi;
                //og.Soyadi = dto.Soyadi;
                //og.TcNo = dto.TcNo;
                //og.Gsm = dto.Gsm;
                //og.Cinsiyet = dto.Cinsiyet;

                var ogrenci = mapper.Map<OgrenciDto, Ogrenci>(dto.OgrenciDto);
                
                try
                {
                    manager.CheckForTckimlik(ogrenci.TcNo);
                    manager.CheckForGsm(ogrenci.Gsm);
                    manager.Add(ogrenci);

                    return RedirectToAction("Index", "Ogrenci", new { Areas = "Admin" });
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", ex.Message);
                }

            }

            return View(dto);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var entity = manager.Find(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Update(Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                manager.Update(ogrenci);
                return RedirectToAction("Index", "Ogrenci");
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
        public IActionResult Delete(Ogrenci ogrenci)
        {
            manager.Delete(ogrenci);
            return RedirectToAction("Index", "Ogrenci");

        }
    }
}
