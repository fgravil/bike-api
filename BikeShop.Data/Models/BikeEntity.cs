namespace BikeShop.Data.Models
{
    public class BikeEntity
    {
        public Guid BikeId { get; set; }
        public int ManufacturerId { get; set; }
        public string Model { get; set; }
        public int FrameSize { get; set; }
        public decimal Price { get; set; }
    }
}

