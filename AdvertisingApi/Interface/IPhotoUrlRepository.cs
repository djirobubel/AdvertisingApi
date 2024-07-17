using AdvertisingApi.Models;

namespace AdvertisingApi.Interface
{
    public interface IPhotoUrlRepository
    {
        Task<bool> CreatePhotoUrlAsync(PhotoUrl photoUrl);
        Task<bool> SaveAsync();
    }
}
