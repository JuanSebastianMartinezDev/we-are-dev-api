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

        [HttpGet("{id}")]
        public ActionResult<TypeClient> GetTypeClientById(int Id)
        {
            var type = _dbContext.TypeClient.Find(Id);

            return Ok(type);
        }

        [HttpPost]
        public ActionResult SaveTypeClient(TypeClient type)
        {

            type.CreatedAt=DateTime.Now;
            _dbContext.TypeClient.Add(type);
            _dbContext.SaveChanges();

            return Accepted(true);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTypeClient(int id,TypeClient typeClient)
        {
            var type = _dbContext.TypeClient.Find(id);

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
        public ActionResult DeleteTypeClient(int id)
        {
            var type = _dbContext.TypeClient.Find(id);

            if (type == null)
            {
                return NotFound();
            }
            type.State = 0;
            _dbContext.SaveChanges();

            return Accepted(true);
        }

        [HttpPost("restore/{id}")]
        public ActionResult RestoreTypeClient(int id)
        {
            var type = _dbContext.TypeClient.Find(id);

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
