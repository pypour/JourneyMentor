using System.Text.Json.Serialization;

namespace Application.Commands.Dto
{
    public class FlightInfoDto
    {
        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("iata")]
        public string Iata { get; set; }

        [JsonPropertyName("icao")]
        public string Icao { get; set; }

        [JsonPropertyName("codeshared")]
        public SharedInfoDto Codeshared { get; set; }
    }
}