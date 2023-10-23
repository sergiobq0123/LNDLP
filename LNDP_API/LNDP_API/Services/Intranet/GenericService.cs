using System.Linq.Expressions;
using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models.Interfaces;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        protected readonly IImageUtils _imageUtils;
        protected readonly IUrlEmbedUtils _urlEmbedUtils;
        protected readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _imageUtils = new ImageUtils();
            _urlEmbedUtils = new UrlEmbedUtils();
            _mapper = mapper;
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await _repository.GetAsync();
        }

        public async Task<TEntity> Exists(TEntity entity)
        {
            return await _repository.Exist(entity);
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
            if (entity is IHasUrl entityWithUrl)
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
            var keys = await _repository.GetAsync();
            return _mapper.Map<IEnumerable<KeysIntranetDto>>(keys);
        }
    }
}