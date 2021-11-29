using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Models;
using Web_Assignment1.ViewModels;

namespace Web_Assignment1.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult PeopleIndex()
        {

            Person person = new Person();
            PeopleViewModel people = new PeopleViewModel(); //{PeopleList=person.GetPeople() };
            if (people.PeopleList.Count == 0 || people.PeopleList == null)
            {
                person.People();
            }
            people.PeopleList = person.GetPeople();
            return View(people);
        }

        [HttpPost]
        public IActionResult PeopleCreation(CreatePersonViewModel createPerson)
        {
            Person person = new Person();
            PeopleViewModel peopleView = new PeopleViewModel();

            if (ModelState.IsValid)
            {

                person.CreatePerson(createPerson.Name, createPerson.Phone,
                       createPerson.City);
                foreach (Person per in person.GetPeople())
                {

                    peopleView.PeopleList.Add(per);
                }

                ViewBag.Message = "You have added one new person Successfully";
                return View("PeopleIndex", peopleView);
            }
            ViewBag.Message = "You are failed to add new Person" + ModelState.Values;


            return View("PeopleIndex", peopleView);

        }

        [HttpPost]
        public IActionResult PeopleSearch(PeopleViewModel peopleView)
        {
            Person person = new Person();
            peopleView.PeopleList.Clear();


            foreach (Person per in person.GetPeople())
            {

                if (per.Name.ToLower() == peopleView.Namestring.ToLower())
                {
                    peopleView.PeopleList.Add(per);
                }
                //        //        //This is searching with match city value
                //        //        //if(per.City.ToLower() == peopleView.Citystring.ToLower())
                //        //        //{
                //        //        //    peopleView.PeopleList.Add(per);
                //        //        //}

                //        //    }

            }
            return View("PeopleIndex", peopleView);
        }
        public IActionResult DeletePerson(string nm)
        {
            Person person = new Person();
            Person p = person.GetPeople(nm);
            //person.RemovePerson(p);

            PeopleViewModel people1 = new PeopleViewModel();
            people1.RemovePerson(p);
            people1.PeopleList = person.GetPeople();
            //person = people1.PeopleList.Find(c => c.Name == name);
            //people1.PeopleList.Remove(person);
            //person.PeopleList1.Remove(person);
            //foreach (var i in people1.PeopleList)
            //{
            //    if (i == person)
            //    {
            //        people1.PeopleList.Remove(i);
            //    }
            //}
            //if (people1.PeopleList.Contains(person))
            //{
            //    people1.PeopleList.Remove(person);
            //}

            return View("PeopleIndex",people1);

        }
    }
}
