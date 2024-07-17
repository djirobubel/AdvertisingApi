using AdvertisingApi.Dto;
using AdvertisingApi.Interface;
using MediatR;

namespace AdvertisingApi.CQRS.Queries.GetAdvertisement
{
    public class GetAdvertisementHandler : IRequestHandler<GetAdvertisementQuery,
        GetAdvertisementResult>
    {
        private readonly IAdvertisementRepository _advertisementRepository;

        public GetAdvertisementHandler(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }

        public async Task<GetAdvertisementResult> Handle(GetAdvertisementQuery request,
            CancellationToken cancellationToken)
        {
            if (!_advertisementRepository.AdvertisementExists(request.Title))
            {
                var notFound = new GetAdvertisementResult
                {
                    Existence = false
                };

                return notFound;
            }

            var advertisement = await _advertisementRepository.GetAdvertisementAsync(request.Title);

            var result = new GetAdvertisementResult
            {
                Id = advertisement.Id,
                Title = advertisement.Title,
                Description = advertisement.Description,
                Price = advertisement.Price,
                CreationDate = advertisement.CreationDate,
                PhotoUrls = advertisement.PhotoUrls.Select(p =>
                new PhotoUrlDto
                {
                    Id = p.Id,
                    Url = p.Url,
                }).ToList()
            };

            return result;
        }
    }
}
