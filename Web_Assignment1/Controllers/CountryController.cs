using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Data;
using Web_Assignment1.ViewModels;

namespace Web_Assignment1.Controllers
{
    public class CountryController : Controller
    {
        private readonly PeopleDbContext dbContext;

        public CountryController(PeopleDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Country()
        {
            List<CityViewModel> cityList = dbContext.Cities.ToList();
            return View(cityList);
        }
    }
}
