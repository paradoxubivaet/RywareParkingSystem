namespace RywareParkingSystem.DAL.Entities
{
    public class ParkingDatabaseModel
    {
        public Guid Id { get; set; }
        public string? Address { get; set; }
        public bool Status { get; set; }
        public TimeSpan Usages { get; set; }
    }
}
