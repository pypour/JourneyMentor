using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    Iata = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Registration = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icao24 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.Iata);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Airline",
                columns: table => new
                {
                    Iata = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.Iata);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AirportInfo",
                columns: table => new
                {
                    FlightId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Airport = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Timezone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Iata = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Terminal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Delay = table.Column<int>(type: "int", nullable: true),
                    Scheduled = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Estimated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Actual = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EstimatedRunway = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ActualRunway = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportInfo", x => x.FlightId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IATACode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ICAOCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Latitude = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Longitude = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GeoId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TimeZone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GMT = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryISOCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CityIATACode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LiveInfo",
                columns: table => new
                {
                    FlightId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Altitude = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Direction = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    SpeedHorizontal = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    SpeedVertical = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    IsGround = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveInfo", x => x.FlightId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SharedInfo",
                columns: table => new
                {
                    FlightId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AirlineName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AirlineIata = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AirlineIcao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlightNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlightIata = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlightIcao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedInfo", x => x.FlightId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FlightInfo",
                columns: table => new
                {
                    FlightId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Iata = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodesharedFlightId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightInfo", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_FlightInfo_SharedInfo_CodesharedFlightId",
                        column: x => x.CodesharedFlightId,
                        principalTable: "SharedInfo",
                        principalColumn: "FlightId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FlightDate = table.Column<DateOnly>(type: "date", nullable: false),
                    FlightStatus = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepartureFlightId = table.Column<long>(type: "bigint", nullable: true),
                    ArrivalFlightId = table.Column<long>(type: "bigint", nullable: true),
                    AirlineIata = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlightInfoFlightId = table.Column<long>(type: "bigint", nullable: true),
                    AircraftIata = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LiveFlightId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Aircraft_AircraftIata",
                        column: x => x.AircraftIata,
                        principalTable: "Aircraft",
                        principalColumn: "Iata");
                    table.ForeignKey(
                        name: "FK_Flights_Airline_AirlineIata",
                        column: x => x.AirlineIata,
                        principalTable: "Airline",
                        principalColumn: "Iata");
                    table.ForeignKey(
                        name: "FK_Flights_AirportInfo_ArrivalFlightId",
                        column: x => x.ArrivalFlightId,
                        principalTable: "AirportInfo",
                        principalColumn: "FlightId");
                    table.ForeignKey(
                        name: "FK_Flights_AirportInfo_DepartureFlightId",
                        column: x => x.DepartureFlightId,
                        principalTable: "AirportInfo",
                        principalColumn: "FlightId");
                    table.ForeignKey(
                        name: "FK_Flights_FlightInfo_FlightInfoFlightId",
                        column: x => x.FlightInfoFlightId,
                        principalTable: "FlightInfo",
                        principalColumn: "FlightId");
                    table.ForeignKey(
                        name: "FK_Flights_LiveInfo_LiveFlightId",
                        column: x => x.LiveFlightId,
                        principalTable: "LiveInfo",
                        principalColumn: "FlightId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FlightInfo_CodesharedFlightId",
                table: "FlightInfo",
                column: "CodesharedFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AircraftIata",
                table: "Flights",
                column: "AircraftIata");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirlineIata",
                table: "Flights",
                column: "AirlineIata");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ArrivalFlightId",
                table: "Flights",
                column: "ArrivalFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DepartureFlightId",
                table: "Flights",
                column: "DepartureFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FlightInfoFlightId",
                table: "Flights",
                column: "FlightInfoFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_LiveFlightId",
                table: "Flights",
                column: "LiveFlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "Airline");

            migrationBuilder.DropTable(
                name: "AirportInfo");

            migrationBuilder.DropTable(
                name: "FlightInfo");

            migrationBuilder.DropTable(
                name: "LiveInfo");

            migrationBuilder.DropTable(
                name: "SharedInfo");
        }
    }
}
