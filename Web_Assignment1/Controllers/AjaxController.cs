using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Models;
using Web_Assignment1.ViewModels;

namespace Web_Assignment1.Controllers
{
    public class AjaxController : Controller
    {

        public IActionResult Ajax()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetPerson()
        {
            People People = new People();
            List<Person> personList = People.GetPeople();

            return PartialView("_PeoplePartialView", personList);

        }



        [HttpPost]
        public ActionResult GetPersonByID(int id)
        {
            People people = new People();
           
            Person personDetail = people.GetPeople(id);

           
            return PartialView("_PersonPartialView", personDetail);

        }

        [HttpPost]
        public ActionResult DeletePersonByID(int id)
        {
            People people = new People();
           
            Person personDetail = people.GetPeople(id);
            bool success = false;
            if (personDetail != null)
            {
               success= people.GetPeople().Remove(personDetail);
            }

            if (success)
            {
                return StatusCode(200);
            }
            return StatusCode(404);
           


        }
    }
}
