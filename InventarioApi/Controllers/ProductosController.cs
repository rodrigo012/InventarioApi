using InventarioApi.DTOs;
using InventarioApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioApi.Controllers;

[ApiController]
[Route("api/productos")]
public class ProductosController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductosController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_productoService.GetAll());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var producto = _productoService.GetById(id);
        return producto is null ? NotFound() : Ok(producto);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateProductoDto productoDto)
    {
        var producto = _productoService.Create(productoDto);
        return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] CreateProductoDto productoDto)
    {
        return _productoService.Update(id, productoDto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        return _productoService.Delete(id) ? NoContent() : NotFound();
    }
}
