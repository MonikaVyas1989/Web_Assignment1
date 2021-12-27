using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Data;
using Web_Assignment1.Models;
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
            CountryViewModel countryView = new CountryViewModel()
            {
                CountryList = dbContext.Countries.ToList(),
                Cities = dbContext.Cities.ToList()
                
            };
            //List<City> cityList = dbContext.Cities.ToList();
            return View(countryView);
        }
    }
}
