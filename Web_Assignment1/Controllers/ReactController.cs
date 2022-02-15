using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Data;

namespace Web_Assignment1.Controllers
{
    public class ReactController : Controller
    {

        private readonly PeopleDbContext dbContext;

        public ReactController(PeopleDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public JsonResult GetPeople()
        {   
            return Json(dbContext.Persons);

        }
    }
}
