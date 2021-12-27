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
        //[Key]
        //public int Id { get; set; }

        //[Required]
        //[MaxLength(30)]
        //public string Name { get; set; }

        //public List<CityViewModel> Cities { get; set; }
        public List<Country> CountryList { get; set; }
        //public List<City> CityList { get; set; }
    }
}
