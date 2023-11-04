using System;
using System.Text.Json.Serialization;

namespace Application.Commands.Dto
{
    public class SearchFlightDto
    {
        public string access_key { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public string flight_status { get; set; }
        public DateTime? flightDate { get; set; }
        public string flight_date { 
            get
            {
                if (flightDate.HasValue && flightDate != DateTime.MinValue)
                    return flightDate.Value.ToString("yyyy-MM-dd");
                return null;
            }
        }
        public string dep_iata { get; set; }
        public string arr_iata { get; set; }
        public string dep_icao { get; set; }
        public string arr_icao { get; set; }
        public string airline_name { get; set; }
        public string airline_iata { get; set; }
        public string airline_icao { get; set; }
        public string flight_number { get; set; }
        public string flight_iata { get; set; }
        public string flight_icao { get; set; }
    }
}