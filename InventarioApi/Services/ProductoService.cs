using InventarioApi.DTOs;
using InventarioApi.Models;
using InventarioApi.Repositories;

namespace InventarioApi.Services;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _productoRepository;

    public ProductoService(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }

    public IEnumerable<ProductoDto> GetAll()
    {
        return _productoRepository.GetAll().Select(MapToDto).ToList();
    }

    public ProductoDto? GetById(int id)
    {
        var producto = _productoRepository.GetById(id);
        return producto is null ? null : MapToDto(producto);
    }

    public ProductoDto Create(CreateProductoDto productoDto)
    {
        var producto = new Producto
        {
            Nombre = productoDto.Nombre,
            Precio = productoDto.Precio,
            Categoria = productoDto.Categoria,
            Activo = productoDto.Activo
        };

        return MapToDto(_productoRepository.Add(producto));
    }

    public bool Update(int id, CreateProductoDto productoDto)
    {
        var producto = new Producto
        {
            Id = id,
            Nombre = productoDto.Nombre,
            Precio = productoDto.Precio,
            Categoria = productoDto.Categoria,
            Activo = productoDto.Activo
        };

        return _productoRepository.Update(producto);
    }

    public bool Delete(int id)
    {
        return _productoRepository.Delete(id);
    }

    private static ProductoDto MapToDto(Producto producto)
    {
        return new ProductoDto
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            Categoria = producto.Categoria,
            Activo = producto.Activo
        };
    }
}
