namespace LNDP_API.Filters
{
    public class PaginationFilter
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        public PaginationFilter()
        {
            Page = 1;
            Size = 10;
            SortBy = "Id";
            SortOrder = "asc";
        }
        public PaginationFilter(int page, int size, string sortBy = "Id", string sortOrder = "asc")
        {
            Page = page < 1 ? 1 : page;
            Size = size > 20 ? 20 : size;
            SortBy = sortBy;
            SortOrder = sortOrder;
        }
    }
}