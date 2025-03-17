using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EmpresaWebApp.Models.Departamento;

public class DepartamentoModel
{
    [Key]
    [JsonPropertyName("id_departamento")]
    [Column("id_departamento")]
    public int IdDepartamento { get; set; }
    
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(75, ErrorMessage = "El nombre debe tener menos de 75 caracteres")]
    [JsonPropertyName("nombre")]
    [Column("nombre")]
    public string Nombre { get; set; }
    
    [Range(0, double.MaxValue, ErrorMessage = "El presupuesto debe ser mayor o igual a 0")]
    [JsonPropertyName("presupuesto")]
    [Column("presupuesto")]
    public decimal Presupuesto { get; set; }
}