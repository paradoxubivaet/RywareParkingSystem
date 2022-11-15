using RywareParkingSystem.DAL.Context;
using RywareParkingSystem.DAL.Entities;

namespace RywareParkingSystem.DAL.Repository
{
    public class Repository : IRepository
    {
        public Repository()
        { }

        public Task AddNewParking(ParkingDatabaseModel parking)
        {
            try
            {
                using (ParkingContext context = new ParkingContext())
                {
                    context.Parkings.Add(parking);
                    context.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Task.CompletedTask;
        }

        public Task DisableParkingCounter(Guid id)
        {
            try
            {
                using (ParkingContext context = new ParkingContext())
                {
                    var parking = context.Parkings.SingleOrDefault(x => x.Id == id);

                    if (parking is null)
                        return Task.CompletedTask;

                    parking.Status = false;
                    context.SaveChanges();
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<ParkingDatabaseModel>> GetParkings(string address)
        {
            List<ParkingDatabaseModel> parkings = new List<ParkingDatabaseModel>();
            try
            {
                using (ParkingContext context = new ParkingContext())
                {
                    parkings = context.Parkings.Where(x => x.Address == address).ToList();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return await Task.FromResult(parkings);
        }

        public Task UpdatedUsages(Guid id, TimeSpan time)
        {
            try
            {
                using(ParkingContext context = new ParkingContext())
                {
                    var parking = context.Parkings.SingleOrDefault(x => x.Id == id);

                    if (parking is null)
                        return Task.CompletedTask;

                    parking.Usages = time;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Task.CompletedTask;
        }
    }
}
