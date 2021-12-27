using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Data;

namespace Web_Assignment1.Controllers
{
    public class LanguageController : Controller
    {
        private readonly PeopleDbContext dbContext;

        public LanguageController(PeopleDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Language()
        {
            
            return View();
        }
    }
}
