using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Assignment1.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string Name { get; set; }

        public List<PersonLanguage> People { get; set; }
    }
}
