namespace AdvertisingApi.Models
{
    public class Advertisement
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime CreationDate { get; set; }
        public List<PhotoUrl>? PhotoUrls { get; set; }
    }
}
