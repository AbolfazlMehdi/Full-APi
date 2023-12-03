using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Database
{
    public class AppDbContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("dbContext");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
