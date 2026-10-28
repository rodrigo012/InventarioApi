using System.ComponentModel.DataAnnotations;

namespace InventarioApi.DTOs;

public class CreateProductoDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
    public decimal Precio { get; set; }

    [Required]
    public string Categoria { get; set; } = string.Empty;

    public bool Activo { get; set; }
}
