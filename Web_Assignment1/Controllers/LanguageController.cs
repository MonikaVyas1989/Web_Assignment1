using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Data;
using Web_Assignment1.ViewModels;
using Web_Assignment1.Models;

namespace Web_Assignment1.Controllers
{
    public class LanguageController : Controller
    {
        private readonly PeopleDbContext dbContext;

        public LanguageController(PeopleDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Language()
        {
            PersonViewModel personView = new PersonViewModel()
            {
                Person= dbContext.Persons.ToList()
            };
            return View(personView);
        }
    }
}
