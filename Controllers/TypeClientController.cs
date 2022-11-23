using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WeAreDevApi.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace WeAreDevApi.Controllers
{
    [ApiController]
    [Route("api/type-client")]
    public class TypeClientController : ControllerBase
    {
        private MySQLDBContext _dbContext;

        public TypeClientController(MySQLDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IList<TypeClient> AllTypeClients()
        {
            return (this._dbContext.TypeClient.ToList());
        }

        [HttpGet("/{id}")]
        public ActionResult<TypeClient> GetTypeClientById(int Id)
        {
            var client = _dbContext.TypeClient.Find(Id);

            return Ok(client);
        }

        [HttpPost]
        public ActionResult<TypeClient> SaveTypeClient(TypeClient client)
        {
            _dbContext.TypeClient.Add(client);
            _dbContext.SaveChanges();

            return Accepted();
        }


        [HttpDelete("{id}")]
        public ActionResult<TypeClient> DeleteTypeClient(int id)
        {
            var client = _dbContext.TypeClient.Find(id);

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
