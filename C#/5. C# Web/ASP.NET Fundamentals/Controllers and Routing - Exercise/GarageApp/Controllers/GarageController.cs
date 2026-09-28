using Microsoft.AspNetCore.Mvc;

using GarageApp.Data;
using GarageApp.Data.Models;
using static GarageApp.Common.ApplicationConstants;
using Microsoft.EntityFrameworkCore;

namespace GarageApp.Controllers
{
    public class GarageController : Controller
    {
        private readonly GarageAppDbContext _dbContext;

        public GarageController(GarageAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Garage> garages = _dbContext.Garages
                .Include(g => g.Cars)
                .OrderBy(g => g.Name)
                .ThenBy(g => g.Location)
                .Take(MaxEntitiesPerPage)
                .ToArray();

            return View(garages);
        }

        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest("There was a problem with your request! Try again!");
            }

            Garage? garageDetails = _dbContext.Garages
                .Include(g => g.Cars)
                .SingleOrDefault(g => g.Id == id);
            if (garageDetails == null)
            {
                return NotFound("The garage was not found! Try again!");
            }

            return View(garageDetails);
        }
    }
}
