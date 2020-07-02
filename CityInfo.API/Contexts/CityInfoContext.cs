using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Contexts
{
    public class CityInfoContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfIntrest> PointOfIntrests { get; set; }

        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City()
                {
                    Id = 1,
                    Name = "Toronto",
                    Description = "Canada Capital City"
                },
                new City()
                {
                    Id = 2,
                    Name = "Brampton",
                    Description = "Majotiry of Indian Society lives"
                },
                new City()
                {
                    Id = 3,
                    Name = "Calgary",
                    Description = "The place with scenic beauty"
                }
                );

            modelBuilder.Entity<PointOfIntrest>().HasData(
                new PointOfIntrest()
                {
                    Id = 1,
                    Name = "CN Tower",
                    Description = "Iconic tower with revolving restaurant",
                    CityId = 1,
                },
                new PointOfIntrest()
                {
                    Id = 2,
                    Name = "Royal Museum",
                    CityId = 1,
                    Description = "Huge range of  cultures"
                }, new PointOfIntrest()
                {
                    Id = 3,
                    Name = "Casa Loma",
                    CityId = 1,
                    Description = "Stately castle and gardens"
                },
                new PointOfIntrest()
                {
                    Id = 4,
                    Name = "Humber River",
                    CityId = 2,
                    Description = "River, Marsh, park and garden"
                },
                new PointOfIntrest()
                {
                    Id = 5,
                    Name = "Heart Lake",
                    CityId = 2,
                    Description = "Wetlands and Ziplines"
                },
                 new PointOfIntrest()
                 {
                     Id = 6,
                     Name = "Calgary Tower",
                     CityId = 3,
                     Description = "City Vitas and revolving restaurant"
                 },
                new PointOfIntrest()
                {
                    Id = 7,
                    Name = "Calgary Zoo",
                    CityId = 3,
                    Description = "Live animals and dianasaur displays"
                }
                );

            base.OnModelCreating(modelBuilder);
        }

        //Amother way to configure 
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
