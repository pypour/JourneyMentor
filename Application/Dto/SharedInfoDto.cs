﻿using System.Text.Json.Serialization;

namespace Application.Commands.Dto
{
    public class SharedInfoDto
    {
        [JsonPropertyName("airline_name")]
        public string AirlineName { get; set; }

        [JsonPropertyName("airline_iata")]
        public string AirlineIata { get; set; }

        [JsonPropertyName("airline_icao")]
        public string AirlineIcao { get; set; }

        [JsonPropertyName("flight_number")]
        public string FlightNumber { get; set; }

        [JsonPropertyName("flight_iata")]
        public string FlightIata { get; set; }

        [JsonPropertyName("flight_icao")]
        public string FlightIcao { get; set; }
    }
}