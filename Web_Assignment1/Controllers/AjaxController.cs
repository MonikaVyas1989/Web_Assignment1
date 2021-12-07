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
           
            People person = new People();
            //List<Person> personList = person.GetPeople();
            Person people = new Person(){personList=person.GetPeople() };
            //PeopleViewModel model = new PeopleViewModel { PeopleList = person.GetPeople() };

            

            foreach (Person per in person.GetPeople())
            {
                //if (people.personList.Count < 0 && people.personList == null)
                //{
                //    person.Person();
                //}
                //people.personList.Add(per);
                return PartialView("_PersonPartialView", model: per);
                //people.personList.Add(per);
            }
            return PartialView("_PersonPartialView", people);


       


        }
        [HttpPost]
        public ActionResult GetPersonByID(int id)
        {
            People person = new People();
            List<Person> peopleList = new List<Person>();
            Person personDetail = person.GetPeople(id);

            if (personDetail != null)
            {
                peopleList.Add(personDetail);
            }

            return PartialView("_PersonPartialView",peopleList);

        }
    }
}
