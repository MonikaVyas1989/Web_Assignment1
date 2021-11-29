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

       
        private static readonly List<Person> PeopleList = new List<Person>();
        
        public Person()
        {
            
        }
        public Person(string name, string phone, string city)
        {
            
             Name = name;
             Phone = phone;
             City = city;
        }
        public Person CreatePerson(string name,string phone,string city)
        {
            Person newPerson = new Person(name, phone, city);
            PeopleList.Add(newPerson);
            return newPerson;
        }
        public List<Person> GetPeople()
        { 
            return PeopleList;
        }

       

        public void People()
        {
            Person person = new Person();
            person.CreatePerson("Lokendra", "+461223415112", "Lund");
            person.CreatePerson("Karl", "+464576468456", "Halmstad");
            person.CreatePerson("David", "+464576468211", "Göteborg");
            person.CreatePerson("Hammad", "+464512345612", "Helsingborg");
        }
        public Person GetPeople(string name)
        {
            Person personToDelete = PeopleList.Find(c => c.Name == name);

            return personToDelete;

        }

        public bool RemovePerson(Person per)
        {
            bool delete = PeopleList.Remove(per);
            return delete;
        }


    }
    } 