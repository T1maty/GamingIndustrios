﻿using GamingIndustrios.Models;
using GamingIndustrios.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GamingIndustrios.DataContextClass
{
    public partial  class DataClass : DbContext
    {
     



        public DataClass(DbContextOptions<DataClass> options):
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
           // modelBuilder.Entity<UserDto>().Property(b => b.Gmail).IsRequired();
            //modelBuilder.Entity<UserDto>().Property(b => b.Password).IsRequired();
            //modelBuilder.Entity<UserDto>().Property(b => b.Username).IsRequired();


        }

        public DbSet<Xbox> Xboxes { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Playstation> Playstations { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Driver> Drivers   { get; set; }
        public DbSet<TransferCrypto> transferCryptos { get; set; }
        public DbSet<UserDto> UserDtos { get; set; }



    }
}
