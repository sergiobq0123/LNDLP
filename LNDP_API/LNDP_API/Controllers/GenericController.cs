
using LNDP_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<TEntity> : ControllerBase where TEntity : class
    {
        private readonly IGenericService<TEntity> _service;

        public GenericController(IGenericService<TEntity> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Post(TEntity entity)
        {
            try
            {
                TEntity createdEntity = await _service.Create(entity);
                return Ok(new { Message = $"{typeof(TEntity).Name} creado(a) con éxito.", Entity = createdEntity });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TEntity entity)
        {
            try
            {
                TEntity updatedEntity = await _service.Update(entity);
                return Ok(new { Message = $"{typeof(TEntity).Name} actualizado(a) con éxito.", Entity = updatedEntity });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return Ok(new { Message = $"{typeof(TEntity).Name} eliminado(a) con éxito." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }


}