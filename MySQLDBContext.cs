using Microsoft.EntityFrameworkCore;
using WeAreDevApi.Models;

namespace WeAreDevApi
{
    public class MySQLDBContext: DbContext
    {
        public DbSet<Country> Country { get; set; }
        public DbSet<Sector> Sector { get; set; }
        public DbSet<TypeClient> TypeClient { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<ClientTag> ClientTag { get; set; } 
        public DbSet<ClientAnnotation> ClientAnnotation { get; set; }

        public MySQLDBContext(DbContextOptions<MySQLDBContext> options) : base(options) { }
    }
}
