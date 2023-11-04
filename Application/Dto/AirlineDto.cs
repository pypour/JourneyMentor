using System.Text.Json.Serialization;

namespace Application.Commands.Dto
{
    public class AirlineDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("iata")]
        public string Iata { get; set; }

        [JsonPropertyName("icao")]
        public string Icao { get; set; }
    }
}