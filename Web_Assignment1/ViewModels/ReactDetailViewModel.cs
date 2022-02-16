using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Assignment1.ViewModels
{
    public class ReactDetailViewModel
    {
        public int personId { get; set; }
        public string Name { get; set; }



       
        public string Phone { get; set; }

        
        public string City { get; set; }

        
        public string Country { get; set; }
        public List<string> Language { get; set; } = new List<string>();

    }
}
