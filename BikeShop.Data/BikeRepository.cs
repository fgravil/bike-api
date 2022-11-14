using BikeShop.Data.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BikeShop.Data
{
    public class BikeRepository : RepositoryBase, IBikeRepository
    {
        public BikeRepository(IOptions<BikeShopClientSettings> settings, ILogger<BikeRepository> logger)
            : base(settings.Value, logger)
        {
        }

        public async Task<IEnumerable<BikeEntity>> GetBikesAsync()
        {
            var sql = @"Select * from bike";
            return await QueryDataAsync<dynamic, BikeEntity>(sql, null);
        }

        public async Task AddBikeAsync(BikeEntity bike)
        {
            var sql = "Insert Into bike Values(@BikeId, @ManufacturerId, @Model, @FrameSize, @Price)";
            await SaveDataAsync(sql, bike);
        }

        public async Task UpdateBikeAsync(BikeEntity bike)
        {
            var sql = @"Update bike
                        Set model = @Model, manufacturerId = @ManufacturerId, frameSize = @FrameSize, price = @Price
                        Where bikeId = @BikeId";
            await SaveDataAsync(sql, bike);
        }

        public async Task DeleteBikeAsync(Guid bikeId)
        {
            var sql = "Delete From bike Where BikeId = @bikeId";
            await SaveDataAsync(sql, new { bikeId });
        }

    }
}

