using System.ComponentModel.DataAnnotations;

namespace Domain.Flights
{
    public class Airline
    {
        public string Name { get; set; }
        [Key]
        public string Iata { get; set; }
        public string Icao { get; set; }
    }
}
