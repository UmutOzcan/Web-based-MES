using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NurusMES.Data.Models;
using NurusMES.Repositories;
using X.PagedList;

namespace NurusMES.Controllers
{
    public class PersonelController : Controller
    {
        Context cnt = new Context();
        PersonelRepository personelRepository = new PersonelRepository();
        public IActionResult Index(int page = 1)
        {
            return View(personelRepository.TList("Makine").ToPagedList(page,5));
        }

        // sayfa açıldığında çalışan
        [HttpGet]
        public IActionResult AddPersonel() 
        {

            // Personelin ait olduğu makineyi seçerken dropdown kullancağız o yüzden burada atamasını yapmalıyız ve ViewBag ile taşırız
            List<SelectListItem> values = (from x in cnt.Makines.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.MakineAdi,
                                               Value = x.MakineID.ToString()
                                           }).ToList();

            ViewBag.v1 = values;

            // Personelin ait olduğu makineyi seçerken dropdown kullancağız o yüzden burada atamasını yapmalıyız ve ViewBag ile taşırız
            List<SelectListItem> values5 = (from y in cnt.Birims.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.BirimAdi,
                                               Value = y.BirimID.ToString()
                                           }).ToList();

            ViewBag.v5 = values5;

            return View();
        }

        // butona basınca çalışan
        [HttpPost]
        public IActionResult AddPersonel(Personel p) 
        {

            personelRepository.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult RemovePersonel(int id)
        {
            personelRepository.TRemove(new Personel { PersonelID = id });
            return RedirectToAction("Index");
        }

        public IActionResult GetPersonel(int id)
        {
            var x = personelRepository.TGet(id);

            // Personelin ait olduğu makineyi seçerken dropdown kullancağız o yüzden burada atamasını yapmalıyız ve ViewBag ile taşırız
            List<SelectListItem> values = (from y in cnt.Makines.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.MakineAdi,
                                               Value = y.MakineID.ToString()
                                           }).ToList();

            ViewBag.v1 = values;

            // Personelin ait olduğu makineyi seçerken dropdown kullancağız o yüzden burada atamasını yapmalıyız ve ViewBag ile taşırız
            List<SelectListItem> values2 = (from y in cnt.Birims.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.BirimAdi,
                                               Value = y.BirimID.ToString()
                                           }).ToList();

            ViewBag.v2 = values2;

            Personel per = new Personel()
            {
                MakineID = x.MakineID,
                BirimID = x.BirimID,
                PersonelAdSoyad = x.PersonelAdSoyad,
                PersonelID = x.PersonelID,
                Admin = x.Admin,
            };
            return View(per);
        }

        [HttpPost]
        public IActionResult UpdatePersonel(Personel p)
        {
            var x = personelRepository.TGet(p.PersonelID);
            x.PersonelAdSoyad = p.PersonelAdSoyad;
            x.MakineID = p.MakineID;
            x.BirimID = p.BirimID;
            x.Admin = p.Admin;
            personelRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
