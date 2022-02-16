using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Data;
using Web_Assignment1.Models;
using Web_Assignment1.ViewModels;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public IActionResult GetPerson(int id)
        {
            ReactDetailViewModel reactDetailView = new ReactDetailViewModel();
            var person = dbContext.Persons.Include(p => p.City).Include(p => p.People)
                .Where(p => p.PersonId == id).SingleOrDefault();
            reactDetailView.personId = person.PersonId;
            reactDetailView.Name = person.Name;
            reactDetailView.Phone = person.Phone;
            reactDetailView.City = person.City.Name;
            var country = dbContext.Countries.Find(person.City.CountryId);
            reactDetailView.Country = country.Name;
            if (person.People != null)
            {
                foreach (var language in person.People)
                {
                    foreach (var name in dbContext.Languages)
                    {
                        if (language.LanguageId.Equals(name.Id))
                        { reactDetailView.Language.Add(name.Name); }
                    }
                }

            }

            return Json(reactDetailView);
        }

        [HttpPut]
        public IActionResult CreatePerson(PersonCreateViewModel person)
        {
            if (ModelState.IsValid)
            {
                var newPerson = new PersonModel
                {
                    Name = person.Name,
                    Phone = person.Phone,
                    CityId = person.CityId,
                };
                dbContext.Persons.Add(newPerson);
                dbContext.SaveChanges();
                foreach (var languageId in person.Languages)
                {
                    dbContext.PersonLanguages.Add(new PersonLanguage
                    {
                        PersonId = newPerson.PersonId,
                        LanguageId = int.Parse(languageId)
                    });

                }
                //dbContext.SaveChanges();
                dbContext.SaveChanges();

                return GetPerson(newPerson.PersonId);
                    
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeletePerson(int id)
        {
            try
            {
                var person = dbContext.Persons.First(person => person.PersonId.Equals(id));
                dbContext.Persons.Remove(person);
                dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        
       

        [HttpGet]
        public IActionResult GetFormData()
        {
            var countries = dbContext.Cities
               .Include(city => city.Country)
               .ToList()
               .GroupBy(city => city.Country.Name)
               .Select(x => new
               {
                   name = x.Key,
                   cities = x.Select(city => new
                   {
                       Id = city.Id,
                       Name = city.Name
                   })
               });

            return Json(new
            {
                countries = countries,
                languages = dbContext.Languages,
            });
        }
    }
}
