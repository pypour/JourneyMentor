using Application.Commands.Dto;
using Domain.Airports;
using Domain.Flights;

namespace Application
{
    public static class Extensions
    {
        public static Airport ToModel(this AirportDto airportDto)
        {
            var airport = new Airport
            {
                Name = airportDto.Name,
                IATACode = airportDto.IATACode,
                ICAOCode = airportDto.ICAOCode,
                Latitude = airportDto.Latitude,
                Longitude = airportDto.Longitude,
                GeoId = airportDto.GeoId,
                TimeZone = airportDto.TimeZone,
                GMT = airportDto.GMT,
                PhoneNumber = airportDto.PhoneNumber,
                Country = airportDto.Country,
                CountryISOCode = airportDto.CountryISOCode,
                CityIATACode = airportDto.CityIATACode
            };

            return airport;
        }

        public static Flight ToModel(this FlightDto flightDto)
        {
            var flight = new Flight
            {
                Aircraft = flightDto.Aircraft.ToModel(),
                Airline = flightDto.Airline.ToModel(),
                Arrival = flightDto.Arrival.ToModel(),
                Departure = flightDto.Departure.ToModel(),
                FlightInfo = flightDto.FlightInfo.ToModel(),
                Live = flightDto.Live.ToModel(),
                FlightDate = flightDto.FlightDate,
                FlightStatus = flightDto.FlightStatus
            };
            return flight;
        }

        public static Aircraft ToModel(this AircraftDto aircraftDto)
        {
            if(aircraftDto == null)
                return null;

            return new Aircraft
            {
                Iata = aircraftDto.Iata,
                Icao = aircraftDto.Icao,
                Icao24 = aircraftDto.Icao24,
                Registration = aircraftDto.Registration
            };
        }

        public static Airline ToModel(this AirlineDto airlineDto)
        {
            if (airlineDto == null)
                return null;

            return new Airline
            {
                Iata = airlineDto.Iata,
                Icao = airlineDto.Icao,
                Name = airlineDto.Name,
            };
        }

        public static AirportInfo ToModel(this AirportInfoDto airportInfoDto)
        {
            if (airportInfoDto == null)
                return null;

            return new AirportInfo
            {
                Airport = airportInfoDto.Airport,
                Timezone = airportInfoDto.Timezone,
                Iata = airportInfoDto.Iata,
                Icao = airportInfoDto.Icao,
                Terminal = airportInfoDto.Terminal,
                Gate = airportInfoDto.Gate,
                Delay = airportInfoDto.Delay
            };
        }

        public static FlightInfo ToModel(this FlightInfoDto flightInfoDto)
        {
            if (flightInfoDto == null)
                return null;

            return new FlightInfo
            {
                Number = flightInfoDto.Number,
                Iata = flightInfoDto.Iata,
                Icao = flightInfoDto.Icao,
                Codeshared = flightInfoDto.Codeshared.ToModel()
            };
        }

        public static LiveInfo ToModel(this LiveInfoDto liveInfoDto)
        {
            if(liveInfoDto == null) 
                return null;

            return new LiveInfo
            {
                Updated = liveInfoDto.Updated,
                Latitude = liveInfoDto.Latitude,
                Longitude = liveInfoDto.Longitude,
                Altitude = liveInfoDto.Altitude,
                Direction = liveInfoDto.Direction,
                SpeedHorizontal = liveInfoDto.SpeedHorizontal,
                SpeedVertical = liveInfoDto.SpeedVertical,
                IsGround = liveInfoDto.IsGround
            };
        }

        public static SharedInfo ToModel(this SharedInfoDto sharedInfoDto)
        {
            if (sharedInfoDto == null)
                return null;

            return new SharedInfo
            {
                AirlineName = sharedInfoDto.AirlineName,
                AirlineIata = sharedInfoDto.AirlineIata,
                AirlineIcao = sharedInfoDto.AirlineIcao,
                FlightNumber = sharedInfoDto.FlightNumber,
                FlightIata = sharedInfoDto.FlightIata,
                FlightIcao = sharedInfoDto.FlightIcao
            };
        }
    }
}
