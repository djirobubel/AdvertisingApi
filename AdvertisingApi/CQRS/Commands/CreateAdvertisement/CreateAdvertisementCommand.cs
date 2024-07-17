using AdvertisingApi.Models;
using MediatR;

namespace AdvertisingApi.CQRS.Commands.CreateAdvertisement
{
    public class CreateAdvertisementCommand : IRequest<CreateAdvertisementResult>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public List<string>? PhotoUrls { get; set; }
    }
}
