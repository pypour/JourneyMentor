using System;
using System.Text.Json.Serialization;

namespace Application.Commands.Dto
{
    public class LiveInfoDto
    {
        [JsonPropertyName("updated")]
        public DateTime Updated { get; set; }

        [JsonPropertyName("latitude")]
        public decimal? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public decimal? Longitude { get; set; }

        [JsonPropertyName("altitude")]
        public decimal? Altitude { get; set; }

        [JsonPropertyName("direction")]
        public decimal? Direction { get; set; }

        [JsonPropertyName("speed_horizontal")]
        public decimal? SpeedHorizontal { get; set; }

        [JsonPropertyName("speed_vertical")]
        public decimal? SpeedVertical { get; set; }

        [JsonPropertyName("is_ground")]
        public bool? IsGround { get; set; }
    }
}