namespace AdvertisingApi.Dto
{
    public class AdvertisementDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreationDate { get; set; }
        public PhotoUrlDto? PhotoUrl { get; set; }
    }
}
