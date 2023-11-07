using System.Linq.Expressions;
using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Filters;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Services
{
    public class AlbumService : GenericService<Album>, IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        public AlbumService(IAlbumRepository albumRepository, IMapper mapper, IUriService uriService) : base(albumRepository, mapper, uriService)
        {
            _albumRepository = albumRepository;
        }

        public async Task<PagedResponse<List<Album>>> GetAlbums([FromQuery] PaginationFilter paginationFilter, string route, [FromBody] List<Filter> filters)
        {
            Expression<Func<Album, bool>> predicate = FilterUtils.GetPredicate<Album>(filters);
            IQueryable<Album> query = await _albumRepository.GetAlbumsAsync(predicate);
            return await GetPagination(paginationFilter, query, route);
        }
    }
}
