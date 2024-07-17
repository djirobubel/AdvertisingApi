using AdvertisingApi.Data;
using AdvertisingApi.Interface;
using AdvertisingApi.Models;

namespace AdvertisingApi.Repository
{
    public class PhotoUrlRepository : IPhotoUrlRepository
    {
        private readonly DataContext _context;

        public PhotoUrlRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePhotoUrlAsync(PhotoUrl photoUrl)
        {
            await _context.PhotoUrls.AddAsync(photoUrl);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
