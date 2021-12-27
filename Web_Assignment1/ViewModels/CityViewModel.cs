using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Models;

namespace Web_Assignment1.ViewModels
{
    public class CityViewModel:City
    {
        //[Key]
        //public int Id { get; set; }

        //[Required]
        //[MaxLength(25)]
        //[MinLength(3)]
        //public string Name { get; set; }

        //[Required]
        //public int CountryId { get; set; }

        //public CountryViewModel Country { get; set; }
        //public List<PersonModel> People { get; set; }
        public List<City> CityList { get; set; }
        
    }
}
