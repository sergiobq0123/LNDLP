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
    public class SongService : GenericService<Song>, ISongService
    {
        private readonly ISongRepository _songRepository;
        public SongService(ISongRepository songRepository, IMapper mapper, IUriService uriService) : base(songRepository, mapper, uriService)
        {
            _songRepository = songRepository;
        }

        public async Task<PagedResponse<List<Song>>> GetSongs([FromQuery] PaginationFilter paginationFilter, string route, [FromBody] List<Filter> filters)
        {
            Expression<Func<Song, bool>> predicate = FilterUtils.GetPredicate<Song>(filters);
            IQueryable<Song> query = await _songRepository.GetSongsAsync(predicate);
            return await GetPagination(paginationFilter, query, route);
        }
    }
}
