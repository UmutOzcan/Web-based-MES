using Microsoft.AspNetCore.Mvc;
using NurusMES.Data.Models;
using NurusMES.Repositories;

namespace NurusMES.Controllers
{
    public class IsEmriController : Controller
    {

        Context cnt = new Context();

        IsEmriRepository IsEmriRepository = new IsEmriRepository();

        public IActionResult Index()
        {
            return View();
        }

    }
}
