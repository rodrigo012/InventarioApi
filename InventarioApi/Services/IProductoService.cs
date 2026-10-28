using InventarioApi.DTOs;

namespace InventarioApi.Services;

public interface IProductoService
{
    IEnumerable<ProductoDto> GetAll();

    ProductoDto? GetById(int id);

    ProductoDto Create(CreateProductoDto productoDto);

    bool Update(int id, CreateProductoDto productoDto);

    bool Delete(int id);
}
