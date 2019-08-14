using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using VehicleApplication.Models;


namespace VehicleApplication.Controllers
{
    public class VehicleController : Controller
    {
        private ApplicationDbContext _dbContext;

        public VehicleController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        // GET: Vehicle
       
        public ActionResult Index(string searching, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
           
            var vehicles = from v in _dbContext.Vehicles.Include(v => v.MarkaNaVozilo)
                           select v;
            if (!String.IsNullOrEmpty(searching))
            {
                vehicles = vehicles.Where(v => v.MarkaNaVozilo.ModelName.Contains(searching));
            }
            
            switch (sortOrder)
            {
                case "name_desc":
                    vehicles = vehicles.OrderByDescending(v=> v.MarkaNaVozilo.ModelName);
                    break;
                default:
                   vehicles= vehicles.OrderBy(v=> v.MarkaNaVozilo.ModelName);
                    break;
            }
            return View(vehicles.ToList());
        }

            public ActionResult NewVehicle()
        {
            var markaNaVozilo = _dbContext.MarkaNaVozilo.ToList();

            var viewModel = new VehicleViewModel
            {
                MarkaNaVozilo = markaNaVozilo
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateVehicle(Vehicle vehicle)
        {
            _dbContext.Vehicles.Add(vehicle);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Vehicle");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var vehicle = _dbContext.Vehicles.SingleOrDefault(v => v.Id == id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }

            var viewModel = new VehicleViewModel
            {
                Vehicle = vehicle,
                MarkaNaVozilo = _dbContext.MarkaNaVozilo.ToList()

        };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Vehicle vehicle)
        {
            var vehicleInDB = _dbContext.Vehicles.Single(v=> v.Id == vehicle.Id);
            vehicleInDB.LicencePlateNumber = vehicle.LicencePlateNumber;
            vehicleInDB.VIN = vehicle.VIN;
            vehicleInDB.MarkaNaVoziloId = vehicle.MarkaNaVoziloId;

            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Vehicle");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var vehicle = _dbContext.Vehicles.SingleOrDefault(v => v.Id == id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }

            var viewModel = new VehicleViewModel
            {
                MarkaNaVozilo = _dbContext.MarkaNaVozilo.ToList(),
                Vehicle = vehicle
            };
            return View(viewModel);
        }

       
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Vehicle vehicle)
        {
            var vehicleInDb = _dbContext.Vehicles.Single(v => v.Id == vehicle.Id);
            _dbContext.Vehicles.Remove(vehicleInDb);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Vehicle");
        }


        public ActionResult GetVehiclesToPrint()
        {
            var vehicles = _dbContext.Vehicles.Include(v => v.MarkaNaVozilo).ToList();
            return View(vehicles);
        }
        public ActionResult PrintAllVehicles()
        {
            var report = new ActionAsPdf("GetVehiclesToPrint");
            return report;
        }

        
    }
}