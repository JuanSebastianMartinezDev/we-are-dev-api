using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WeAreDevApi.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace WeAreDevApi.Controllers
{
    [ApiController]
    [Route("api/country")]
    public class CountryController : ControllerBase
    {
        private MySQLDBContext _dbContext;

        public CountryController(MySQLDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IList<Country> AllCountrys()
        {
            
            return this._dbContext.Country.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Country> GetCountryById(int Id)
        {
            var country = _dbContext.Country.Find(Id);
            if (country == null)
            {
                return NotFound();
            }  
            return Ok(country);
        }

        [HttpPost]
        public ActionResult SaveCountry(Country country)
        {

            country.CreatedAt=DateTime.Now;
            _dbContext.Country.Add(country);
            _dbContext.SaveChanges();

            return Accepted(true);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCountry(int id,Country newCountry)
        {
            var country = _dbContext.Country.Find(id);

            if (country == null)
            {
                return NotFound();
            }
            country.State = newCountry.State;
            country.Name = newCountry.Name;
            country.UpdatedAt = DateTime.Now;
            _dbContext.SaveChanges();

            return Accepted(true);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCountry(int id)
        {
            var country = _dbContext.Country.Find(id);

            if (country == null)
            {
                return NotFound();
            }
            country.State = 0;
            _dbContext.SaveChanges();

            return Accepted(true);
        }

        [HttpPost("restore/{id}")]
        public ActionResult RestoreCountry(int id)
        {
            var country = _dbContext.Country.Find(id);

            if (country == null)
            {
                return NotFound(false);
            }
            country.State = 1;
            _dbContext.SaveChanges();

            return Accepted(true);
        }


    }
}
