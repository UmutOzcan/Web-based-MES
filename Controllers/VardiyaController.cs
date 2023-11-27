using Microsoft.AspNetCore.Mvc;
using NurusMES.Data.Models;
using NurusMES.Repositories;
using X.PagedList;

namespace NurusMES.Controllers
{
    public class VardiyaController : Controller
    {
        Context cnt = new Context();
        VardiyaRepository vardiyaRepository = new VardiyaRepository();
        public IActionResult Index(int page = 1)
        {
            return View(vardiyaRepository.TList().ToPagedList(page, 5));
        }


    }
}
