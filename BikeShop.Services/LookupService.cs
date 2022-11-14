using BikeShop.Data.Interfaces;
using BikeShop.Services.Models;

namespace BikeShop.Services
{
    public class LookupService : ILookupService
    {
        private readonly ILookupRepository _lookupRepository;

        public LookupService(ILookupRepository lookupRepository)
        {
            _lookupRepository = lookupRepository;
        }

        public async Task<IEnumerable<LookupModel>> GetLookupAsync(string name)
        {
            var lookups = await _lookupRepository.GetLookupAsync(name);
            return lookups.Select(l => new LookupModel
            {
                Id = l.Id,
                Name = l.Name
            });
        }
    }
}

