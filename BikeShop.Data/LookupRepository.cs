using BikeShop.Data.Interfaces;
using BikeShop.Data.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BikeShop.Data
{
    public class LookupRepository : RepositoryBase, ILookupRepository
    {
        public LookupRepository(IOptions<BikeShopClientSettings> settings, ILogger<LookupRepository> logger)
            : base(settings.Value, logger)
        {
        }

        public async Task<IEnumerable<LookupEntity>> GetLookupAsync(string tableName)
        {
            var sql = $"Select Id, Name From {tableName}";
            return await QueryDataAsync<dynamic, LookupEntity>(sql, new {tableName});
        }
    }
}

