using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.ViewModels;

namespace Web_Assignment1.Models
{
    public class Person
    {
       
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }

        private readonly int id;
        public int ID { get { return id; } }

        
        
        public Person()
        {
            
        }
        public Person(int id,string name, string phone, string city)
        {
             this.id = id;
             Name = name;
             Phone = phone;
             City = city;
        }



       
       


    }
    } 