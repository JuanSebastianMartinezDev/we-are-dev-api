using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WeAreDevApi.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace WeAreDevApi.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private MySQLDBContext _dbContext;

        public ClientController(MySQLDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IList<Client> AllClients()
        {
             
            return this._dbContext.Client.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Client> GetClientById(int Id)
        {
            var client = _dbContext.Client.Include(b => b.Annotations).Include(b => b.Tags).Where(a => a.Id==Id).First();
            if(client == null)
            {
                return NotFound();
            } 
            return Ok(client);
        }


        [HttpGet("data-view")]
        public ActionResult DataView()
        {
            var typeClients = this._dbContext.TypeClient.Where(a => a.State==1).ToList();
            var sectorsSearch = this._dbContext.Sector.Where(a => a.State==1).ToList();
            var countrysSearch = this._dbContext.Country.Where(a => a.State==1).ToList();

            return Ok(new { types = typeClients, sectors = sectorsSearch, countrys = countrysSearch });
        }

        [HttpPost]
        public ActionResult SaveClient(Client client)
        {
            client.CreatedAt=DateTime.Now;
            _dbContext.Client.Add(client);
            _dbContext.SaveChanges();

            return Accepted(true);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateClient(int id,Client newClient)
        {
            var client = _dbContext.Client.Include(b => b.Annotations).Include(b => b.Tags).Where(a => a.Id == id).First();

            if(client == null)
            {
                return NotFound();
            }
            client.State = newClient.State;
            client.Name = newClient.Name;
            client.Email = newClient.Email;
            client.Direction = newClient.Direction;
            client.Description = newClient.Description;
            client.SectorId = newClient.SectorId;
            client.CountryId = newClient.CountryId;
            client.TypeClientId= newClient.TypeClientId;
            client.Annotations = newClient.Annotations;
            client.Tags = newClient.Tags;
            client.Phone = newClient.Phone;
            client.Phone2= newClient.Phone2;
            client.City= newClient.City;
            client.UpdatedAt = DateTime.Now;
            _dbContext.SaveChanges();

            return Accepted(true);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteClient(int id)
        {
            var client = _dbContext.Client.Find(id);

            if(client == null)
            {
                return NotFound();
            }
            client.State = 0;
            _dbContext.SaveChanges();

            return Accepted(true);
        }

        [HttpPost("restore/{id}")]
        public ActionResult RestoreClient(int id)
        {
            var client = _dbContext.Client.Find(id);

            if(client == null)
            {
                return NotFound(false);
            }
            client.State = 1;
            _dbContext.SaveChanges();

            return Accepted(true);
        }


    }
}
