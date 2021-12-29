using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Models;

namespace Web_Assignment1.ViewModels
{
    public class LanguageViewModel:Language
    {
       public List<Language> Languages { get; set; }
 
       
        
        
    }
}
