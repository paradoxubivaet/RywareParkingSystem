using RywareParkingSystem.DAL.Entities;
using RywareParkingSystem.Models;

namespace RywareParkingSystem.DAL.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<ParkingDatabaseModel>> GetParkings(string address);
        Task AddNewParking(ParkingDatabaseModel parking);
        Task DisableParkingCounter(Guid id);
        Task UpdatedUsages(Guid id, TimeSpan time);
    }
}
