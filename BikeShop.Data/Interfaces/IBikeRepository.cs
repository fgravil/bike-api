using BikeShop.Data.Models;

namespace BikeShop.Data
{
    public interface IBikeRepository
    {
        Task AddBikeAsync(BikeEntity bike);
        Task DeleteBikeAsync(Guid bikeId);
        Task<IEnumerable<BikeEntity>> GetBikesAsync();
        Task UpdateBikeAsync(BikeEntity bike);
    }
}