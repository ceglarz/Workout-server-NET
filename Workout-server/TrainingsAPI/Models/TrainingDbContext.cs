using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingsAPI.Models
{
    public class TrainingDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
           ("Server=(localdb)\\mssqllocaldb;Database=TrainingDb;Trusted_Connection=True;");
        }

        public DbSet<Training> Trainings { get; set; }
    }
}
