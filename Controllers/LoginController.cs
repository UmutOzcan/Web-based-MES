using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NurusMES.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace NurusMES.Controllers
{
    
    public class LoginController : Controller
    {
        Context cnt = new Context();

        //AllowAnonymous yapınca authorize işlemi dışında tutulur ve authorize olunmamışsa bu sayfaya döndürür
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //Aşağıdaki kod bloğu Loginde girilen bilgiler doğru ise talep oluşturup kullanıcı kimliği ile giriş yapmasını sağlar
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index (Personel p)
        {
            var bilgiler = cnt.Personels.FirstOrDefault(x => x.PersonelAdSoyad == p.PersonelAdSoyad && x.Sifre == p.Sifre);
            if (bilgiler != null) 
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.PersonelAdSoyad)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);

                if (bilgiler.Admin == 'A')
                {
                    return RedirectToAction("Index", "Personel");
                }

                return View("PersonelGiris");


            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
