using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Models;
using System.ComponentModel.DataAnnotations;
using Web_Assignment1.Controllers;


namespace Web_Assignment1.ViewModels
{
    public class CreatePersonViewModel
    {
        

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter person name."), MaxLength(50), MinLength(3)]
        public string Name { get; set; }


       
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Phone Number.")]
        public string Phone { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter your City."), MaxLength(25), MinLength(3)]
        public string City { get; set; }
        

        
    }
}
