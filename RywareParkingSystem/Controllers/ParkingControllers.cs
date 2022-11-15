using Microsoft.AspNetCore.Mvc;
using RywareParkingSystem.Converter;
using RywareParkingSystem.DAL.Entities;
using RywareParkingSystem.DAL.Repository;
using RywareParkingSystem.Models;

namespace RywareParkingSystem.Controllers
{
    [ApiController]
    [Route("parkings")]
    public class ParkingControllers : ControllerBase
    {
        private readonly IRepository repository;

        public ParkingControllers(IRepository repository)
        {
            this.repository = repository;
        }

        // GET /parkings
        [HttpGet("{address}")]
        public async Task<IEnumerable<Parking>> GetParkingsByAddress(string address)
        {
            var parkingDbModels = await repository.GetParkings(address);
            var parkings = ParkingConverter.ConvertToModelList(parkingDbModels);
            return parkings;
        }

        // POST /parkings
        [HttpPost]
        public async Task<ActionResult<ParkingDatabaseModel>> AddNewParking(ParkingDatabaseModel parking)
        {
            await repository.AddNewParking(parking);
            return NoContent();
        }

        // PUT /parkings
        [HttpPut("{id}")]
        public async Task<ActionResult> DisableParkingMeter(Guid id) 
        {
            await repository.DisableParkingCounter(id);
            return NoContent();
        }

        // PUT /usages
        [HttpPut("/usages/{id}")]
        public async Task<ActionResult> UpdateUsages(Guid id, TimeSpan time)
        {
            await repository.UpdatedUsages(id, time);
            return NoContent();
        }
    }
}
