using AdvertisingApi.Interface;
using AdvertisingApi.Models;
using MediatR;

namespace AdvertisingApi.CQRS.Commands.CreateAdvertisement
{
    public class CreateAdvertisementHandler : IRequestHandler<CreateAdvertisementCommand,
        CreateAdvertisementResult>
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IPhotoUrlRepository _photoUrlRepository;

        public CreateAdvertisementHandler(IAdvertisementRepository advertisementRepository,
            IPhotoUrlRepository photoUrlRepository)
        {
            _advertisementRepository = advertisementRepository;
            _photoUrlRepository = photoUrlRepository;
        }

        public async Task<CreateAdvertisementResult> Handle(CreateAdvertisementCommand request,
            CancellationToken cancellationToken)
        {
            Advertisement advertisement = new Advertisement
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                CreationDate = DateTime.UtcNow
            };

            await _advertisementRepository.CreateAdvertisementAsync(advertisement);

            var photoUrls = request.PhotoUrls;

            if(photoUrls.Count > 3)
            {
                throw new InvalidOperationException("Cannot add more than 3 urls to an advertisement.");
            }

            foreach (var photoUrl in photoUrls)
            {
                PhotoUrl url = new PhotoUrl
                {
                    Url = photoUrl,
                    AdvertisementId = advertisement.Id
                };

                await _photoUrlRepository.CreatePhotoUrlAsync(url);
            }

            CreateAdvertisementResult result = new CreateAdvertisementResult
            {
                Id = advertisement.Id,
            };

            return result;
        }
    }
}
