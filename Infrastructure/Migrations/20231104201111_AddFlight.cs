using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFlight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AircraftIata",
                table: "Flights",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AirlineIata",
                table: "Flights",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateOnly>(
                name: "FlightDate",
                table: "Flights",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FlightStatus",
                table: "Flights",
                type: "longtext",
                nullable: true)
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
                    FlightId = table.Column<long>(type: "bigint", nullable: false),
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
                    Delay = table.Column<int>(type: "int", nullable: false),
                    Scheduled = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Estimated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Actual = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EstimatedRunway = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ActualRunway = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FlightId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportInfo", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_AirportInfo_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AirportInfo_Flights_FlightId1",
                        column: x => x.FlightId1,
                        principalTable: "Flights",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FlightInfo",
                columns: table => new
                {
                    FlightId = table.Column<long>(type: "bigint", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Iata = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Codeshared = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightInfo", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_FlightInfo_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LiveInfo",
                columns: table => new
                {
                    FlightId = table.Column<long>(type: "bigint", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Altitude = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Direction = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SpeedHorizontal = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SpeedVertical = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IsGround = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveInfo", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_LiveInfo_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AircraftIata",
                table: "Flights",
                column: "AircraftIata");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirlineIata",
                table: "Flights",
                column: "AirlineIata");

            migrationBuilder.CreateIndex(
                name: "IX_AirportInfo_FlightId1",
                table: "AirportInfo",
                column: "FlightId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Aircraft_AircraftIata",
                table: "Flights",
                column: "AircraftIata",
                principalTable: "Aircraft",
                principalColumn: "Iata");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airline_AirlineIata",
                table: "Flights",
                column: "AirlineIata",
                principalTable: "Airline",
                principalColumn: "Iata");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Aircraft_AircraftIata",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airline_AirlineIata",
                table: "Flights");

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

            migrationBuilder.DropIndex(
                name: "IX_Flights_AircraftIata",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_AirlineIata",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AircraftIata",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AirlineIata",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "FlightDate",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "FlightStatus",
                table: "Flights");
        }
    }
}
