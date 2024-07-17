using MediatR;

namespace AdvertisingApi.CQRS.Queries.GetAdvertisement
{
    public class GetAdvertisementQuery : IRequest<GetAdvertisementResult>
    {
        public string Title { get; set; }

        public GetAdvertisementQuery(string title)
        {
            Title = title;
        }
    }
}
