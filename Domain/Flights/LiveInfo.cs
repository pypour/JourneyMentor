using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Flights
{
    public class LiveInfo
    {
        [Key]
        public long FlightId { get; set; }
        public DateTime Updated { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Altitude { get; set; }
        public decimal? Direction { get; set; }
        public decimal? SpeedHorizontal { get; set; }
        public decimal? SpeedVertical { get; set; }
        public bool? IsGround { get; set; }
    }
}
