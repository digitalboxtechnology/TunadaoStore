using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IGenericRepository<Product> _productRepository;

    public ProductsController(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(string? brand, string? type, [FromQuery] string? sort)
    {
        var spec = new ProductFilterSpecification(brand, type, sort);

        var products = await _productRepository.ListAsync(spec);

        return Ok(products);
    }

    [HttpGet("{id:int}")] //api/products/3
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct([FromBody]Product product)
    {
        _productRepository.Add(product);

        if(await _productRepository.SaveChangesAsync())
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);

        return BadRequest("Problem creating product");
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        if (id != product.Id || !ProductExists(id)) return BadRequest("Cannot update product");

        _productRepository.Update(product);

        if(await _productRepository.SaveChangesAsync())
            return NoContent();

        return BadRequest("Problem updating product");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return NotFound();

        _productRepository.Delete(product);
        
        if(await _productRepository.SaveChangesAsync())
            return NoContent();

        return BadRequest("Problem deleting product");
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetProductBrands()
    {
        //TODO: Implements method
        //var brands = await _productRepository.GetAllProductBrandsAsync();
        
        return Ok();
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetProductTypes()
    {
        //TODO: Implements method
        //var types = await _productRepository.GetAllProductTypesAsync();
        return Ok();
    }

    private bool ProductExists(int id)
    {
        return _productRepository.EntityExists(id);
    }
}