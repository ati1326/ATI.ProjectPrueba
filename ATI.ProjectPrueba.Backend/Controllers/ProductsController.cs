using ATI.ProjectPrueba.Backend.Data;
using ATI.ProjectPrueba.Classlibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATI.ProjectPrueba.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly DataContext _context;
        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] // trae la lista de todos los poductos existetes en la base de datos 
        public async Task<IActionResult> GetAsync()
        {
 
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpGet("{id}")] // busca el producto en la base de datos
        public async Task<IActionResult> GetAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }



        [HttpPost]// creamos un producto 
        public async Task<IActionResult> PostAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }


        [HttpPut]// editamos un producto 
        public async Task<IActionResult> PutAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")] // busca el producto en la base de datos
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

         








    }
}