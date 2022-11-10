using GamingIndustrios.Models;
using Microsoft.EntityFrameworkCore;

namespace GamingIndustrios.DataContextClass
{
    public class DataClass : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataClass(IConfiguration configuration)
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
