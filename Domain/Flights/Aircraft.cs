using System.ComponentModel.DataAnnotations;

namespace Domain.Flights
{
    public class Aircraft
    {
        public string Registration { get; set; }
        [Key]
        public string Iata { get; set; }
        public string Icao { get; set; }
        public string Icao24 { get; set; }
    }
}
