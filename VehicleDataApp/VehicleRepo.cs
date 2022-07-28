using System;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using VehicleDataApp.Models;

namespace VehicleDataApp
{
    public class VehicleRepo : IVehicleRepo
    {
        private readonly string _conn;

        public VehicleRepo(string conn)
        {
            _conn = conn;
        }

        public Vehicle GetAPIResponse(string VIN)
        {
            var Vehicle = new Vehicle();

            var client = new HttpClient();

            var apiCall = $"http://api.carsxe.com/specs?key={_conn}&vin={VIN}";

            Vehicle.APIResponse = client.GetStringAsync(apiCall).Result;

            //Vehicle.Icon = JObject.Parse(Vehicle.APIResponse)["vehicle"][0]["icon"].ToString();
            Vehicle.VIN = JObject.Parse(Vehicle.APIResponse)["input"]["vin"].ToString();
            Vehicle.Year = int.Parse(JObject.Parse(Vehicle.APIResponse)["attributes"]["year"].ToString());
            Vehicle.Make = JObject.Parse(Vehicle.APIResponse)["attributes"]["make"].ToString();
            Vehicle.Model = JObject.Parse(Vehicle.APIResponse)["attributes"]["model"].ToString();
            Vehicle.Trim = JObject.Parse(Vehicle.APIResponse)["attributes"]["trim"].ToString();
            Vehicle.Style = JObject.Parse(Vehicle.APIResponse)["attributes"]["style"].ToString();
            Vehicle.Engine = JObject.Parse(Vehicle.APIResponse)["attributes"]["engine"].ToString();
            Vehicle.CityMileage = JObject.Parse(Vehicle.APIResponse)["attributes"]["city_mileage"].ToString();
            Vehicle.HighwayMileage = JObject.Parse(Vehicle.APIResponse)["attributes"]["highway_mileage"].ToString();
            Vehicle.CurbWeight = JObject.Parse(Vehicle.APIResponse)["attributes"]["curb_weight"].ToString();

            return Vehicle;
        }
    }
}
