using System;
namespace VehicleDataApp.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
        }
        public string APIResponse { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public string Style { get; set; }
        public string Engine { get; set; }
        public string CityMileage { get; set; }
        public string HighwayMileage { get; set; }
        public string CurbWeight { get; set; }
        public string Icon { get; set; }
        public string VIN { get; set; }
    }
}
