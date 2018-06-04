using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Models
{
    public class PlaceDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
           ("Server=(localdb)\\mssqllocaldb;Database=PlaceDb;Trusted_Connection=True;");

        }

        public DbSet<Place> Places { get; set; }

    }
}
