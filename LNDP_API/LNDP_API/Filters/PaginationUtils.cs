using LNDP_API.Filters;
using Microsoft.EntityFrameworkCore;

namespace LNDP_API.Filters
{
    public class PaginationUtils<T>
    {
        private readonly IUriService _uriService;

        public PaginationUtils(IUriService uriService)
        {
            _uriService = uriService;
        }

        public async Task<PagedResponse<List<TResult>>> GetPagedDataAsync<TResult>(
            IQueryable<T> query, PaginationFilter pageFilter, string route, Func<T, TResult>? mappingFunc = null)
        {
            var validPageFilter = new PaginationFilter(pageFilter.Page, pageFilter.Size, pageFilter.SortBy, pageFilter.SortOrder);

            // Sort the query
            if (!string.IsNullOrWhiteSpace(validPageFilter.SortBy) && !string.IsNullOrWhiteSpace(validPageFilter.SortOrder))
            {
                query = SortingUtils.ApplySorting(query, validPageFilter.SortBy, validPageFilter.SortOrder);
            }

            // Apply pagination
            var totalCount = await query.CountAsync();
            var pagedQuery = query
                .Skip((validPageFilter.Page - 1) * validPageFilter.Size)
                .Take(validPageFilter.Size);

            var data = mappingFunc != null ? pagedQuery.Select(mappingFunc).ToList() : pagedQuery.Cast<TResult>().ToList();

            var pagedResponse = PaginationHelper.CreatePagedResponse(data, validPageFilter, totalCount, _uriService, route);

            return pagedResponse;
        }
    }
}