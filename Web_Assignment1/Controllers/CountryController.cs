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
        //public IActionResult CreateCountry()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult CreateCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                dbContext.Countries.Add(country);
                dbContext.SaveChanges();
                return RedirectToAction("Country");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            dbContext.Countries.Remove(dbContext.Countries.Find(id));
            dbContext.SaveChanges();
            return RedirectToAction("Country");
        }
    }
}
