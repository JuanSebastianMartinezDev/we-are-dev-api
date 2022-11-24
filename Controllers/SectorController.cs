using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WeAreDevApi.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace WeAreDevApi.Controllers
{
    [ApiController]
    [Route("api/sector")]
    public class SectorController : ControllerBase
    {
        private MySQLDBContext _dbContext;

        public SectorController(MySQLDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IList<Sector> AllSectors()
        {
            return (this._dbContext.Sector.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Sector> GetSectorById(int Id)
        {
            var sector = _dbContext.Sector.Find(Id);

            return Ok(sector);
        }

        [HttpPost]
        public ActionResult SaveSector(Sector sector)
        {

            sector.CreatedAt=DateTime.Now;
            _dbContext.Sector.Add(sector);
            _dbContext.SaveChanges();

            return Accepted(true);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSector(int id,Sector newSector)
        {
            var sector = _dbContext.Sector.Find(id);

            if (sector == null)
            {
                return NotFound();
            }
            sector.State = newSector.State;
            sector.Name = newSector.Name;
            sector.UpdatedAt = DateTime.Now;
            _dbContext.SaveChanges();

            return Accepted(true);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSector(int id)
        {
            var sector = _dbContext.Sector.Find(id);

            if (sector == null)
            {
                return NotFound();
            }
            sector.State = 0;
            _dbContext.SaveChanges();

            return Accepted(true);
        }

        [HttpPost("restore/{id}")]
        public ActionResult RestoreSector(int id)
        {
            var sector = _dbContext.Sector.Find(id);

            if (sector == null)
            {
                return NotFound(false);
            }
            sector.State = 1;
            _dbContext.SaveChanges();

            return Accepted(true);
        }


    }
}
