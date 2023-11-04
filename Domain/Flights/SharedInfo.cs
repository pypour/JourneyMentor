using System.ComponentModel.DataAnnotations;

namespace Domain.Flights
{
    public class SharedInfo
    {
        [Key]
        public long FlightId { get; set; }
        public string AirlineName { get; set; }
        public string AirlineIata { get; set; }
        public string AirlineIcao { get; set; }
        public string FlightNumber { get; set; }
        public string FlightIata { get; set; }
        public string FlightIcao { get; set; }
    }
}
