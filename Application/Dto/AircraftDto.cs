using System.Text.Json.Serialization;

namespace Application.Commands.Dto
{
    public class AircraftDto
    {
        [JsonPropertyName("registration")]
        public string Registration { get; set; }

        [JsonPropertyName("iata")]
        public string Iata { get; set; }

        [JsonPropertyName("icao")]
        public string Icao { get; set; }

        [JsonPropertyName("icao24")]
        public string Icao24 { get; set; }
    }
}