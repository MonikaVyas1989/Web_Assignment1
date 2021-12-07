using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Assignment1.Models
{
    public class People
    {
        private static List<Person> PeopleList = new List<Person>();
        private static int id_counter;
        public Person CreatePerson(string name, string phone, string city)
        {
            Person newPerson = new Person(id_counter,name, phone, city);
            id_counter++;
            PeopleList.Add(newPerson);
            return newPerson;
        }
        public List<Person> GetPeople()
        {
            return PeopleList;
        }



        public void Person()
        {
            People person = new People();
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

        public Person GetPeople(int id)
        {
            Person personDetail = PeopleList.Find(c => c.ID == id);

            return personDetail;
        }

       
    }
}
