using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace WebAppSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "This Sample is an application requirement for PLAYnGo.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "You can contact me via the following:";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
