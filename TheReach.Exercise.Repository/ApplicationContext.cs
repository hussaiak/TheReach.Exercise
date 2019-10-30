using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TheReach.Exercise.DataModel.Models;

namespace TheReach.Exercise.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
              : base(options)
        {
        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Country>()
                .HasData(
                    InitializeCountries()
                );

            modelBuilder.Entity<Postcode>()
                .HasData(
                    InitializePostcodes()
                );
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Postcode> Postcodes { get; set; }

        public DbSet<Country> Countries { get; set; }

        public List<Country> InitializeCountries()
        {
            return new List<Country>
            {
                 new Country
                    {
                       Id = 1,
                       CountryName = "Australia",
                       CountryCode = "AU",
                    },
                    new Country
                    {
                        Id = 2,
                        CountryName = "New Zealand",
                        CountryCode = "NZ",
                    },
                    new Country
                    {
                        Id = 3,
                        CountryName = "Antarctica",
                        CountryCode = "AQ",
                    },
                    new Country
                    {
                        Id = 4,
                        CountryName = "Argentina",
                        CountryCode = "AR",
                    },
                    new Country
                    {
                        Id = 5,
                        CountryName = "Brazil",
                        CountryCode = "BR",
                    },
                    new Country
                    {
                        Id = 6,
                        CountryName = "India",
                        CountryCode = "IND",
                    },
                    new Country
                    {
                        Id = 7,
                        CountryName = "China",
                        CountryCode = "CH",
                    },
                    new Country
                    {
                        Id = 8,
                        CountryName = "Germany",
                        CountryCode = "DE",
                    },
                    new Country
                    {
                        Id = 9,
                        CountryName = "England",
                        CountryCode = "EN",
                    },
                    new Country
                    {
                        Id = 10,
                        CountryName = "United States",
                        CountryCode = "US",
                    }
            };
        }

        public List<Postcode> InitializePostcodes()
        {
            return new List<Postcode>
            {
                new Postcode
                    {
                        Id = 50,
                        Pcode = "2000",
                        Locality = "Sydney",
                        State ="NSW",
                        CountryCode = "AU",
                        Category= "Delivery Area"
                    },
                    new Postcode
                    {
                        Id = 51,
                        Pcode = "2140",
                        Locality = "Homebush",
                        State = "NSW",
                        CountryCode = "AU",
                        Category = "Delivery Area"
                    },
                    new Postcode
                    {
                        Id = 52,
                        Pcode = "2133",
                        Locality = "Parametta",
                        State = "NSW",
                        CountryCode = "AU",
                        Category = "Delivery Area"
                    },
                    new Postcode
                    {
                        Id = 53,
                        Pcode = "2840",
                        Locality = "AARONS PASS",
                        State = "NSW",
                        CountryCode = "AU",
                        Category = "Delivery Area"
                    },
                    new Postcode
                    {
                        Id = 60,
                        Pcode = "3737",
                        Locality = "ABBEYARD",
                        State = "VIC",
                        CountryCode = "AU",
                        Category = "Delivery Area"
                    },
                    new Postcode
                    {
                        Id = 54,
                        Pcode = "2610",
                        Locality = "ACTON",
                        State = "ACT",
                        CountryCode = "AU",
                        Category = "Delivery Area"
                    },
                    new Postcode
                    {
                        Id = 55,
                        Pcode = "5159",
                        Locality = "ABERFOYLE PARK",
                        State = "SA",
                        CountryCode = "AU",
                        Category = "Delivery Area"
                    },
                    new Postcode
                    {
                        Id = 56,
                        Pcode = "6280",
                        Locality = "ABBA RIVER",
                        State = "WA",
                        CountryCode = "AU",
                        Category = "Delivery Area"
                    },
                    new Postcode
                    {
                        Id = 57,
                        Pcode = "7360",
                        Locality = "ACACIA HILLS",
                        State = "TAS",
                        CountryCode = "AU",
                        Category = "Delivery Area"
                    },
                    new Postcode
                    {
                        Id = 58,
                        Pcode = "3918",
                        Locality = "ABBEYWOOD",
                        State = "QLD",
                        CountryCode = "AU",
                        Category = "Delivery Area"
                    }
            };
        }
    }
}
