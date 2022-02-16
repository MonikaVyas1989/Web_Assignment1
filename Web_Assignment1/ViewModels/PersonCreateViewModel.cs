using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Assignment1.ViewModels
{
    public class PersonCreateViewModel
    {
       
        public string Name { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public List <string> Languages { get; set; }
    }
}
