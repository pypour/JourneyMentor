﻿// <auto-generated />
using System;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231104205929_InitialDatabase")]
    partial class InitialDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Airports.Airport", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CityIATACode")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<string>("CountryISOCode")
                        .HasColumnType("longtext");

                    b.Property<string>("GMT")
                        .HasColumnType("longtext");

                    b.Property<string>("GeoId")
                        .HasColumnType("longtext");

                    b.Property<string>("IATACode")
                        .HasColumnType("longtext");

                    b.Property<string>("ICAOCode")
                        .HasColumnType("longtext");

                    b.Property<string>("Latitude")
                        .HasColumnType("longtext");

                    b.Property<string>("Longitude")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("TimeZone")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("Domain.Flights.Aircraft", b =>
                {
                    b.Property<string>("Iata")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Icao")
                        .HasColumnType("longtext");

                    b.Property<string>("Icao24")
                        .HasColumnType("longtext");

                    b.Property<string>("Registration")
                        .HasColumnType("longtext");

                    b.HasKey("Iata");

                    b.ToTable("Aircraft");
                });

            modelBuilder.Entity("Domain.Flights.Airline", b =>
                {
                    b.Property<string>("Iata")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Icao")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Iata");

                    b.ToTable("Airline");
                });

            modelBuilder.Entity("Domain.Flights.AirportInfo", b =>
                {
                    b.Property<long>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Actual")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ActualRunway")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Airport")
                        .HasColumnType("longtext");

                    b.Property<int?>("Delay")
                        .HasColumnType("int");

                    b.Property<DateTime>("Estimated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("EstimatedRunway")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Gate")
                        .HasColumnType("longtext");

                    b.Property<string>("Iata")
                        .HasColumnType("longtext");

                    b.Property<string>("Icao")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Scheduled")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Terminal")
                        .HasColumnType("longtext");

                    b.Property<string>("Timezone")
                        .HasColumnType("longtext");

                    b.HasKey("FlightId");

                    b.ToTable("AirportInfo");
                });

            modelBuilder.Entity("Domain.Flights.Flight", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("AircraftIata")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AirlineIata")
                        .HasColumnType("varchar(255)");

                    b.Property<long?>("ArrivalFlightId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DepartureFlightId")
                        .HasColumnType("bigint");

                    b.Property<DateOnly>("FlightDate")
                        .HasColumnType("date");

                    b.Property<long?>("FlightInfoFlightId")
                        .HasColumnType("bigint");

                    b.Property<string>("FlightStatus")
                        .HasColumnType("longtext");

                    b.Property<long?>("LiveFlightId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AircraftIata");

                    b.HasIndex("AirlineIata");

                    b.HasIndex("ArrivalFlightId");

                    b.HasIndex("DepartureFlightId");

                    b.HasIndex("FlightInfoFlightId");

                    b.HasIndex("LiveFlightId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Domain.Flights.FlightInfo", b =>
                {
                    b.Property<long>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("CodesharedFlightId")
                        .HasColumnType("bigint");

                    b.Property<string>("Iata")
                        .HasColumnType("longtext");

                    b.Property<string>("Icao")
                        .HasColumnType("longtext");

                    b.Property<string>("Number")
                        .HasColumnType("longtext");

                    b.HasKey("FlightId");

                    b.HasIndex("CodesharedFlightId");

                    b.ToTable("FlightInfo");
                });

            modelBuilder.Entity("Domain.Flights.LiveInfo", b =>
                {
                    b.Property<long>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Altitude")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("Direction")
                        .HasColumnType("decimal(65,30)");

                    b.Property<bool?>("IsGround")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal?>("Latitude")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("Longitude")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("SpeedHorizontal")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("SpeedVertical")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("FlightId");

                    b.ToTable("LiveInfo");
                });

            modelBuilder.Entity("Domain.Flights.SharedInfo", b =>
                {
                    b.Property<long>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("AirlineIata")
                        .HasColumnType("longtext");

                    b.Property<string>("AirlineIcao")
                        .HasColumnType("longtext");

                    b.Property<string>("AirlineName")
                        .HasColumnType("longtext");

                    b.Property<string>("FlightIata")
                        .HasColumnType("longtext");

                    b.Property<string>("FlightIcao")
                        .HasColumnType("longtext");

                    b.Property<string>("FlightNumber")
                        .HasColumnType("longtext");

                    b.HasKey("FlightId");

                    b.ToTable("SharedInfo");
                });

            modelBuilder.Entity("Domain.Flights.Flight", b =>
                {
                    b.HasOne("Domain.Flights.Aircraft", "Aircraft")
                        .WithMany()
                        .HasForeignKey("AircraftIata");

                    b.HasOne("Domain.Flights.Airline", "Airline")
                        .WithMany()
                        .HasForeignKey("AirlineIata");

                    b.HasOne("Domain.Flights.AirportInfo", "Arrival")
                        .WithMany()
                        .HasForeignKey("ArrivalFlightId");

                    b.HasOne("Domain.Flights.AirportInfo", "Departure")
                        .WithMany()
                        .HasForeignKey("DepartureFlightId");

                    b.HasOne("Domain.Flights.FlightInfo", "FlightInfo")
                        .WithMany()
                        .HasForeignKey("FlightInfoFlightId");

                    b.HasOne("Domain.Flights.LiveInfo", "Live")
                        .WithMany()
                        .HasForeignKey("LiveFlightId");

                    b.Navigation("Aircraft");

                    b.Navigation("Airline");

                    b.Navigation("Arrival");

                    b.Navigation("Departure");

                    b.Navigation("FlightInfo");

                    b.Navigation("Live");
                });

            modelBuilder.Entity("Domain.Flights.FlightInfo", b =>
                {
                    b.HasOne("Domain.Flights.SharedInfo", "Codeshared")
                        .WithMany()
                        .HasForeignKey("CodesharedFlightId");

                    b.Navigation("Codeshared");
                });
#pragma warning restore 612, 618
        }
    }
}
