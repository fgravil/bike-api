using BikeShop.Services.Models;

namespace BikeShop.Services.Interfaces
{
    public interface IBikeService
    {
        Task<Guid> AddBikeAsync(BikeModelBase bikeRequest);
        Task DeleteBikeAsync(Guid bikeId);
        Task<IEnumerable<GetBikeModel>> GetBikesAsync();
        Task UpdateBikeAsync(Guid bikeId, BikeModelBase bikeRequest);
    }
}