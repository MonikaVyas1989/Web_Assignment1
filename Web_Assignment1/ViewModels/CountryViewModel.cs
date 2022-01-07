using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Models;

namespace Web_Assignment1.ViewModels
{
    public class CountryViewModel:Country
    {
        
        public List<Country> CountryList { get; set; }
        //public List<City> CityList { get; set; }
    }
}
 