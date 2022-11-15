using RywareParkingSystem.DAL.Entities;
using RywareParkingSystem.Models;

namespace RywareParkingSystem.Converter
{
    public class ParkingConverter
    {
        public static Parking ConvertToModel(ParkingDatabaseModel parkingDbModel)
        {
            var parking = new Parking 
            {
                Id = parkingDbModel.Id,
                Address = parkingDbModel.Address,
            };

            return parking;
        }

        public static IEnumerable<Parking> ConvertToModelList(IEnumerable<ParkingDatabaseModel> parkingDbModels)
        {
            var parkings = new List<Parking>();

            foreach(var parking in parkingDbModels)
            {
                parkings.Add(ConvertToModel(parking));
            }

            return parkings; 
        }
    }
}
