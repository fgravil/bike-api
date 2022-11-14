namespace BikeShop.Services.Models
{
    public class BikeModelBase
    {
        public int ManufacturerId { get; set; }
        public string Model { get; set; }
        public int FrameSize { get; set; }
        public decimal Price { get; set; }
    }
}

