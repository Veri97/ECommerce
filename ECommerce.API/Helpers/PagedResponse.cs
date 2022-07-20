namespace ECommerce.API.Helpers
{
    public class PagedResponse<T>
        where T : class
    {
        public PagedResponse(int pageIndex, int pageSize, int totalResults, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalResults = totalResults;
            Data = data;
            TotalPages = Convert.ToInt32(Math.Ceiling((double)totalResults / (double)pageSize));
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; private set; }
        public int TotalResults { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
