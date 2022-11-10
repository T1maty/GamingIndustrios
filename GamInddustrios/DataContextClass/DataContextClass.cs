using GamInddustrios.Models;
using Microsoft.EntityFrameworkCore;

namespace GamingIndustrios.DataContextClass
{
    public class DataContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Xbox> Xboxes { get; set; }
    }
}
