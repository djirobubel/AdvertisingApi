using AdvertisingApi.Dto;

namespace AdvertisingApi.CQRS.Queries.GetAllAdvertisements
{
    public class GetAllAdvertisementsResult
    {
        public List<AdvertisementDto>? Advertisements { get; set; }
    }
}
