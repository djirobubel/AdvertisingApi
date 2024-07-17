using AdvertisingApi.Models;

namespace AdvertisingApi.Interface
{
    public interface IAdvertisementRepository
    {
        Task<ICollection<Advertisement>> GetAllAdvertisementsAsync(int pageNumber, int pageSize,
            string sortBy, bool isAscending);
        Task<Advertisement> GetAdvertisementAsync(string title);
        Task<bool> CreateAdvertisementAsync(Advertisement advertisement);
        bool AdvertisementExists(string title);
        Task<bool> SaveAsync();
    }
}
