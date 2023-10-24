public static class PaginationHelper
{
    public static PagedResponse<List<T>> CreatePagedResponse<T>(
        List<T> pagedData, PaginationFilter pageFilter, int totalEntries, IUriService uriService, string route)
    {
        var response = new PagedResponse<List<T>>(pagedData, pageFilter.Page, pageFilter.Size);
        var totalPages = (double)totalEntries / (double)pageFilter.Size;
        int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
        response.NextPage =
            pageFilter.Page >= 1 && pageFilter.Page < roundedTotalPages
            ? uriService.GetPageUri(new PaginationFilter(pageFilter.Page + 1, pageFilter.Size), route)
            : null;
        response.PreviousPage =
            pageFilter.Page > 1 && pageFilter.Page <= roundedTotalPages
            ? uriService.GetPageUri(new PaginationFilter(pageFilter.Page - 1, pageFilter.Size), route)
            : null;
        response.FirstPage = uriService.GetPageUri(new PaginationFilter(1, pageFilter.Size), route);
        response.LastPage = uriService.GetPageUri(new PaginationFilter(roundedTotalPages, pageFilter.Size), route);
        response.TotalPages = roundedTotalPages;
        response.TotalEntries = totalEntries;
        return response;
    }
}