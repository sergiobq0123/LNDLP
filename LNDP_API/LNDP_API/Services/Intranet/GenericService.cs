using System.Linq.Expressions;
using LNDP_API.Models.Interfaces;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IImageUtils _imageUtils;
        private readonly IUrlEmbedUtils _urlEmbedUtils;

        public GenericService(IGenericRepository<TEntity> repository, IImageUtils imageUtils = null, IUrlEmbedUtils urlEmbedUtils = null)
        {
            _repository = repository;
            _imageUtils = imageUtils;
            _urlEmbedUtils = urlEmbedUtils;
        }

        public async Task<IEnumerable<TEntity>> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Expression<Func<TEntity, object>> includes = null)
        {
            return await _repository.GetWithIncludesAsync(filter, includes);
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
                if(!_imageUtils.IsValidUrl(entityWithPhotoUrl.PhotoUrl))
                {
                    entityWithPhotoUrl.PhotoUrl = await _imageUtils.ConvertBase64ToUrl(entityWithPhotoUrl.PhotoUrl, entityWithPhotoUrl.Name);
                }
            }
            return await _repository.UpdateAsync(entity);
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }

    }
}