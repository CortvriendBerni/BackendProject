using System;
using Formula1.Configuration;
using Formula1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Formula1.Data
{
    public class FormulaContext : DbContext
    {
        public DbSet<Circuits> Circuits { get; set; }
        public DbSet<Drivers> Drivers { get; set; }
        public DbSet<DriverCircuits> DriverCircuits { get; set; }
        public DbSet<Ranking> Ranking { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<TeamDrivers> TeamDrivers { get; set; }
        private ConnectionStrings _connectionStrings;

        public FormulaContext(DbContextOptions<FormulaContext> options, IOptions<ConnectionStrings> connectionStrings): base(options)
        {
            _connectionStrings = connectionStrings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
            options.UseSqlServer(_connectionStrings.SQL);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DriverCircuits>().HasKey(cs => new { cs.DriverId, cs.CircuitId });
            modelBuilder.Entity<TeamDrivers>().HasKey(cs => new { cs.TeamId, cs.DriverId });

            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 1, Number = 33, DriverName = "Max Verstappen", Age = 23, Country = "Netherlands", Team = "Red Bull Racing"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 2, Number = 11, DriverName = "Sergio Perez", Age = 31, Country = "Mexico", Team = "Red Bull Racing"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 3, Number = 55, DriverName = "Carlos Sainz", Age = 26, Country = "Spain", Team = "Ferrari"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 4, Number = 16, DriverName = "Charles Leclerc", Age = 23, Country = "Monaco", Team = "Ferrari"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 5, Number = 4, DriverName = "Lando Norris", Age = 21, Country = "United Kingdom", Team = "McLaren"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 6, Number = 3, DriverName = "Daniel Ricciardo", Age = 31, Country = "Australia", Team = "McLaren"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 7, Number = 44, DriverName = "Lewis Hamilton", Age = 36, Country = "United Kingdom", Team = "Mercedes"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 8, Number = 77, DriverName = "Valtteri Bottas", Age = 31, Country = "Finland", Team = "Mercedes"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 9, Number = 10, DriverName = "Pierre Gasly", Age = 25, Country = "France", Team = "AlphaTauri"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 10, Number = 22, DriverName = "Yuki Tsunoda", Age = 20, Country = "Japan", Team = "AlphaTauri"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 11, Number = 18, DriverName = "Lance Stroll", Age = 25, Country = "France", Team = "Aston Martin"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 12, Number = 5, DriverName = "Sebastian Vettal", Age = 33, Country = "Germany", Team = "Aston Martin"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 13, Number = 31, DriverName = "Esteban Ocon", Age = 24, Country = "France", Team = "Alpine"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 14, Number = 14, DriverName = "Fernando Alonso", Age = 39, Country = "Spain", Team = "Alpine"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 15, Number = 7, DriverName = "Kimi Räikkönen", Age = 41, Country = "Finland", Team = "Alfa Romeo Racing"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 16, Number = 99, DriverName = "Antonio Giovinazzi", Age = 27, Country = "Italy", Team = "Alfa Romeo Racing"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 17, Number = 6, DriverName = "Nicholas Latifi", Age = 25, Country = "Canada", Team = "Williams"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 18, Number = 63, DriverName = "Goerge Russel", Age = 23, Country = "United Kingdom", Team = "Williams"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 19, Number = 47, DriverName = "Mick Schumacher", Age = 22, Country = "Germany", Team = "Haas F1 Team"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = 20, Number = 9, DriverName = "Nikita Mazepin", Age = 22, Country = "Russia", Team = "Haas F1 Team"});
        }
    }
}
