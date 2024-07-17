namespace AdvertisingApi.Models
{
    public class PhotoUrl
    {
        public Guid Id { get; set; }
        public string? Url { get; set; }

        public Guid AdvertisementId { get; set; }
        public Advertisement? Advertisement { get; set; }
    }
}
