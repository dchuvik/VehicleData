using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleDataApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleDataApp.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleRepo repo;

        public VehicleController(IVehicleRepo vehicleRepo)
        {
            this.repo = vehicleRepo;
        }

        // GET: /<controller>/
        public IActionResult Index(string VIN)
        {
            var vehicle = new Vehicle();

            if (VIN == null)
            {
                return View(vehicle);
            }
            try
            {
                vehicle = repo.GetAPIResponse(VIN);
            }
            catch (AggregateException)
            {
                return RedirectToAction("Index", "Vehicle");
            }

            return View(vehicle);
        }

        public IActionResult Weather(string VIN)
        {
            var vehicle = new Vehicle();

            if (VIN == null)
            {
                return View(vehicle);
            }

            vehicle = repo.GetAPIResponse(VIN);

            return View(vehicle);
        }
    }
}
