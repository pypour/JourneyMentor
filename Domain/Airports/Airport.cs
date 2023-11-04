using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Airports
{
    public class Airport
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string IATACode { get; set; }
        public string ICAOCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string GeoId { get; set; }
        public string TimeZone { get; set; }
        public string GMT { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string CountryISOCode { get; set; }
        public string CityIATACode { get; set; }
    }
}
