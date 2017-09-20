using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDWebAPI.Controllers
{
    public class CountriesController : ApiController
    {


        [HttpGet]
        public IEnumerable<Country> Get()
        {
            //now i am returning dummy data
            return GetCountries();
        }

        ////here i want to create a function that generate list of countries and country code, this data can come from Database

        private List<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country {CountryCode =1, CountryName="India" },
                new Country {CountryCode =2, CountryName="Italy" },
                new Country {CountryCode =3, CountryName="Norway" },
                new Country {CountryCode =4, CountryName="Spain" },
                new Country {CountryCode =5, CountryName="Germany" },
                new Country {CountryCode =6, CountryName="Other" }
            };
        }
    }


    public class Country
    {
        public int? CountryCode { get; set; }

        public string CountryName { get; set; }


    }
}
