 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Web_Assignment1.Models
{
    public class Person
    {

       
        //private readonly int id;
        
        //public int ID { get { return id; } }

        [Key]
        public int PersonId { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string City { get; set; }


        public Person()
        {
            
        }
        public Person(int id,string name, string phone, string city)
        {
            //this.id = id;
            PersonId = id;
             Name = name;
             Phone = phone;
             City = city;
        }



       
       


    }
    } 