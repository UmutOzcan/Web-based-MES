using Microsoft.AspNetCore.Mvc;
using NurusMES.Data.Models;
using NurusMES.Repositories;
using System.Diagnostics;
using System.IO.Ports;
using System.Reflection;
using System.Security.Cryptography.Xml;
using X.PagedList;

namespace NurusMES.Controllers
{
    public class ArduinoController : Controller
    {
        SerialPort port = new SerialPort("COM3");
        ArduinoRepository arduinoRepository = new ArduinoRepository();

        public IActionResult Index(int page = 1)
        {
           
            port.Open();
            string text = port.ReadLine();
            List<string> liste = text.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            ViewBag.liste = liste;
            port.Close();
            return View(arduinoRepository.TList().ToPagedList(page, 5));
        }

       


    }
}
