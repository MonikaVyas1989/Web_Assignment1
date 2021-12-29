using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.ViewModels;

namespace Web_Assignment1.Models
{
    public class PersonModel
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }

        [Required]
        public int CityId { get; set; }
        public City City{ get; set; }

        public List<PersonLanguage> People { get; set; }
    }
}
