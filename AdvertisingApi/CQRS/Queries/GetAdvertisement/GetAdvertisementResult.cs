using AdvertisingApi.Dto;

namespace AdvertisingApi.CQRS.Queries.GetAdvertisement
{
    public class GetAdvertisementResult
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime CreationDate { get; set; }
        public List<PhotoUrlDto>? PhotoUrls { get; set; }
        public bool? Existence { get; set; } = true;
    }
}
