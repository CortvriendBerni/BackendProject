using System;
using System.Collections.Generic;
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

            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 33, DriverName = "Max Verstappen", Age = 23, Country = "Netherlands", Team = "Red Bull Racing"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 11, DriverName = "Sergio Perez", Age = 31, Country = "Mexico", Team = "Red Bull Racing"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 55, DriverName = "Carlos Sainz", Age = 26, Country = "Spain", Team = "Ferrari"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 16, DriverName = "Charles Leclerc", Age = 23, Country = "Monaco", Team = "Ferrari"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 4, DriverName = "Lando Norris", Age = 21, Country = "United Kingdom", Team = "McLaren"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 3, DriverName = "Daniel Ricciardo", Age = 31, Country = "Australia", Team = "McLaren"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 44, DriverName = "Lewis Hamilton", Age = 36, Country = "United Kingdom", Team = "Mercedes"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 77, DriverName = "Valtteri Bottas", Age = 31, Country = "Finland", Team = "Mercedes"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 10, DriverName = "Pierre Gasly", Age = 25, Country = "France", Team = "AlphaTauri"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 22, DriverName = "Yuki Tsunoda", Age = 20, Country = "Japan", Team = "AlphaTauri"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 18, DriverName = "Lance Stroll", Age = 25, Country = "France", Team = "Aston Martin"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 5, DriverName = "Sebastian Vettal", Age = 33, Country = "Germany", Team = "Aston Martin"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 31, DriverName = "Esteban Ocon", Age = 24, Country = "France", Team = "Alpine"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 14, DriverName = "Fernando Alonso", Age = 39, Country = "Spain", Team = "Alpine"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 7, DriverName = "Kimi Räikkönen", Age = 41, Country = "Finland", Team = "Alfa Romeo Racing"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 99, DriverName = "Antonio Giovinazzi", Age = 27, Country = "Italy", Team = "Alfa Romeo Racing"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 6, DriverName = "Nicholas Latifi", Age = 25, Country = "Canada", Team = "Williams"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 63, DriverName = "Goerge Russel", Age = 23, Country = "United Kingdom", Team = "Williams"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 47, DriverName = "Mick Schumacher", Age = 22, Country = "Germany", Team = "Haas F1 Team"});
            modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 9, DriverName = "Nikita Mazepin", Age = 22, Country = "Russia", Team = "Haas F1 Team"});

            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Albert Park", Country = "Australia", Url= "https://f1-circuits.nl/albert-park/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Shanghai International Circuit", Country = "China", Url= "https://f1-circuits.nl/shanghai/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Bahrain International Circuit", Country = "Bahrain", Url= "https://f1-circuits.nl/bahrain/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Sochi Autodrom", Country = "Russia", Url= "https://f1-circuits.nl/sochi/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Circuit de Barcelona-Catalunya", Country = "Spain", Url= "https://f1-circuits.nl/barcelona/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Circuit de Monaco", Country = "Monaco", Url= "https://f1-circuits.nl/monaco/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Circuit Gilles Villeneuve", Country = "Canada", Url= "https://f1-circuits.nl/gilles-villeneuve/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Baku City Circuit", Country = "Azerbeidzjan", Url= "https://f1-circuits.nl/baku/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Red Bull Ring", Country = "Austria", Url= "https://f1-circuits.nl/red-bull-ring/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Silverstone", Country = "United Kingdom", Url= "https://f1-circuits.nl/silverstone/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Hungaroring", Country = "Hungary", Url= "https://f1-circuits.nl/hungaroring/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Circuit Spa-Francorchamps", Country = "Belgium", Url= "https://f1-circuits.nl/spa-francorchamps/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Autodromo Nazionale Monza", Country = "Italy", Url= "https://f1-circuits.nl/monza/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Marina Bay Circuit", Country = "Singapore", Url= "https://f1-circuits.nl/marina-bay/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Sepang International Circuit", Country = "Malaysia", Url= "https://f1-circuits.nl/sepang/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Suzuka", Country = "Japan", Url= "https://f1-circuits.nl/suzuka/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Autódromo Hermanos Rodríguez", Country = "Mexico", Url= "https://f1-circuits.nl/mexico/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Circuit of the Americas", Country = "United States", Url= "https://f1-circuits.nl/americas/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Interlagos", Country = "Brazil", Url= "https://f1-circuits.nl/interlagos/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Yas Marina Circuit", Country = "United Arab Emirates", Url= "https://f1-circuits.nl/yas-marina/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Paul Ricard", Country = "France", Url= "https://f1-circuits.nl/paul-ricard/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Hockendheimring", Country = "Germany", Url= "https://f1-circuits.nl/hockenheim/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Zandvoort", Country = "The Netherlands", Url= "https://f1-circuits.nl/zandvoort/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Vietnam", Country = "Vietnam", Url= "https://f1-circuits.nl/vietnam/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Mugello Circuit", Country = "Italy", Url= "https://f1-circuits.nl/mugello/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Nürburging", Country = "Germany", Url= "https://f1-circuits.nl/nurburgring/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Autodromo Enzo e Dino Ferrari", Country = "Italy", Url= "https://f1-circuits.nl/imola/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Autodromo Internacional do Algarve", Country = "Portugal", Url= "https://f1-circuits.nl/algarve/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Istanbul Park", Country = "Turkey", Url= "https://f1-circuits.nl/istanbul-park/"});
            modelBuilder.Entity<Circuits>().HasData(new Circuits(){CircuitId = Guid.NewGuid(), CircuitName = "Jeddah Street Circuit", Country = "Saudi Arabia", Url= "https://f1-circuits.nl/jeddah-street/"});

            modelBuilder.Entity<Teams>().HasData(new Teams(){TeamId = Guid.NewGuid(), TeamName = "Redd Bull Racing"});
            modelBuilder.Entity<Teams>().HasData(new Teams(){TeamId = Guid.NewGuid(), TeamName = "Ferrari"});
            modelBuilder.Entity<Teams>().HasData(new Teams(){TeamId = Guid.NewGuid(), TeamName = "Mercedes"});
            modelBuilder.Entity<Teams>().HasData(new Teams(){TeamId = Guid.NewGuid(), TeamName = "McLaren"});
            modelBuilder.Entity<Teams>().HasData(new Teams(){TeamId = Guid.NewGuid(), TeamName = "Haas F1 Team"});
            modelBuilder.Entity<Teams>().HasData(new Teams(){TeamId = Guid.NewGuid(), TeamName = "Williams"});
            modelBuilder.Entity<Teams>().HasData(new Teams(){TeamId = Guid.NewGuid(), TeamName = "AlphaTauri"});
            modelBuilder.Entity<Teams>().HasData(new Teams(){TeamId = Guid.NewGuid(), TeamName = "Alpine"});
            modelBuilder.Entity<Teams>().HasData(new Teams(){TeamId = Guid.NewGuid(), TeamName = "Alfa Romeo Racing"});
            modelBuilder.Entity<Teams>().HasData(new Teams(){TeamId = Guid.NewGuid(), TeamName = "Aston Martin"});

            // modelBuilder.Entity<List<TeamDrivers>>().HasData(new List<TeamDrivers>(){TeamId = Guid.NewGuid(), TeamName = "Aston Martin"});
        }
    }
}
