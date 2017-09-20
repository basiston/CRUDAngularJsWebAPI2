using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDWebAPI.Controllers
{
    public class CitiesController : ApiController
    {


        [HttpGet]
        public IEnumerable<City> Get(int? selectedcountry)
        {
            return this.GetCities().Where(p => p.CountyCode == selectedcountry);
        }

        [HttpGet]
        public IEnumerable<City> Get()
        {
            //now i am returning dummy data
            return this.GetCities();
        }

        private List<City> GetCities()
        {
            return new List<City>
            {
                new City {CountyCode=1, CityName="Bhubaneswar", CityCode="BBSR" },
                new City {CountyCode=1, CityName="Cuttack", CityCode="CTC" },
                new City {CountyCode=1, CityName="Roulkela", CityCode="RKL" },
                 new City {CountyCode=3, CityName="Oslo", CityCode="OSL" },
                new City {CountyCode=3, CityName="Bergan", CityCode="BER" },
                new City {CountyCode=3, CityName="Stavanger", CityCode="STA" },
                new City {CountyCode=2, CityName="Sisilia", CityCode="SIL" },
                new City {CountyCode=2, CityName="Rome", CityCode="ROM" },
                new City {CountyCode=2, CityName="Venice", CityCode="VEC" },
                new City {CountyCode=4, CityName="Toromolino", CityCode="TOR" },
                new City {CountyCode=4, CityName="Barcelona", CityCode="BAR" },
                new City {CountyCode=4, CityName="Barcelona1", CityCode="BAR1" },
                new City {CountyCode=5, CityName="Berlin", CityCode="BER" },
                new City {CountyCode=5, CityName="Frankfurt", CityCode="FRK" },
                new City {CountyCode=5, CityName="Humburg", CityCode="HBR" }
            };
        }
    }

    public class City
    {
        public int? CountyCode { get; set; }

        public string CityCode { get; set; }

        public string CityName { get; set; }
    }
}
