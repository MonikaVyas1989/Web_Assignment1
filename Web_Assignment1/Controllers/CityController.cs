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
            CityViewModel model = new CityViewModel();
            PersonModel person = new PersonModel();
            bool id = person.CityId==model.Id;
            List<PersonModel> personList = dbContext.Persons.ToList(); 
            //List<CityViewModel> city = dbContext.Cities.Include(c => c.Name).Where(c => c.Id == model.CityId).ToList();
            return View(personList);
        }
    }
}
