using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NurusMES.Data.Models;
using NurusMES.Repositories;
using System.Security.Cryptography.Xml;
using X.PagedList;

namespace NurusMES.Controllers
{
    public class DuruslarController : Controller
    {
        Context cnt = new Context();

        DuruslarRepository duruslarRepository = new DuruslarRepository();
        public IActionResult Index(int page = 1)
        {

            return View(duruslarRepository.TList("Personel").ToPagedList(page, 5));
        }

        [HttpPost]
        public IActionResult AddDurus(Duruslar d)
        {
            duruslarRepository.TAdd(d);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddDurus()
        {

            // BIRIM DROPDOWN
            
            List<SelectListItem> values = (from x in cnt.Birims.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.BirimAdi,
                                                    Value = x.BirimID.ToString()
                                                }).ToList();

            ViewBag.birimValues = values;

            // MAKİNE DROPDOWN

            List<SelectListItem> values2 = (from x in cnt.Makines.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.MakineAdi,
                                                    Value = x.MakineID.ToString()
                                                }).ToList();

            ViewBag.makineValues = values2;

            // DURUS DROPDOWN

            List<SelectListItem> values3 = (from x in cnt.Duruslar.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DurusTuru,
                                                     Value = x.DurusID.ToString()
                                                 }).ToList();

            ViewBag.AnaDurusValues = values3;

            // DURUS DROPDOWN

            List<SelectListItem> values4 = (from x in cnt.Personels.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.PersonelAdSoyad,
                                                Value = x.PersonelID.ToString()
                                            }).ToList();

            ViewBag.PersonelValues = values4;

            return View();

        }


        //// Duruş İsimleri

        //// Tanımlı Süre Ekleme inputu

        //}


        // Update func


        // Remove func


    }
}
