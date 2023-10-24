using AutoMapper;
using LNDP_API.Data;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Services
{
    public class ArtistFestivalAsocService : GenericService<ArtistFestivalAsoc>, IArtistFestivalAsocService
    {
        private readonly IArtistFestivalAsocRepository _artistFestivalAsocRepository;
        public ArtistFestivalAsocService(IArtistFestivalAsocRepository artistFestivalAsocRepository, IMapper mapper, IUriService uriService) : base(artistFestivalAsocRepository, mapper, uriService)
        {
            _artistFestivalAsocRepository = artistFestivalAsocRepository;
        }
        public async Task<ArtistFestivalAsoc> CreateArtistFestivalAsoc(ArtistFestivalAsoc artistFestivalAsoc)
        {
            return await _artistFestivalAsocRepository.CreateAsync(artistFestivalAsoc);
        }

        public async Task DeleteArtistFestivalAsoc(int idArtistFestivalAsoc)
        {
            await _artistFestivalAsocRepository.DeleteAsync(idArtistFestivalAsoc);
        }

        public async Task UpdateFestivalWithArtists(FestivalArtistDto festivalArtistDto)
        {
            foreach (var artista in festivalArtistDto.NuevosArtistas)
            {
                ArtistFestivalAsoc artistFestivalAsoc = new ArtistFestivalAsoc
                {
                    ArtistId = artista.Id,
                    FestivalId = festivalArtistDto.FestivalId
                };
                await CreateArtistFestivalAsoc(artistFestivalAsoc);
            }
            foreach (var artista in festivalArtistDto.ArtistasEliminados)
            {
                int idArtistFestivalAsoc = await _artistFestivalAsocRepository.GetIdByArtistFestival(artista.Id, festivalArtistDto.FestivalId);
                await DeleteArtistFestivalAsoc(idArtistFestivalAsoc);
            }
        }

        public async Task<PagedResponse<List<ArtistFestivalAsoc>>> GetFestivalForArtist(int id, [FromQuery] PaginationFilter paginationFilter, string route)
        {
            IQueryable<ArtistFestivalAsoc> query = await _artistFestivalAsocRepository.GetFestivalsForArtistAsync(id);
            return await this.GetPagination(paginationFilter, query, route);
        }
    }

}
