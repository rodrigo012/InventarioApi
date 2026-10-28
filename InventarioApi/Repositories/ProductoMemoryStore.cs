using InventarioApi.Models;

namespace InventarioApi.Repositories;

public class ProductoMemoryStore
{
    private readonly List<Producto> _productos =
    [
        new Producto { Id = 1, Nombre = "Teclado mecánico", Precio = 85000m, Categoria = "Informática", Activo = true },
        new Producto { Id = 2, Nombre = "Mouse inalámbrico", Precio = 32000m, Categoria = "Informática", Activo = true },
        new Producto { Id = 3, Nombre = "Monitor 24 pulgadas", Precio = 210000m, Categoria = "Pantallas", Activo = true },
        new Producto { Id = 4, Nombre = "Auriculares Bluetooth", Precio = 67000m, Categoria = "Audio", Activo = false }
    ];

    public List<Producto> Productos => _productos;
}
