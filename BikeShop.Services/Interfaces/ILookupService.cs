using BikeShop.Services.Models;

namespace BikeShop.Services
{
    public interface ILookupService
    {
        Task<IEnumerable<LookupModel>> GetLookupAsync(string name);
    }
}