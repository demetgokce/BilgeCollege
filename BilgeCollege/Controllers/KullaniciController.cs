using AutoMapper;
using Bilge.BLManager.Abstract;
using BilgeCollege.Models.Dto;
using Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BilgeCollege.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly IKullaniciManager manager;
        private readonly BilgeDbContext db;
        private readonly IMapper mapper;

        public KullaniciController(IKullaniciManager manager, BilgeDbContext db, IMapper mapper)
        {
            this.manager = manager;
            this.db = db;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {

            var kullanici = manager.GetAll(null);
            return View(kullanici);
        }

        public IActionResult Giris()
        {


            LoginDto loginDto = new LoginDto();

            return View(loginDto);
        }


        [HttpPost]
        public async Task<IActionResult> Giris(LoginDto dto)
        {
            var user = manager.GetAll(x => x.UserName == dto.UserName && x.Password == dto.Password).FirstOrDefault();
            if (user != null)
            {

                //Cookie icerisinde saklanacak bilgileri tutan Claim tipinden Liste olusturyoruz.
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,user.Role)
                };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //var authenticationProperty = new AuthenticationProperties
                //{

                //    IsPersistent = model.RememberMe
                //};


                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme
                                        , new ClaimsPrincipal(claimIdentity));


                return RedirectToAction("Index", "Home", new { area = "Admin" });


            }
            else
            {
                return View();
            }



        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            var registeruser = new RegisterDto();
            return View(registeruser);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterDto input)
        {
            if (ModelState.IsValid)
            {
                var user = mapper.Map<Kullanici>(input);
                user.Role = "User";


                manager.Add(user);
                return RedirectToAction("Index", "Home");

            }

            return View();
        }


    }
}
