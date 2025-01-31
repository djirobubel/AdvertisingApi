﻿using AdvertisingApi.Data;
using AdvertisingApi.Interface;
using AdvertisingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingApi.Repository
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly DataContext _context;

        public AdvertisementRepository(DataContext context)
        {
            _context = context;
        }

        public bool AdvertisementExists(string title)
        {
            return _context.Advertisements.Any(a => a.Title == title);
        }

        public async Task<bool> CreateAdvertisementAsync(Advertisement advertisement)
        {
            await _context.Advertisements.AddAsync(advertisement);
            return await SaveAsync();
        }

        public async Task<Advertisement> GetAdvertisementAsync(string title)
        {
            return await _context.Advertisements.Include(p => p.PhotoUrls).SingleOrDefaultAsync
                (a => a.Title == title);
        }

        public async Task<ICollection<Advertisement>> GetAllAdvertisementsAsync
            (int pageNumber, int pageSize, string sortBy, bool isAscending)
        {
            var skipNumber = (pageNumber - 1) * pageSize;

            IQueryable<Advertisement> query = _context.Advertisements;

            query = sortBy.ToLower() switch
            {
                "price" => isAscending
                    ? query.Include(p => p.PhotoUrls).OrderBy(a => a.Price)
                    : query.Include(p => p.PhotoUrls).OrderByDescending(a => a.Price),
                "creationdate" => isAscending
                    ? query.Include(p => p.PhotoUrls).OrderBy(a => a.CreationDate)
                    : query.Include(p => p.PhotoUrls).OrderByDescending(a => a.CreationDate),
                _ => query.Include(p => p.PhotoUrls).OrderByDescending(a => a.CreationDate)
            };

            return await query.Skip(skipNumber).Take(pageSize).ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}
