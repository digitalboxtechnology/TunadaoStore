using System.Reflection.Metadata;
using API.RequestHelpers;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;


public class ProductsController : BaseController
{
    private readonly IGenericRepository<Product> _productRepository;

    public ProductsController(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts([FromQuery] ProductSpecParams productSpecParams)
    {
        var spec = new ProductFilterSpecification(productSpecParams);

        return await CreatePagedResult(_productRepository, spec, productSpecParams.PageIndex, productSpecParams.PageSize);
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
        var spec = new BrandListSpecification();
        return Ok(await _productRepository.ListAsync(spec));
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetProductTypes()
    {
        var spec = new TypeListSpecification();
        return Ok(await _productRepository.ListAsync(spec));
    }

    private bool ProductExists(int id)
    {
        return _productRepository.EntityExists(id);
    }
}