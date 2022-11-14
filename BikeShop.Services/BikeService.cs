using BikeShop.Data;
using BikeShop.Data.Models;
using BikeShop.Services.Interfaces;
using BikeShop.Services.Models;

namespace BikeShop.Services
{
    public class BikeService : IBikeService
    {
        private readonly IBikeRepository _bikeRepository;

        public BikeService(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public async Task<IEnumerable<GetBikeModel>> GetBikesAsync()
        {
            var bikes = await _bikeRepository.GetBikesAsync();
            return bikes.Select(b => new GetBikeModel
            {
                BikeId = b.BikeId,
                ManufacturerId = b.ManufacturerId,
                Model = b.Model,
                FrameSize = b.FrameSize,
                Price = b.Price,
            });
        }

        public async Task<Guid> AddBikeAsync(BikeModelBase bikeRequest)
        {
            if (bikeRequest == null)
            {
                throw new ArgumentNullException(nameof(bikeRequest));
            }

            var bike = new BikeEntity
            {
                BikeId = Guid.NewGuid(),
                ManufacturerId = bikeRequest.ManufacturerId,
                Model = bikeRequest.Model,
                FrameSize = bikeRequest.FrameSize,
                Price = bikeRequest.Price
            };

            await _bikeRepository.AddBikeAsync(bike);
            return bike.BikeId;
        }

        public async Task UpdateBikeAsync(Guid bikeId, BikeModelBase bikeRequest)
        {
            if (bikeRequest == null)
            {
                throw new ArgumentNullException(nameof(bikeRequest));
            }

            var bike = new BikeEntity
            {
                BikeId = bikeId,
                ManufacturerId = bikeRequest.ManufacturerId,
                Model = bikeRequest.Model,
                FrameSize = bikeRequest.FrameSize,
                Price = bikeRequest.Price
            };

            await _bikeRepository.UpdateBikeAsync(bike);
        }

        public async Task DeleteBikeAsync(Guid bikeId)
        {
            await _bikeRepository.DeleteBikeAsync(bikeId);
        }
    }
}

