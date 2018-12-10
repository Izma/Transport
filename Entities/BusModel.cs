namespace Entities
{
    public class BusModel : LogUserModel
    {
        public int BusId { get; set; }
        public string Number { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public int SeatNumber { get; set; }
        public int WheelsNumber { get; set; }
        public string EngineNumber { get; set; }
    }
}
