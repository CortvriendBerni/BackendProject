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
        public DbSet<Circuit> Circuits { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverCircuit> DriverCircuits { get; set; }
        public DbSet<Ranking> Ranking { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamDriver> TeamDrivers { get; set; }
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
            modelBuilder.Entity<DriverCircuit>().HasKey(cs => new { cs.DriverId, cs.CircuitId });
            modelBuilder.Entity<TeamDriver>().HasKey(cs => new { cs.TeamId, cs.DriverId });
            
            modelBuilder.Entity<Driver>().HasOne<Ranking>(s => s.Rank).WithOne(ad => ad.Driver).HasForeignKey<Ranking>(ad => ad.DriverId);
            modelBuilder.Entity<Ranking>().HasOne<Driver>(ad => ad.Driver).WithOne(s => s.Rank).HasForeignKey<Ranking>(ad => ad.DriverId);

            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 33, DriverName = "Max Verstappen", Age = 23, Country = "Netherlands", Team = "Red Bull Racing"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 11, DriverName = "Sergio Perez", Age = 31, Country = "Mexico", Team = "Red Bull Racing"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 55, DriverName = "Carlos Sainz", Age = 26, Country = "Spain", Team = "Ferrari"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 16, DriverName = "Charles Leclerc", Age = 23, Country = "Monaco", Team = "Ferrari"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 4, DriverName = "Lando Norris", Age = 21, Country = "United Kingdom", Team = "McLaren"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 3, DriverName = "Daniel Ricciardo", Age = 31, Country = "Australia", Team = "McLaren"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 44, DriverName = "Lewis Hamilton", Age = 36, Country = "United Kingdom", Team = "Mercedes"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 77, DriverName = "Valtteri Bottas", Age = 31, Country = "Finland", Team = "Mercedes"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 10, DriverName = "Pierre Gasly", Age = 25, Country = "France", Team = "AlphaTauri"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 22, DriverName = "Yuki Tsunoda", Age = 20, Country = "Japan", Team = "AlphaTauri"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 18, DriverName = "Lance Stroll", Age = 25, Country = "France", Team = "Aston Martin"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 5, DriverName = "Sebastian Vettal", Age = 33, Country = "Germany", Team = "Aston Martin"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 31, DriverName = "Esteban Ocon", Age = 24, Country = "France", Team = "Alpine"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 14, DriverName = "Fernando Alonso", Age = 39, Country = "Spain", Team = "Alpine"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 7, DriverName = "Kimi Räikkönen", Age = 41, Country = "Finland", Team = "Alfa Romeo Racing"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 99, DriverName = "Antonio Giovinazzi", Age = 27, Country = "Italy", Team = "Alfa Romeo Racing"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 6, DriverName = "Nicholas Latifi", Age = 25, Country = "Canada", Team = "Williams"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 63, DriverName = "Goerge Russel", Age = 23, Country = "United Kingdom", Team = "Williams"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 47, DriverName = "Mick Schumacher", Age = 22, Country = "Germany", Team = "Haas F1 Team"});
            // modelBuilder.Entity<Drivers>().HasData(new Drivers(){DriverId = Guid.NewGuid(), Number = 9, DriverName = "Nikita Mazepin", Age = 22, Country = "Russia", Team = "Haas F1 Team"});

            var maxVerstappen = new Driver(){DriverId = 33, DriverName = "Max Verstappen", Age = 23, Country = "Netherlands", Team = "Red Bull Racing"};
            var carlosSainz = new Driver(){DriverId = 55, DriverName = "Carlos Sainz", Age = 26, Country = "Spain", Team = "Ferrari"};
            var charlesLeclerc = new Driver(){DriverId = 16, DriverName = "Charles Leclerc", Age = 23, Country = "Monaco", Team = "Ferrari"};
            var landoNorris = new Driver(){DriverId = 4, DriverName = "Lando Norris", Age = 21, Country = "United Kingdom", Team = "McLaren"};
            var danielRicciardo = new Driver(){DriverId = 3, DriverName = "Daniel Ricciardo", Age = 31, Country = "Australia", Team = "McLaren"};
            var lewisHamilton = new Driver(){DriverId = 44, DriverName = "Lewis Hamilton", Age = 36, Country = "United Kingdom", Team = "Mercedes"};
            var valtteriBottas = new Driver(){DriverId = 77, DriverName = "Valtteri Bottas", Age = 31, Country = "Finland", Team = "Mercedes"};
            var pierreGasly = new Driver(){DriverId = 10, DriverName = "Pierre Gasly", Age = 25, Country = "France", Team = "AlphaTauri"};
            var yukiTsunoda = new Driver(){DriverId = 22, DriverName = "Yuki Tsunoda", Age = 20, Country = "Japan", Team = "AlphaTauri"};
            var lanceStroll = new Driver(){DriverId = 18, DriverName = "Lance Stroll", Age = 25, Country = "France", Team = "Aston Martin"};
            var sebastianVettel = new Driver(){DriverId = 5, DriverName = "Sebastian Vettal", Age = 33, Country = "Germany", Team = "Aston Martin"};
            var estebanOcon = new Driver(){DriverId = 31, DriverName = "Esteban Ocon", Age = 24, Country = "France", Team = "Alpine"};
            var fernandoAlonse = new Driver(){DriverId = 14, DriverName = "Fernando Alonso", Age = 39, Country = "Spain", Team = "Alpine"};
            var kimiRaikkonen = new Driver(){DriverId = 7, DriverName = "Kimi Räikkönen", Age = 41, Country = "Finland", Team = "Alfa Romeo Racing"};
            var antonioGiovinazzi = new Driver(){DriverId = 99, DriverName = "Antonio Giovinazzi", Age = 27, Country = "Italy", Team = "Alfa Romeo Racing"};
            var nacholasLatifi = new Driver(){DriverId = 6, DriverName = "Nicholas Latifi", Age = 25, Country = "Canada", Team = "Williams"};
            var georgeRussel = new Driver(){DriverId = 63, DriverName = "Goerge Russel", Age = 23, Country = "United Kingdom", Team = "Williams"};
            var mickSchumacher = new Driver(){DriverId = 47, DriverName = "Mick Schumacher", Age = 22, Country = "Germany", Team = "Haas F1 Team"};
            var nikitaMazepin = new Driver(){DriverId = 9, DriverName = "Nikita Mazepin", Age = 22, Country = "Russia", Team = "Haas F1 Team"};
            var sergioPerez = new Driver(){DriverId = 11, DriverName = "Sergio Perez", Age = 31, Country = "Mexico", Team = "Red Bull Racing"};

            modelBuilder.Entity<Driver>().HasData(maxVerstappen, carlosSainz, charlesLeclerc, landoNorris, danielRicciardo, lewisHamilton, valtteriBottas, pierreGasly, yukiTsunoda, lanceStroll, sebastianVettel, estebanOcon, fernandoAlonse, kimiRaikkonen, antonioGiovinazzi, nacholasLatifi, georgeRussel, mickSchumacher, nikitaMazepin, sergioPerez);

            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "albertPark", CircuitName = "Albert Park", Country = "Australia", Url= "https://f1-circuits.nl/albert-park/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "shanghai", CircuitName = "Shanghai International Circuit", Country = "China", Url= "https://f1-circuits.nl/shanghai/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "bahrain", CircuitName = "Bahrain International Circuit", Country = "Bahrain", Url= "https://f1-circuits.nl/bahrain/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "sochi", CircuitName = "Sochi Autodrom", Country = "Russia", Url= "https://f1-circuits.nl/sochi/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "barcelonaCatalunya", CircuitName = "Circuit de Barcelona-Catalunya", Country = "Spain", Url= "https://f1-circuits.nl/barcelona/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "Monaco", CircuitName = "Circuit de Monaco", Country = "Monaco", Url= "https://f1-circuits.nl/monaco/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "gillesVilleneuve", CircuitName = "Circuit Gilles Villeneuve", Country = "Canada", Url= "https://f1-circuits.nl/gilles-villeneuve/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "baku", CircuitName = "Baku City Circuit", Country = "Azerbeidzjan", Url= "https://f1-circuits.nl/baku/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "redBullRing", CircuitName = "Red Bull Ring", Country = "Austria", Url= "https://f1-circuits.nl/red-bull-ring/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "Silverstone", CircuitName = "Silverstone", Country = "United Kingdom", Url= "https://f1-circuits.nl/silverstone/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "Hungaroring", CircuitName = "Hungaroring", Country = "Hungary", Url= "https://f1-circuits.nl/hungaroring/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "spaFrancorchamps", CircuitName = "Circuit Spa-Francorchamps", Country = "Belgium", Url= "https://f1-circuits.nl/spa-francorchamps/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "monza", CircuitName = "Autodromo Nazionale Monza", Country = "Italy", Url= "https://f1-circuits.nl/monza/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "marinaBay", CircuitName = "Marina Bay Circuit", Country = "Singapore", Url= "https://f1-circuits.nl/marina-bay/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "sepang", CircuitName = "Sepang International Circuit", Country = "Malaysia", Url= "https://f1-circuits.nl/sepang/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "suzuka", CircuitName = "Suzuka", Country = "Japan", Url= "https://f1-circuits.nl/suzuka/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "hermanosRodriguez", CircuitName = "Autódromo Hermanos Rodríguez", Country = "Mexico", Url= "https://f1-circuits.nl/mexico/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "americas", CircuitName = "Circuit of the Americas", Country = "United States", Url= "https://f1-circuits.nl/americas/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "interlagos", CircuitName = "Interlagos", Country = "Brazil", Url= "https://f1-circuits.nl/interlagos/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "yasMarina", CircuitName = "Yas Marina Circuit", Country = "United Arab Emirates", Url= "https://f1-circuits.nl/yas-marina/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "paulRicard", CircuitName = "Paul Ricard", Country = "France", Url= "https://f1-circuits.nl/paul-ricard/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "hockendHeimring", CircuitName = "Hockendheimring", Country = "Germany", Url= "https://f1-circuits.nl/hockenheim/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "zandvoort", CircuitName = "Zandvoort", Country = "The Netherlands", Url= "https://f1-circuits.nl/zandvoort/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "vietnam", CircuitName = "Vietnam", Country = "Vietnam", Url= "https://f1-circuits.nl/vietnam/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "mugello", CircuitName = "Mugello Circuit", Country = "Italy", Url= "https://f1-circuits.nl/mugello/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "nurburging", CircuitName = "Nürburging", Country = "Germany", Url= "https://f1-circuits.nl/nurburgring/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "ferrari", CircuitName = "Autodromo Enzo e Dino Ferrari", Country = "Italy", Url= "https://f1-circuits.nl/imola/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "algarve", CircuitName = "Autodromo Internacional do Algarve", Country = "Portugal", Url= "https://f1-circuits.nl/algarve/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "istanbul", CircuitName = "Istanbul Park", Country = "Turkey", Url= "https://f1-circuits.nl/istanbul-park/"});
            modelBuilder.Entity<Circuit>().HasData(new Circuit(){CircuitId = "jeddah", CircuitName = "Jeddah Street Circuit", Country = "Saudi Arabia", Url= "https://f1-circuits.nl/jeddah-street/"});

            modelBuilder.Entity<Team>().HasData(new Team(){TeamId = 1, TeamName = "Redd Bull Racing"});
            modelBuilder.Entity<Team>().HasData(new Team(){TeamId = 2, TeamName = "Ferrari"});
            modelBuilder.Entity<Team>().HasData(new Team(){TeamId = 3, TeamName = "Mercedes"});
            modelBuilder.Entity<Team>().HasData(new Team(){TeamId = 4, TeamName = "McLaren"});
            modelBuilder.Entity<Team>().HasData(new Team(){TeamId = 5, TeamName = "Haas F1 Team"});
            modelBuilder.Entity<Team>().HasData(new Team(){TeamId = 6, TeamName = "Williams"});
            modelBuilder.Entity<Team>().HasData(new Team(){TeamId = 7, TeamName = "AlphaTauri"});
            modelBuilder.Entity<Team>().HasData(new Team(){TeamId = 8, TeamName = "Alpine"});
            modelBuilder.Entity<Team>().HasData(new Team(){TeamId = 9, TeamName = "Alfa Romeo Racing"});
            modelBuilder.Entity<Team>().HasData(new Team(){TeamId = 10, TeamName = "Aston Martin"});


            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 1, DriverId = 44, Points = 44});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 2, DriverId = 33, Points = 43});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 3, DriverId = 4, Points = 27});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 4, DriverId = 16, Points = 20});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 5, DriverId = 77, Points = 16});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 6, DriverId = 55, Points = 14});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 7, DriverId = 3, Points = 14});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 8, DriverId = 11, Points = 10});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 9, DriverId = 10, Points = 6});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 10, DriverId = 18, Points = 5});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 11, DriverId = 22, Points = 2});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 12, DriverId = 31, Points = 2});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 13, DriverId = 14, Points = 1});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 14, DriverId = 7, Points = 0});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 15, DriverId = 99, Points = 0});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 16, DriverId = 63, Points = 0});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 17, DriverId = 5, Points = 0});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 18, DriverId = 47, Points = 0});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 19, DriverId = 9, Points = 0});
            modelBuilder.Entity<Ranking>().HasData(new Ranking(){Place = 20, DriverId = 6, Points = 0});

            // modelBuilder.Entity<List<TeamDrivers>>().HasData(new List<TeamDrivers>(){TeamId = Guid.NewGuid(), TeamName = "Aston Martin"});
        }
    }
}
