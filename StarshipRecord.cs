namespace StarshipServer
{
    public class StarshipRecord
    {
        public required string StarshipName { get; set; }

        // public StarshipType ShipType { get; set; }
        
        public required string StarshipConfigJson { get; set; }
    }
}
