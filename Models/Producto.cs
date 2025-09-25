using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RealtechOrden.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser un número positivo")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El costo es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El costo debe ser mayor a 0")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Costo { get; set; }

        [Required(ErrorMessage = "El precio de venta es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio de venta debe ser mayor a 0")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioVenta { get; set; }

        [Required(ErrorMessage = "El IMEI es obligatorio")]
        [StringLength(20, ErrorMessage = "El IMEI no puede exceder los 20 caracteres")]
        public string IMEI { get; set; } = string.Empty;

        public int ProveedorId { get; set; }

        [ForeignKey("ProveedorId")]
        public Proveedor Proveedor { get; set; }

        [Required]
        public DateTime FechaIngreso { get; set; } = DateTime.Now;

        [Required]
        public EstadoProducto Estado { get; set; } = EstadoProducto.Disponible;

        // Propiedades calculadas
        [NotMapped]
        public decimal GananciaPorUnidad => PrecioVenta - Costo;

        [NotMapped]
        public decimal GananciaTotal => GananciaPorUnidad * Cantidad;

        [NotMapped]
        public string CostoFormateado => Costo.ToString("N0", new System.Globalization.CultureInfo("es-CO"));

        [NotMapped]
        public string PrecioVentaFormateado => PrecioVenta.ToString("N0", new System.Globalization.CultureInfo("es-CO"));

        [NotMapped]
        public string GananciaPorUnidadFormateado => GananciaPorUnidad.ToString("N0", new System.Globalization.CultureInfo("es-CO"));

        [NotMapped]
        public string GananciaTotalFormateado => GananciaTotal.ToString("N0", new System.Globalization.CultureInfo("es-CO"));
    }

}