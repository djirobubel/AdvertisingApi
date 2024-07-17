using MediatR;

namespace AdvertisingApi.CQRS.Queries.GetAllAdvertisements
{
    public class GetAllAdvertisementsQuery : IRequest<GetAllAdvertisementsResult>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public bool IsAscending { get; set; }

        public GetAllAdvertisementsQuery(int pageNumber, int pageSize, string sortBy, bool isAscending)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SortBy = sortBy;
            IsAscending = isAscending;
        }
    }
}
