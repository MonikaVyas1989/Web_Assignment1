using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Assignment1.Models
{
    public class People
    {
        private static readonly List<Person> PeopleList = new List<Person>() {
            new Person() { Name = "Lokendra", Phone = "+461223415112", City = "Lund" },
            new Person() { Name = "Karl", Phone = "+464576468456", City = "Halmstad" },
            new Person() { Name = "David", Phone = " + 464576468211", City = "Göteborg" },
            new Person() { Name = "Hammad", Phone = "+464512345612", City = "Helsingborg" },
            new Person() { Name = "Johan", Phone = "+464512345689", City = "Ronneby" }
            };
        private static int id_counter;
        public Person CreatePerson(string name, string phone, string city)
        {
            Person newPerson = new Person(id_counter, name, phone, city);
            id_counter++;
            PeopleList.Add(newPerson);
            return newPerson;
        }
        public List<Person> GetPeople()
        {
            return PeopleList;
        }



        //public People()
        //{
            
            //People person = new People();
            //person.CreatePerson("Lokendra", "+461223415112", "Lund");
            //person.CreatePerson("Karl", "+464576468456", "Halmstad");
            //person.CreatePerson("David", "+464576468211", "Göteborg");
            //person.CreatePerson("Hammad", "+464512345612", "Helsingborg");
        //}
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

        public Person GetPeople(int id)
        {

            Person personDetail =  PeopleList.ElementAt(id);
            return personDetail;
           
            
        }

       
    }
}
