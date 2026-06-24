using ATI.ProjectPrueba.Backend.Data;
using ATI.ProjectPrueba.Classlibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace ATI.ProjectPrueba.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {

        private readonly DataContext _context;
        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] // trae la lista de todos los paises existetes en la base de datos 
        public async Task<IActionResult> GetAsync()
        {
 
            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpGet("{id}")] // busca el pais en la base de datos
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }



        [HttpPost]// creamos un pais 
        public async Task<IActionResult> PostAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }


        [HttpPut]// editamos un pais 
        public async Task<IActionResult> PutAsync(Country country)
        {
            _context.Update(country    );
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")] // busca el pais en la base de datos
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var country  = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            _context.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

         








    }
}