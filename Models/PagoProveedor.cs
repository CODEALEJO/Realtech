using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RealtechOrden.Models
{
  public class PagoProveedor
{
    public int Id { get; set; }

    public int ProveedorId { get; set; }

    [ForeignKey("ProveedorId")]
    public Proveedor Proveedor { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
    public decimal Monto { get; set; }

    [Required]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [StringLength(250)]
    public string? Observacion { get; set; }
}

}