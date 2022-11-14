using BikeShop.Data.Models;

namespace BikeShop.Data.Interfaces
{
    public interface ILookupRepository
    {
        Task<IEnumerable<LookupEntity>> GetLookupAsync(string tableName);
    }
}