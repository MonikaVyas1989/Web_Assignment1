using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Models;

namespace Web_Assignment1.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            //Redirection of View to FeverCheck View...
            return RedirectToAction("FeverCheck");
        }

        
        public IActionResult FeverCheck()
        {
            ViewBag.Message = Utility.CheckFever();
            return View();
        }
        [HttpPost]
        public IActionResult FeverCheck(float num)
        {
            Utility.Number = num;
            ViewBag.Message = Utility.CheckFever(num);
            return View();
        }
    }
}
