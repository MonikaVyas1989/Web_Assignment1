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
    [Authorize(Roles ="Admin")]
    public class CityController : Controller
    {
        private readonly PeopleDbContext dbContext;
        public CityController(PeopleDbContext context)
        {
            dbContext = context;
        }
        
       
        public IActionResult City()
        {
            CityViewModel cityView = new CityViewModel()
            {
                People = dbContext.Persons.ToList(),
                CityList = dbContext.Cities.ToList()
            };
            return View(cityView);
        }
        

        [HttpPost]
        public IActionResult CreateCity(City city)
        {
            if (ModelState.IsValid)
            {
                dbContext.Cities.Add(city);
                dbContext.SaveChanges();
                return RedirectToAction("City");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            City city = dbContext.Cities.Find(id);

            return View(city);
        }
        [HttpPost]
        public IActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(city).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("City");


            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            dbContext.Cities.Remove(dbContext.Cities.Find(id));
            dbContext.SaveChanges();
            return RedirectToAction("City");
        }

    }
}
