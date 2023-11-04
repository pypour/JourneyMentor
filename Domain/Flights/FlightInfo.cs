using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Flights
{
    public class FlightInfo
    {
        [Key]
        public long FlightId { get; set; }
        public string Number { get; set; }
        public string Iata { get; set; }
        public string Icao { get; set; }
        public SharedInfo Codeshared { get; set; }
    }
}
