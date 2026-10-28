using InventarioApi.Models;

namespace InventarioApi.Repositories;

public class ProductoRepositoryMemory : IProductoRepository
{
    private readonly ProductoMemoryStore _store;

    public ProductoRepositoryMemory(ProductoMemoryStore store)
    {
        _store = store;
    }

    public IEnumerable<Producto> GetAll()
    {
        return _store.Productos.ToList();
    }

    public Producto? GetById(int id)
    {
        return _store.Productos.FirstOrDefault(producto => producto.Id == id);
    }

    public Producto Add(Producto producto)
    {
        producto.Id = _store.Productos.Count == 0
            ? 1
            : _store.Productos.Max(productoExistente => productoExistente.Id) + 1;

        _store.Productos.Add(producto);
        return producto;
    }

    public bool Update(Producto producto)
    {
        var productoExistente = GetById(producto.Id);
        if (productoExistente is null)
        {
            return false;
        }

        productoExistente.Nombre = producto.Nombre;
        productoExistente.Precio = producto.Precio;
        productoExistente.Categoria = producto.Categoria;
        productoExistente.Activo = producto.Activo;

        return true;
    }

    public bool Delete(int id)
    {
        var producto = GetById(id);
        return producto is not null && _store.Productos.Remove(producto);
    }
}
