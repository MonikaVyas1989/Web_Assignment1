using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Models;

namespace Web_Assignment1.ViewModels
{
    public class PeopleViewModel:Person
    {
        public  List<Person> PeopleList { get; set; }

        public string Namestring { get; set; }

        //public string Citystring { get; set; }

        
        public PeopleViewModel()
        {
            PeopleList = new List<Person>();
           
        }

    }
}
