using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WeAreDevApi.Models;
using Microsoft.EntityFrameworkCore;


namespace WeAreDevApi.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : Controller
    {
        private MySQLDBContext _dbContext;

        public ClientController(MySQLDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IList<Client> allClients()
        {
            return (this._dbContext.Client.Include(x => x.TypeClient).ToList());
        }
    }
}
