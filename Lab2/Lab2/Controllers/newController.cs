using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2
{
    public class newController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
