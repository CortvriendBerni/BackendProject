using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula1.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Circuits",
                columns: table => new
                {
                    CircuitId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CircuitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circuits", x => x.CircuitId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                    table.ForeignKey(
                        name: "FK_Drivers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverCircuits",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    CircuitId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverCircuits", x => new { x.DriverId, x.CircuitId });
                    table.ForeignKey(
                        name: "FK_DriverCircuits_Circuits_CircuitId",
                        column: x => x.CircuitId,
                        principalTable: "Circuits",
                        principalColumn: "CircuitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverCircuits_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ranking",
                columns: table => new
                {
                    Place = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranking", x => x.Place);
                    table.ForeignKey(
                        name: "FK_Ranking_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Circuits",
                columns: new[] { "CircuitId", "CircuitName", "Country", "Url" },
                values: new object[,]
                {
                    { "albertPark", "Albert Park", "Australia", "https://f1-circuits.nl/albert-park/" },
                    { "jeddah", "Jeddah Street Circuit", "Saudi Arabia", "https://f1-circuits.nl/jeddah-street/" },
                    { "istanbul", "Istanbul Park", "Turkey", "https://f1-circuits.nl/istanbul-park/" },
                    { "algarve", "Autodromo Internacional do Algarve", "Portugal", "https://f1-circuits.nl/algarve/" },
                    { "ferrari", "Autodromo Enzo e Dino Ferrari", "Italy", "https://f1-circuits.nl/imola/" },
                    { "nurburging", "Nürburging", "Germany", "https://f1-circuits.nl/nurburgring/" },
                    { "mugello", "Mugello Circuit", "Italy", "https://f1-circuits.nl/mugello/" },
                    { "vietnam", "Vietnam", "Vietnam", "https://f1-circuits.nl/vietnam/" },
                    { "zandvoort", "Zandvoort", "The Netherlands", "https://f1-circuits.nl/zandvoort/" },
                    { "hockendHeimring", "Hockendheimring", "Germany", "https://f1-circuits.nl/hockenheim/" },
                    { "paulRicard", "Paul Ricard", "France", "https://f1-circuits.nl/paul-ricard/" },
                    { "interlagos", "Interlagos", "Brazil", "https://f1-circuits.nl/interlagos/" },
                    { "americas", "Circuit of the Americas", "United States", "https://f1-circuits.nl/americas/" },
                    { "hermanosRodriguez", "Autódromo Hermanos Rodríguez", "Mexico", "https://f1-circuits.nl/mexico/" },
                    { "suzuka", "Suzuka", "Japan", "https://f1-circuits.nl/suzuka/" },
                    { "yasMarina", "Yas Marina Circuit", "United Arab Emirates", "https://f1-circuits.nl/yas-marina/" },
                    { "marinaBay", "Marina Bay Circuit", "Singapore", "https://f1-circuits.nl/marina-bay/" },
                    { "shanghai", "Shanghai International Circuit", "China", "https://f1-circuits.nl/shanghai/" },
                    { "bahrain", "Bahrain International Circuit", "Bahrain", "https://f1-circuits.nl/bahrain/" },
                    { "sepang", "Sepang International Circuit", "Malaysia", "https://f1-circuits.nl/sepang/" },
                    { "barcelonaCatalunya", "Circuit de Barcelona-Catalunya", "Spain", "https://f1-circuits.nl/barcelona/" },
                    { "monaco", "Circuit de Monaco", "Monaco", "https://f1-circuits.nl/monaco/" },
                    { "gillesVilleneuve", "Circuit Gilles Villeneuve", "Canada", "https://f1-circuits.nl/gilles-villeneuve/" },
                    { "sochi", "Sochi Autodrom", "Russia", "https://f1-circuits.nl/sochi/" },
                    { "redBullRing", "Red Bull Ring", "Austria", "https://f1-circuits.nl/red-bull-ring/" },
                    { "silverstone", "Silverstone", "United Kingdom", "https://f1-circuits.nl/silverstone/" },
                    { "hungaroring", "Hungaroring", "Hungary", "https://f1-circuits.nl/hungaroring/" },
                    { "spaFrancorchamps", "Circuit Spa-Francorchamps", "Belgium", "https://f1-circuits.nl/spa-francorchamps/" },
                    { "monza", "Autodromo Nazionale Monza", "Italy", "https://f1-circuits.nl/monza/" },
                    { "baku", "Baku City Circuit", "Azerbeidzjan", "https://f1-circuits.nl/baku/" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "TeamName" },
                values: new object[,]
                {
                    { 9, "Alfa Romeo Racing" },
                    { 1, "Redd Bull Racing" },
                    { 2, "Ferrari" },
                    { 3, "Mercedes" },
                    { 4, "McLaren" },
                    { 5, "Haas F1 Team" },
                    { 6, "Williams" },
                    { 7, "AlphaTauri" },
                    { 8, "Alpine" },
                    { 10, "Aston Martin" }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverId", "Age", "Country", "DriverName", "TeamId" },
                values: new object[,]
                {
                    { 33, 23, "Netherlands", "Max Verstappen", 1 },
                    { 99, 27, "Italy", "Antonio Giovinazzi", 9 },
                    { 7, 41, "Finland", "Kimi Räikkönen", 9 },
                    { 14, 39, "Spain", "Fernando Alonso", 8 },
                    { 31, 24, "France", "Esteban Ocon", 8 },
                    { 22, 20, "Japan", "Yuki Tsunoda", 7 },
                    { 10, 25, "France", "Pierre Gasly", 7 },
                    { 63, 23, "United Kingdom", "George Russel", 6 },
                    { 6, 25, "Canada", "Nicholas Latifi", 6 },
                    { 9, 22, "Russia", "Nikita Mazepin", 5 },
                    { 47, 22, "Germany", "Mick Schumacher", 5 },
                    { 3, 31, "Australia", "Daniel Ricciardo", 4 },
                    { 4, 21, "United Kingdom", "Lando Norris", 4 },
                    { 77, 31, "Finland", "Valtteri Bottas", 3 },
                    { 44, 36, "United Kingdom", "Lewis Hamilton", 3 },
                    { 16, 23, "Monaco", "Charles Leclerc", 2 },
                    { 55, 26, "Spain", "Carlos Sainz", 2 },
                    { 11, 31, "Mexico", "Sergio Perez", 1 },
                    { 18, 25, "France", "Lance Stroll", 10 },
                    { 5, 33, "Germany", "Sebastian Vettal", 10 }
                });

            migrationBuilder.InsertData(
                table: "DriverCircuits",
                columns: new[] { "CircuitId", "DriverId" },
                values: new object[,]
                {
                    { "spaFrancorchamps", 33 },
                    { "monaco", 47 },
                    { "bahrain", 47 },
                    { "mugello", 7 },
                    { "hermanosRodriguez", 9 },
                    { "zandvoort", 9 },
                    { "suzuka", 5 },
                    { "spaFrancorchamps", 6 },
                    { "monaco", 6 },
                    { "vietnam", 7 },
                    { "bahrain", 63 },
                    { "monza", 63 },
                    { "suzuka", 10 },
                    { "bahrain", 10 },
                    { "spaFrancorchamps", 14 },
                    { "sepang", 22 },
                    { "interlagos", 22 },
                    { "suzuka", 14 },
                    { "monaco", 3 },
                    { "interlagos", 31 },
                    { "silverstone", 3 },
                    { "monaco", 4 },
                    { "marinaBay", 33 },
                    { "spaFrancorchamps", 5 },
                    { "silverstone", 11 },
                    { "zandvoort", 11 },
                    { "marinaBay", 55 },
                    { "silverstone", 55 },
                    { "monza", 18 },
                    { "algarve", 99 },
                    { "monaco", 16 },
                    { "albertPark", 16 },
                    { "monaco", 44 },
                    { "americas", 44 },
                    { "monza", 77 },
                    { "bahrain", 77 },
                    { "vietnam", 99 },
                    { "spaFrancorchamps", 4 },
                    { "nurburging", 18 },
                    { "marinaBay", 31 }
                });

            migrationBuilder.InsertData(
                table: "Ranking",
                columns: new[] { "Place", "DriverId", "Points" },
                values: new object[,]
                {
                    { 15, 99, 0 },
                    { 13, 14, 1 }
                });

            migrationBuilder.InsertData(
                table: "Ranking",
                columns: new[] { "Place", "DriverId", "Points" },
                values: new object[,]
                {
                    { 10, 18, 5 },
                    { 14, 7, 0 },
                    { 19, 9, 0 },
                    { 11, 22, 2 },
                    { 9, 10, 6 },
                    { 16, 63, 0 },
                    { 20, 6, 0 },
                    { 18, 47, 0 },
                    { 7, 3, 14 },
                    { 3, 4, 27 },
                    { 5, 77, 16 },
                    { 1, 44, 44 },
                    { 4, 16, 20 },
                    { 6, 55, 14 },
                    { 8, 11, 10 },
                    { 2, 33, 43 },
                    { 12, 31, 2 },
                    { 17, 5, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverCircuits_CircuitId",
                table: "DriverCircuits",
                column: "CircuitId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_TeamId",
                table: "Drivers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_DriverId",
                table: "Ranking",
                column: "DriverId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverCircuits");

            migrationBuilder.DropTable(
                name: "Ranking");

            migrationBuilder.DropTable(
                name: "Circuits");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
