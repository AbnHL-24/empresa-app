using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;

namespace EmpresaAPI.Models.AumentoSalario;

public class AumentoSalarioModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonPropertyName("id_aumento_salario")]
    public int IdAumentoSalario { get; set; }
    
    [Required(ErrorMessage = "El campo CUI de empleado es obligatorio")]
    [JsonPropertyName("fk_cui_empleado")]
    public long FkCuiEmpleado { get; set; }
    
    [Required(ErrorMessage = "El campo salario es obligatorio")]
    [JsonPropertyName("salario")]
    public double Salario { get; set; }
    
    [Required(ErrorMessage = "El campo porcentaje de aumento es obligatorio")]
    [JsonPropertyName("porcentaje_aumentado")]
    public double PorcentajeAumentado { get; set; }
    
    [Required(ErrorMessage = "La fecha del aumento es obligatoria")]
    [JsonPropertyName("fecha_del_aumento")]
    public DateOnly FechaDelAumento { get; set; }

    public AumentoSalarioModel(long fkCuiEmpleado, double salario, double porcentajeAumentado, DateOnly fechaDelAumento)
    {
        FkCuiEmpleado = fkCuiEmpleado;
        Salario = salario;
        PorcentajeAumentado = porcentajeAumentado;
        FechaDelAumento = fechaDelAumento;
    }
}