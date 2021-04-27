using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula1.Migrations
{
    public partial class DriversCircuits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Circuits",
                columns: table => new
                {
                    CircuitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CircuitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circuits", x => x.CircuitId);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                });

            migrationBuilder.CreateTable(
                name: "DriverCircuits",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    CircuitId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DriverId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CircuitsCircuitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverCircuits", x => new { x.DriverId, x.CircuitId });
                    table.ForeignKey(
                        name: "FK_DriverCircuits_Circuits_CircuitsCircuitId",
                        column: x => x.CircuitsCircuitId,
                        principalTable: "Circuits",
                        principalColumn: "CircuitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DriverCircuits_Drivers_DriverId1",
                        column: x => x.DriverId1,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Circuits",
                columns: new[] { "CircuitId", "CircuitName", "Country", "Url" },
                values: new object[,]
                {
                    { new Guid("30d27578-80ab-4dd6-b2aa-a4e7e37067c2"), "Albert Park", "Australia", "https://f1-circuits.nl/albert-park/" },
                    { new Guid("aa512f0b-ed92-4407-8d74-cfefccc1af2b"), "Jeddah Street Circuit", "Saudi Arabia", "https://f1-circuits.nl/jeddah-street/" },
                    { new Guid("f2a417d5-317d-49bb-9922-2985b66381cb"), "Istanbul Park", "Turkey", "https://f1-circuits.nl/istanbul-park/" },
                    { new Guid("3f4c06c5-359e-4eb4-96ad-ad71ea192389"), "Autodromo Internacional do Algarve", "Portugal", "https://f1-circuits.nl/algarve/" },
                    { new Guid("caea5ed3-0c3c-4a64-9af7-c9219387b859"), "Autodromo Enzo e Dino Ferrari", "Italy", "https://f1-circuits.nl/imola/" },
                    { new Guid("5a67f641-38ea-42c7-8f18-0a99a6a6c9b1"), "Nürburging", "Germany", "https://f1-circuits.nl/nurburgring/" },
                    { new Guid("a2d70a92-780b-4b41-a95f-dd80cbd60eee"), "Vietnam", "Vietnam", "https://f1-circuits.nl/vietnam/" },
                    { new Guid("511b3610-3e58-41ec-8e25-42690ef70d0c"), "Zandvoort", "The Netherlands", "https://f1-circuits.nl/zandvoort/" },
                    { new Guid("9e049ec8-c5c8-4ca8-a3b9-1e1d1951a6c5"), "Hockendheimring", "Germany", "https://f1-circuits.nl/hockenheim/" },
                    { new Guid("ccbf4c6d-a58e-43d1-9d7b-eb843c235cb7"), "Paul Ricard", "France", "https://f1-circuits.nl/paul-ricard/" },
                    { new Guid("d1d6b362-fc91-4830-a53c-61c0b0970f27"), "Yas Marina Circuit", "United Arab Emirates", "https://f1-circuits.nl/yas-marina/" },
                    { new Guid("5fbe7fe7-e38b-4f0e-8a73-3b851a31ea77"), "Interlagos", "Brazil", "https://f1-circuits.nl/interlagos/" },
                    { new Guid("9db91460-c226-4016-9e04-4dc6321d92d8"), "Circuit of the Americas", "United States", "https://f1-circuits.nl/americas/" },
                    { new Guid("9a04ab33-1482-458b-8040-96ee9b97ea69"), "Autódromo Hermanos Rodríguez", "Mexico", "https://f1-circuits.nl/mexico/" },
                    { new Guid("c5ebd482-54a0-4936-9543-9768a3828040"), "Suzuka", "Japan", "https://f1-circuits.nl/suzuka/" },
                    { new Guid("e319e422-61ce-482a-956c-b44a547dc8a6"), "Mugello Circuit", "Italy", "https://f1-circuits.nl/mugello/" },
                    { new Guid("7fe4f380-e76d-4975-84f0-eb74fcb74535"), "Marina Bay Circuit", "Singapore", "https://f1-circuits.nl/marina-bay/" },
                    { new Guid("49397597-d529-48e7-9421-f7a1d86a1fc6"), "Sepang International Circuit", "Malaysia", "https://f1-circuits.nl/sepang/" },
                    { new Guid("81d30bc3-427c-4058-b4eb-d114353f8da7"), "Shanghai International Circuit", "China", "https://f1-circuits.nl/shanghai/" },
                    { new Guid("5b70c730-20bc-4662-af31-7379a4cd1dae"), "Bahrain International Circuit", "Bahrain", "https://f1-circuits.nl/bahrain/" },
                    { new Guid("f70f11f4-0495-47c7-bbbb-42b0ecd3ada8"), "Circuit de Barcelona-Catalunya", "Spain", "https://f1-circuits.nl/barcelona/" },
                    { new Guid("12c84d29-3c5b-49a7-99aa-d90b75f3bf87"), "Circuit de Monaco", "Monaco", "https://f1-circuits.nl/monaco/" },
                    { new Guid("2695c543-821b-4e6b-b868-bb58e3126667"), "Circuit Gilles Villeneuve", "Canada", "https://f1-circuits.nl/gilles-villeneuve/" },
                    { new Guid("a138150b-559e-46be-90f4-7220782f9a3d"), "Sochi Autodrom", "Russia", "https://f1-circuits.nl/sochi/" },
                    { new Guid("0c2360d7-9983-41e1-88e9-25e3af946d72"), "Red Bull Ring", "Austria", "https://f1-circuits.nl/red-bull-ring/" },
                    { new Guid("91af9a94-b0b9-48f7-9d65-f392c4a7345f"), "Silverstone", "United Kingdom", "https://f1-circuits.nl/silverstone/" },
                    { new Guid("1e62e8d2-1ccc-4a83-b3a6-2c7c5d23c496"), "Hungaroring", "Hungary", "https://f1-circuits.nl/hungaroring/" },
                    { new Guid("f3b73575-8e11-4cee-b70f-4d2721d5346e"), "Circuit Spa-Francorchamps", "Belgium", "https://f1-circuits.nl/spa-francorchamps/" },
                    { new Guid("10003dc5-4c58-4d04-8c5d-044d3f12b337"), "Autodromo Nazionale Monza", "Italy", "https://f1-circuits.nl/monza/" },
                    { new Guid("ac690c2e-ff94-4057-a5aa-2c596c191637"), "Baku City Circuit", "Azerbeidzjan", "https://f1-circuits.nl/baku/" }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverId", "Age", "Country", "DriverName", "Number", "Team" },
                values: new object[,]
                {
                    { new Guid("9cf30819-004a-4490-a906-f956ab6b7ed7"), 23, "United Kingdom", "Goerge Russel", 63, "Williams" },
                    { new Guid("92a68204-818b-41dd-b25a-8b569faddb3c"), 25, "France", "Lance Stroll", 18, "Aston Martin" },
                    { new Guid("2b6319db-f75e-4a86-b35c-5db6861a0e9d"), 25, "Canada", "Nicholas Latifi", 6, "Williams" },
                    { new Guid("4bad11ff-f791-455b-a2a2-e553c35e3a94"), 27, "Italy", "Antonio Giovinazzi", 99, "Alfa Romeo Racing" },
                    { new Guid("7066bdfc-8de4-4e33-9b92-779f3412b470"), 41, "Finland", "Kimi Räikkönen", 7, "Alfa Romeo Racing" },
                    { new Guid("895a6f97-49ee-43ed-94c8-9e2154b4a0aa"), 39, "Spain", "Fernando Alonso", 14, "Alpine" },
                    { new Guid("502daf0a-1d62-4246-80c9-8b7c298179cc"), 24, "France", "Esteban Ocon", 31, "Alpine" },
                    { new Guid("cc5e055a-f2ff-4adc-be1d-ce7d79e6df63"), 33, "Germany", "Sebastian Vettal", 5, "Aston Martin" },
                    { new Guid("0c63198e-7daf-4a2d-b3b0-572f7fd2f915"), 20, "Japan", "Yuki Tsunoda", 22, "AlphaTauri" },
                    { new Guid("ce446f88-41d6-4c47-af0a-5a9b4f35e094"), 26, "Spain", "Carlos Sainz", 55, "Ferrari" },
                    { new Guid("90578227-a01b-438f-b8bd-92a0082505e4"), 31, "Finland", "Valtteri Bottas", 77, "Mercedes" },
                    { new Guid("cb2246c8-9a2c-4665-b1fb-438f87098db4"), 36, "United Kingdom", "Lewis Hamilton", 44, "Mercedes" }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverId", "Age", "Country", "DriverName", "Number", "Team" },
                values: new object[,]
                {
                    { new Guid("c541e9f9-5f17-4997-9790-fe68ac280b4c"), 31, "Australia", "Daniel Ricciardo", 3, "McLaren" },
                    { new Guid("2203e0df-1e73-49e8-8c89-cd19cf184144"), 21, "United Kingdom", "Lando Norris", 4, "McLaren" },
                    { new Guid("2c502b0d-a503-4525-81b5-da75dccf4742"), 23, "Monaco", "Charles Leclerc", 16, "Ferrari" },
                    { new Guid("1128f6f3-e6ae-4540-9a82-837a2afd7b01"), 31, "Mexico", "Sergio Perez", 11, "Red Bull Racing" },
                    { new Guid("c565a83a-8b50-4897-bed6-8aa76092e02d"), 23, "Netherlands", "Max Verstappen", 33, "Red Bull Racing" },
                    { new Guid("625617c7-1bca-4b83-b0bd-c3c9044ebf2b"), 22, "Germany", "Mick Schumacher", 47, "Haas F1 Team" },
                    { new Guid("5c133061-ba22-4679-ab9f-38427995c13d"), 25, "France", "Pierre Gasly", 10, "AlphaTauri" },
                    { new Guid("a56a648b-69d2-4e74-b01a-2c4ebd58374a"), 22, "Russia", "Nikita Mazepin", 9, "Haas F1 Team" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverCircuits_CircuitsCircuitId",
                table: "DriverCircuits",
                column: "CircuitsCircuitId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverCircuits_DriverId1",
                table: "DriverCircuits",
                column: "DriverId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverCircuits");

            migrationBuilder.DropTable(
                name: "Circuits");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
