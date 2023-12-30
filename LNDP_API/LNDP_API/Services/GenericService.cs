using System.Linq.Expressions;
using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Filters;
using LNDP_API.Models.Interfaces;
using LNDP_API.Repositories;
using LNDP_API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        protected readonly IImageUtils _imageUtils;
        protected readonly IUrlEmbedUtils _urlEmbedUtils;
        protected readonly IMapper _mapper;
        protected readonly PaginationUtils<TEntity> _paginationUtils;
        protected readonly Func<TEntity, TEntity> _mappingFunc = entity => entity;
        protected readonly IUriService _uriService;
        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper, IUriService uriService)
        {
            _repository = repository;
            _imageUtils = new ImageUtils();
            _urlEmbedUtils = new UrlEmbedUtils();
            _mapper = mapper;
            _paginationUtils = new PaginationUtils<TEntity>(uriService);
            _uriService = uriService;
        }

        public async Task<PagedResponse<List<TEntity>>> Get([FromQuery] PaginationFilter paginationFilter, string route, [FromBody] List<Filter> filters)
        {
            Expression<Func<TEntity, bool>> predicate = FilterUtils.GetPredicate<TEntity>(filters);
            IQueryable<TEntity> query = await _repository.GetAsync(predicate);
            return await GetPagination(paginationFilter, query, route);
        }

        public async Task<PagedResponse<List<TEntity>>> GetPagination([FromQuery] PaginationFilter paginationFilter, IQueryable<TEntity> query, string route)
        {
            return await _paginationUtils.GetPagedDataAsync(query, paginationFilter, route, _mappingFunc);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            if (entity is IHasPhotoUrl entityWithPhotoUrl)
            {
                entityWithPhotoUrl.PhotoUrl = await _imageUtils.ConvertBase64ToUrl(entityWithPhotoUrl.PhotoUrl, entityWithPhotoUrl.Name);
            }
            if (entity is IHasUrl entityWithUrl)
            {
                entityWithUrl.Url = _urlEmbedUtils.GetEmbedUrlYoutube(entityWithUrl.Url);
            }
            return await _repository.CreateAsync(entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            if (entity is IHasPhotoUrl entityWithPhotoUrl)
            {
                if (!_imageUtils.IsValidUrl(entityWithPhotoUrl.PhotoUrl))
                {
                    entityWithPhotoUrl.PhotoUrl = await _imageUtils.ConvertBase64ToUrl(entityWithPhotoUrl.PhotoUrl, entityWithPhotoUrl.Name);
                }
            }
            if (entity is IHasUrl entityWithUrl && !_urlEmbedUtils.IsEmbedvideo(entityWithUrl.Url))
            {
                entityWithUrl.Url = _urlEmbedUtils.GetEmbedUrlYoutube(entityWithUrl.Url);
            }
            return await _repository.UpdateAsync(entity);
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<KeysIntranetDto>> GetKeys()
        {
            var keys = await _repository.GetAsync(null);
            return _mapper.Map<IEnumerable<KeysIntranetDto>>(keys);
        }
    }
}