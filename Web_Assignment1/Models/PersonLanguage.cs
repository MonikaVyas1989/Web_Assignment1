using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.ViewModels;

namespace Web_Assignment1.Models
{
    public class PersonLanguage
    {
        public int PersonId { get; set; }

        public int LanguageId { get; set; }

        public PersonModel Person { get; set; }

        public LanguageViewModel Language { get; set; }
    }
}
