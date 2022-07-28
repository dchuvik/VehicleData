using System;
using VehicleDataApp.Models;

namespace VehicleDataApp
{
    public interface IVehicleRepo
    {
        public Vehicle GetAPIResponse(string VIN);
    }
}
