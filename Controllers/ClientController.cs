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
            return (this._dbContext.Client.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Client> GetClientById(int Id)
        {
            var type = _dbContext.Client.Find(Id);

            return Ok(type);
        }

        [HttpPost]
        public ActionResult SaveClient(Client type)
        {

            type.CreatedAt=DateTime.Now;
            _dbContext.Client.Add(type);
            _dbContext.SaveChanges();

            return Accepted(true);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateClient(int id,Client typeClient)
        {
            var type = _dbContext.Client.Find(id);

            if (type == null)
            {
                return NotFound();
            }
            type.State = typeClient.State;
            type.Name = typeClient.Name;
            type.UpdatedAt = DateTime.Now;
            _dbContext.SaveChanges();

            return Accepted(true);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteClient(int id)
        {
            var type = _dbContext.Client.Find(id);

            if (type == null)
            {
                return NotFound();
            }
            type.State = 0;
            _dbContext.SaveChanges();

            return Accepted(true);
        }

        [HttpPost("restore/{id}")]
        public ActionResult RestoreClient(int id)
        {
            var type = _dbContext.Client.Find(id);

            if (type == null)
            {
                return NotFound(false);
            }
            type.State = 1;
            _dbContext.SaveChanges();

            return Accepted(true);
        }


    }
}
