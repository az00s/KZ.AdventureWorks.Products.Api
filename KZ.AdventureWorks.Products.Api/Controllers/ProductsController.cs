using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KZ.AdventureWorks.Products.Api.Models;

namespace KZ.AdventureWorks.Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AdventureWorks2019Context _context;

        public ProductsController(AdventureWorks2019Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves products
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        /// <summary>
        /// Retrieves a specific product by unique id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <param name="id" example="123">The product id</param>
        /// <response code="200">Product created</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your product right now</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        /// <summary>
        /// Updates a specific product by unique id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <param name="id" example="123">The product id</param>
        /// <param name="product">A product to update.</param>
        /// <response code="200">Product created</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't update your product right now</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PutProduct(int id, [FromBody] Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Product created</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your product right now</response>
        [HttpPost]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        /// <summary>
        /// Deletes a specific product by unique id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <param name="id" example="123">The product id</param>
        /// <response code="200">Product deleted</response>
        /// <response code="500">Oops! Can't delete your product right now</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
