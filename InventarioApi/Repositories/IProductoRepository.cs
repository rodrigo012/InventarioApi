using InventarioApi.Models;

namespace InventarioApi.Repositories;

public interface IProductoRepository
{
    IEnumerable<Producto> GetAll();

    Producto? GetById(int id);

    Producto Add(Producto producto);

    bool Update(Producto producto);

    bool Delete(int id);
}
