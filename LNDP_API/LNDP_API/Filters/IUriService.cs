using LNDP_API.Filters;

namespace LNDP_API.Filters
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);

    }
}