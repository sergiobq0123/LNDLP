using Microsoft.AspNetCore.WebUtilities;

namespace LNDP_API.Filters
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }
        public Uri GetPageUri(PaginationFilter filter, string route)
        {
            var endpointUri = new Uri(string.Concat(_baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(endpointUri.ToString(), "page", filter.Page.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "size", filter.Size.ToString());
            return new Uri(modifiedUri);
        }
    }
}