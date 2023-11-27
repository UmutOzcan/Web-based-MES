using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NurusMES.Data.Models;
using NurusMES.Repositories;
using System.Net.Mail;
using X.PagedList;

namespace NurusMES.Controllers
{
    public class MakineController : Controller
    {
        Context cnt = new Context();

        MakineRepository makineRepository = new MakineRepository();
        public IActionResult Index(int page = 1)
        {
            
            return View(makineRepository.TList("Birim").ToPagedList(page, 5));
        }

        // sayfa açıldığında çalışan
        [HttpGet]
        public IActionResult AddMakine()
        {
            // Makinenin ait olduğu birimi seçerken dropdown kullancağız o yüzden burada atamasını yapmalıyız ve ViewBag ile taşırız
            List<SelectListItem> values1 = (from x in cnt.Birims.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.BirimAdi,
                                               Value = x.BirimID.ToString()
                                           }).ToList();

            ViewBag.v1 = values1;
            return View();
        }

        // butona basınca çalışan
        [HttpPost]
        public IActionResult AddMakine(Makine p) 
        {
            
            makineRepository.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveMakine(int id)
        {
            makineRepository.TRemove(new Makine { MakineID = id });
            return RedirectToAction("Index");
        }

        public IActionResult GetMakine(int id)
        {
            var x = makineRepository.TGet(id);

            // Makinenin ait olduğu birimi seçerken dropdown kullancağız o yüzden burada atamasını yapmalıyız ve ViewBag ile taşırız
            List<SelectListItem> values1 = (from y in cnt.Birims.ToList()
                                            select new SelectListItem
                                            {
                                                Text = y.BirimAdi,
                                                Value = y.BirimID.ToString()
                                            }).ToList();

            ViewBag.v1 = values1;

            Makine mk = new Makine()
            {
                MakineAdi = x.MakineAdi,
                MakineID = x.MakineID,
            };
            return View(mk);
        }

        [HttpPost]
        public IActionResult UpdateMakine(Makine mk)
        {
            var x = makineRepository.TGet(mk.MakineID);
            x.MakineAdi = mk.MakineAdi;
            x.BirimID = mk.BirimID;
            makineRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
