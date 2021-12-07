﻿using Microsoft.AspNetCore.Mvc;
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
            People person = new People();
            PeopleViewModel people = new PeopleViewModel();
            people.PeopleList = person.GetPeople();
            if (people.PeopleList.Count == 0 || people.PeopleList == null)
            {
                person.Person();
            }

            return View(people);
            

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PeopleCreation(CreatePersonViewModel createPerson)
        {
            People person = new People();
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
            ViewBag.Message = "You are failed to add new Person";
            peopleView.PeopleList = person.GetPeople();

            return View("PeopleIndex", peopleView);

        }

        [HttpPost]
        public IActionResult PeopleSearch(PeopleViewModel people)
        {
            People person = new People();
            


            foreach (Person per in person.GetPeople())
            {

                if (per.Name.ToLower() == people.Namestring.ToLower())
                {
                    people.PeopleList.Clear();
                    people.PeopleList.Add(per);
                }

                //This is searching with match city value
                //if(per.City.ToLower() == peopleView.Citystring.ToLower())
                //{
                      //people.PeopleList.Clear();
                //    peopleView.PeopleList.Add(per);
                //}

            }
            
          
            return View("PeopleIndex",people);
        }
        public IActionResult DeletePerson(string p)
        {
            People person = new People();
            Person per = person.GetPeople(p);
            

            PeopleViewModel people1 = new PeopleViewModel();
            person.RemovePerson(per);
            people1.PeopleList = person.GetPeople();

            return View("PeopleIndex",people1);

        }
       
    }
}
