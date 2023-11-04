using System;
using System.Text.Json.Serialization;

namespace Application.Commands.Dto
{
    public class FlightDto
    {
        [JsonPropertyName("flight_date")]
        public DateOnly FlightDate { get; set; }
        
        [JsonPropertyName("flight_status")]
        public string FlightStatus { get; set; }
        
        [JsonPropertyName("departure")]
        public AirportInfoDto Departure { get; set; }
        
        [JsonPropertyName("arrival")]
        public AirportInfoDto Arrival { get; set; }
        
        [JsonPropertyName("airline")]
        public AirlineDto Airline { get; set; }
        
        [JsonPropertyName("flight")]
        public FlightInfoDto FlightInfo { get; set; }
        
        [JsonPropertyName("aircraft")]
        public AircraftDto Aircraft { get; set; }
        
        [JsonPropertyName("live")]
        public LiveInfoDto Live { get; set; }
    }
}