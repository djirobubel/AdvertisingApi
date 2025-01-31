﻿using AdvertisingApi.Dto;
using AdvertisingApi.Interface;
using MediatR;

namespace AdvertisingApi.CQRS.Queries.GetAllAdvertisements
{
    public class GetAllAdvertisementsHandler : IRequestHandler<GetAllAdvertisementsQuery,
        GetAllAdvertisementsResult>
    {
        private readonly IAdvertisementRepository _advertisementRepository;

        public GetAllAdvertisementsHandler(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }

        public async Task<GetAllAdvertisementsResult> Handle(GetAllAdvertisementsQuery request,
            CancellationToken cancellationToken)
        {
            var advertisements = await _advertisementRepository.GetAllAdvertisementsAsync
                (request.PageNumber, request.PageSize, request.SortBy, request.IsAscending);

            var advertisementsDto = advertisements.Select(a => new AdvertisementDto
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                Price = a.Price,
                CreationDate = a.CreationDate,
                PhotoUrl = a.PhotoUrls.Select(p => new PhotoUrlDto
                {
                    Id = p.Id,
                    Url = p.Url,
                }).FirstOrDefault()
            }).ToList();

            var result = new GetAllAdvertisementsResult
            {
                Advertisements = advertisementsDto
            };

            return result;
        }
    }
}
