using GamingIndustrios.Models;
using GamingIndustrios.Models.DTOs.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GamingIndustrios.DataContextClass
{
    public class DataClass : DbContext
    {
        public DataClass(DbContextOptions<DataClass> options):
            base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Xbox> Xboxes { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Playstation> Playstations { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Driver> Drivers   { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
