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

            AdvertisementDto advertisementDto = new AdvertisementDto
            {
                Id = advertisement.Id,
                Title = advertisement.Title,
                Description = advertisement.Description,
                Price = advertisement.Price,
                CreationDate = advertisement.CreationDate,
                PhotoUrls = advertisement.PhotoUrls.OrderBy(p => p.Url).Select(p =>
                new PhotoUrlDto
                {
                    Id = p.Id,
                    Url = p.Url,
                }).ToList()
            };

            GetAdvertisementResult result = new GetAdvertisementResult
            {
                Id = advertisementDto.Id,
                Title = advertisementDto.Title,
                Description = advertisementDto.Description,
                Price = advertisementDto.Price,
                CreationDate = (DateTime)advertisementDto.CreationDate,
                PhotoUrls = advertisementDto.PhotoUrls
            };

            return result;
        }
    }
}
