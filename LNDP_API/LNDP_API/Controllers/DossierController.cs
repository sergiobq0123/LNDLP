using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Expressions;
using TTTAPI.Utils;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class DossierController : ControllerBase
    {
        private readonly APIContext _context;

        public DossierController(APIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dossier>>> GetDossier()
        {
            if(_context.Dossier == null){
                return NotFound();
            }
            return await _context.Dossier.OrderBy(d =>d.Order) .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> PostDossier([FromForm] IFormFile? image, [FromForm] string section)
        {
            if (image != null && image.Length > 0)
            {
                var assetsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/section");
                if (!Directory.Exists(assetsFolderPath))
                {
                    Directory.CreateDirectory(assetsFolderPath);
                }
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(assetsFolderPath, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                int maxOrder = await _context.Dossier.MaxAsync(d => (int?)d.Order) ?? 0;

                var dossier = new Dossier
                {
                    Section = section,
                    Photo = "https://localhost:7032/assets/section/" + fileName,
                    Order = maxOrder + 1
                };
                _context.Dossier.Add(dossier);
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest(new { Message = "La imagen no se ha podido cargar" });
            }
            await _context.SaveChangesAsync();
             return Ok(new { Message = "Se ha añadido la imagen " });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(List<Dossier> updatedDossierItems)
        {
            if (updatedDossierItems == null)
            {
                return BadRequest("No se proporcionaron datos válidos.");
            }
            try
            {
                foreach (var updatedItem in updatedDossierItems)
                {
                    var existingItem = await _context.Dossier
                        .FirstOrDefaultAsync(d => d.Id == updatedItem.Id);

                    if (existingItem != null)
                    {
                        existingItem.Order = updatedItem.Order;
                    }
                }
                await _context.SaveChangesAsync();
                return Ok(); 
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Ocurrió un error al actualizar la base de datos.");
            }
        }
        [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDossier(int id)
        {
            var dossier = await _context.Dossier.FindAsync(id);

            if (dossier == null)
            {
                return NotFound();
            }

            _context.Dossier.Remove(dossier);
            await _context.SaveChangesAsync();

            // Resta uno a los valores de order de los elementos restantes
            var dossiersToUpdate = _context.Dossier.Where(d => d.Order > dossier.Order).ToList();
            foreach (var dossierToUpdate in dossiersToUpdate)
            {
                dossierToUpdate.Order -= 1;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}