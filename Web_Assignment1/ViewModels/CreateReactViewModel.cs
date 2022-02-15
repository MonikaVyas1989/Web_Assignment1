using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Assignment1.ViewModels
{
    public class CreateReactViewModel
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter person name.")]
        public string Name { get; set; }



        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Phone Number.")]
        public string Phone { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Select your City.")]
        public string City { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Select your Country.")]
        public string Country { get; set; }

    }
}
