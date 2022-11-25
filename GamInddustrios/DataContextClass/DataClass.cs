﻿using GamingIndustrios.Models;
using GamingIndustrios.Models.Authorization;
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
        public DbSet<Games> Games { get; set; }
        public DbSet<LoginModel> LoginModels { get; set; }
        public DbSet<RegisterModel>  RegisterModels { get; set; }
        public DbSet<Response> Responses { get; set; }


    }
}
