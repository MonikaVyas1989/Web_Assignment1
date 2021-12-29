using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Models;

namespace Web_Assignment1.ViewModels
{
    public class PersonViewModel
    {

        public List<PersonModel> Person { get; set; }
        public List<City> City { get; set; }
        public List<Country> Country { get; set;   }
    }
}
