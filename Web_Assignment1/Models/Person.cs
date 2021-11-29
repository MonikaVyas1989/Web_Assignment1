using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.ViewModels;

namespace Web_Assignment1.Models
{
    public class Person
    {
        //private readonly int _id;
        //public int ID { get { return _id; } }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }

        //private static int _idCounter;

        private static readonly List<Person> PeopleList = new List<Person>();
        //private static List<CreatePersonViewModel> PersonList = new List<CreatePersonViewModel>();
        //public List<Person> PeopleList1 => PeopleList;//{get{return PeopleList;} }

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
            //_idCounter++;
            return newPerson;
        }
        public List<Person> GetPeople()
        { 
            return PeopleList;
        }

        //public CreatePersonViewModel CreatePerson(string name, string phone, string city)
        //{
        //    CreatePersonViewModel newPerson = new CreatePersonViewModel(_idCounter, name, phone, city);

        //    PersonList.Add(newPerson);
        //    _idCounter++;
        //    return newPerson;
        //}
        // public List<CreatePersonViewModel> GetPeople()
        //{

        //    return PersonList;
        //}

        public void People()
        {
            Person person = new Person();
            person.CreatePerson("Lokendra", "+4612234", "Khadka");
            person.CreatePerson("Karl", "+464576468", "Andersson");
            
        }
        public Person GetPeople(string name)
        {
            Person personToDelete = PeopleList.Find(c => c.Name == name);

            return personToDelete;

        }

        //public bool RemovePerson(Person per)
        //{
        //    bool delete = PeopleList.Remove(per);
        //    return delete;
        //}


    }
    } 