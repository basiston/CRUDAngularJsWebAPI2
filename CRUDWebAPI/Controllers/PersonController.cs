using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDWebAPI.Controllers
{
    public class PersonController : ApiController
    {

        private static List<Person> _list;

        static PersonController()
        {
            _list = new List<Person>();

        }

        [HttpPost]
        public IEnumerable<Person> Post(Person person)
        {
            person.PersonId = Guid.NewGuid();
            _list.Add(person);
            return _list;

        }


        [HttpGet]
        public Person Get(Guid? id)
        {

            return _list.Where(p => p.PersonId == id).SingleOrDefault();
        }



        [HttpPut]
        public List<Person> Put(Person person)
        {
            var per = _list.Where(p => p.PersonId == person.PersonId).SingleOrDefault();
            if (per != null)
            {
                per.PersonName = person.PersonName;
                per.SelectedCountry = person.SelectedCountry;
                per.SelectedCountryCode = person.SelectedCountryCode;
                per.SelectedCity = person.SelectedCity;
                per.SelectedCityCode = person.SelectedCityCode;
            }
            return _list;
        }

        [HttpDelete]
        public List<Person> Delete(Guid? personid)
        {
            var per = _list.Where(p => p.PersonId == personid).SingleOrDefault();
            _list.Remove(per);
            return _list;
        }
    }

    public class Person
    {

        public Guid? PersonId { get; set; }
        public string PersonName { get; set; }
        public string SelectedCountry { get; set; }

        public int? SelectedCountryCode { get; set; }


        public string SelectedCityCode { get; set; }
        public string SelectedCity { get; set; }

    }
}
