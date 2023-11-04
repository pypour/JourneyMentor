using System.Text.Json.Serialization;

namespace Application.Commands.Dto
{
    public class AirportDto
    {
        [JsonPropertyName("airport_name")]
        public string Name { get; set; }

        [JsonPropertyName("iata_code")]
        public string IATACode { get; set; }

        [JsonPropertyName("icao_code")]
        public string ICAOCode { get; set; }

        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }

        [JsonPropertyName("geoname_id")]
        public string GeoId { get; set; }

        [JsonPropertyName("timezone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("gmt")]
        public string GMT { get; set; }

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("country_name")]
        public string Country { get; set; }

        [JsonPropertyName("country_iso2")]
        public string CountryISOCode { get; set; }

        [JsonPropertyName("city_iata_code")]
        public string CityIATACode { get; set; }
    }
}