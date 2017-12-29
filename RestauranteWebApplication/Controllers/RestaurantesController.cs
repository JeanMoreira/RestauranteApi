using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteWebApplication.Data;
using RestauranteWebApplication.Models;

namespace RestauranteWebApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/Restaurantes")]
    public class RestaurantesController : Controller
    {
        private readonly BdContext _context;

        public RestaurantesController(BdContext context)
        {
            _context = context;
        }

        // GET: api/Restaurantes
        [HttpGet]
        public IEnumerable<Restaurante> GetRestarantes()
        {
            return _context.Restarantes;
        }


        [HttpGet("GetRestarantesLike/{nome}")]
        public IEnumerable<Restaurante> GetRestarantesLike(string nome)
        {

            try
            {
                var query = _context.Restarantes.FromSql("select * from Restaurante where Descricao like '%"+ nome + "%'");
                return query;

            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }



        // GET: api/Restaurantes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurante([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurante = await _context.Restarantes.SingleOrDefaultAsync(m => m.ID == id);

            if (restaurante == null)
            {
                return NotFound();
            }

            return Ok(restaurante);
        }

        // PUT: api/Restaurantes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurante([FromRoute] int id, [FromBody] Restaurante restaurante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurante.ID)
            {
                return BadRequest();
            }

            _context.Entry(restaurante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestauranteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Restaurantes
        [HttpPost]
        public async Task<IActionResult> PostRestaurante([FromBody] Restaurante restaurante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Restarantes.Add(restaurante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurante", new { id = restaurante.ID }, restaurante);
        }

        // DELETE: api/Restaurantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurante([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurante = await _context.Restarantes.SingleOrDefaultAsync(m => m.ID == id);
            if (restaurante == null)
            {
                return NotFound();
            }

            _context.Restarantes.Remove(restaurante);
            await _context.SaveChangesAsync();

            return Ok(restaurante);
        }

        

        private bool RestauranteExists(int id)
        {
            return _context.Restarantes.Any(e => e.ID == id);
        }
    }
}