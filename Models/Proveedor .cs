using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RealtechOrden.Models
{
    public class Proveedor
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    // Navegación: Productos que se le compraron
    public ICollection<Producto> Productos { get; set; } = new List<Producto>();

    // Navegación: Pagos realizados a este proveedor
    public ICollection<PagoProveedor> Pagos { get; set; } = new List<PagoProveedor>();

    // Cálculo del saldo pendiente
    [NotMapped]
    public decimal SaldoPendiente =>
        Productos.Sum(p => p.Costo * p.Cantidad) - Pagos.Sum(p => p.Monto);
}

}