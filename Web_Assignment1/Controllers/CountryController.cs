using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Data;
using Web_Assignment1.Models;
using Web_Assignment1.ViewModels;

namespace Web_Assignment1.Controllers
{
    [Authorize(Roles = "Admin")]
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Country country = dbContext.Countries.Find(id);

            return View(country);
        }
        [HttpPost]
        public IActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(country).State = EntityState.Modified;
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
