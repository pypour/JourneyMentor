using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Flights
{
    public class Flight
    {
        [Key]
        public long Id { get; set; }

        public DateOnly FlightDate { get; set; }

        public string FlightStatus { get; set; }

        [ForeignKey("DepartureFlightId")]
        public AirportInfo Departure { get; set; }

        [ForeignKey("ArrivalFlightId")]
        public AirportInfo Arrival { get; set; }

        public Airline Airline { get; set; }

        [ForeignKey("FlightInfoFlightId")]
        public FlightInfo FlightInfo { get; set; }

        public Aircraft Aircraft { get; set; }

        [ForeignKey("LiveFlightId")]
        public LiveInfo Live { get; set; }
    }
}
