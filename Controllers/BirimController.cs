using Microsoft.AspNetCore.Mvc;
using NurusMES.Data.Models;
using NurusMES.Repositories;
using X.PagedList;

namespace NurusMES.Controllers
{
    public class BirimController : Controller
    {
        BirimRepository birimRepository = new BirimRepository();

        public IActionResult Index(int page=1)
        {
            return View(birimRepository.TList().ToPagedList(page,5));
        }

        // sayfa açıldığında çalışan
        [HttpGet]
        public IActionResult AddBirim() 
        {
            return View();
        }

        // butona basınca çalışan
        [HttpPost]
        public IActionResult AddBirim(Birim p) 
        {
            birimRepository.TAdd(p);
            return RedirectToAction("Index"); 
        }

        public IActionResult RemoveBirim(int id) 
        {
            birimRepository.TRemove(new Birim { BirimID = id });
            return RedirectToAction("Index");
        }

        public IActionResult GetBirim(int id) 
        {
            var x = birimRepository.TGet(id);
            Birim br = new Birim()
            {
                BirimAdi = x.BirimAdi,
                BirimID = x.BirimID,
            };
            return View(br);
        }

        [HttpPost]
        public IActionResult UpdateBirim(Birim br) 
        {
            var x = birimRepository.TGet(br.BirimID);
            x.BirimAdi = br.BirimAdi;
            birimRepository.TUpdate(x);
            return RedirectToAction("Index");
        }

    }
}
