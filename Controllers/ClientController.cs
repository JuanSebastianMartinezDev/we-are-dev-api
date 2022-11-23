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
            return (this._dbContext.Client.Include(x => x.TypeClient).ToList());
        }

        [HttpGet("/{id}")]
        public ActionResult<Client> GetClientById(int Id)
        {
            var client = _dbContext.Client.Find(Id);

            return Ok(client);
        }

        [HttpPost]
        public ActionResult<Client> SaveClient(Client client)
        {
            _dbContext.Client.Add(client);
            _dbContext.SaveChanges();

            return Accepted();
        }


        [HttpDelete("{id}")]
        public ActionResult<Client> DeleteClient(int id)
        {
            var client = _dbContext.Client.Find(id);

            if (client == null)
            {
                return NotFound();
            }
            client.State = 0;
            _dbContext.Update(client);

            return Accepted();
        }


    }
}
