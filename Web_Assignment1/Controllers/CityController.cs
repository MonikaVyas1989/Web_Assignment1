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
    public class CityController : Controller
    {
        private readonly PeopleDbContext dbContext;
        public CityController(PeopleDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            List<PersonModel> personList = dbContext.Persons.ToList(); 
            return View(personList);
        }
        public IActionResult Persons()
        {
            CityViewModel cityView = new CityViewModel()
            {

                People = dbContext.Persons.ToList(),
                CityList=dbContext.Cities.ToList()
            };
            return View(cityView);
        }
        public IActionResult City()
        {
            CityViewModel cityView = new CityViewModel()
            {

                CityList = dbContext.Cities.ToList()
            };
            return View(cityView);
        }
        public IActionResult CreateCity()
        {
            return View();
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

    }
}
