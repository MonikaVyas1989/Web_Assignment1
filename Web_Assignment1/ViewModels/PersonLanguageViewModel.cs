using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Models;

namespace Web_Assignment1.ViewModels
{
    public class PersonLanguageViewModel:PersonLanguage
    {
        public List<PersonLanguage> GetPersonLanguages { get; set; }
       
    }
}
