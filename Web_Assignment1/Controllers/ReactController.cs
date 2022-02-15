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
        public IActionResult GetPeople()
        {
            
            return Json(dbContext.Persons);
        }

        [HttpPost]
        public IActionResult CreatePerson(PersonModel person)
        {
            if (ModelState.IsValid)
            {
                dbContext.Persons.Add(person);
                dbContext.SaveChanges();

                return Ok();
            }

            return BadRequest();
            
            
        }
    }
}
