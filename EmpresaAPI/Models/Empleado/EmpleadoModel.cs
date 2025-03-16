using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmpresaAPI.Models.Empleado;

public class EmpleadoModel
{
    [Key]
    [JsonPropertyName("cui_empleado")]
    public long CuiEmpleado { get; set; }
    
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre debe tener menos de 100 caracteres")]
    [JsonPropertyName("nombre")]
    public string Nombre { get; set; }
    
    [Required(ErrorMessage = "Los apellidos son obligatorios")]
    [StringLength(125, ErrorMessage = "Los apellidos deben tener menos de 125 caracteres")]
    [JsonPropertyName("apellidos")]
    public string Apellidos { get; set; }
    
    [Range(0, int.MaxValue, ErrorMessage = "El telefono no puede ser un numero negativo")]
    [JsonPropertyName("telefono")]
    public string? Telefono { get; set; }
    
    [StringLength(50, ErrorMessage = "El correo debe tener menos de 50 caracteres")]
    [JsonPropertyName("correo")]
    public string? correo { get; set; }
    
    [Required(ErrorMessage = "El usuario es obligatorio")]
    [StringLength(50, ErrorMessage = "El usuario debe tener menos de 50 caracteres")]
    [JsonPropertyName("usuario")]
    public string usuario { get; set; }
    
    [Required(ErrorMessage = "La constraseña es obligatoria")]
    [StringLength(255, ErrorMessage = "La contraseña debe tener menos de 255 caracteres")]
    [JsonPropertyName("contrasenya")]
    public string contrasenya { get; set; }
    
    [Required(ErrorMessage = "El puesto es obligatorio")]
    [Range(0, int.MaxValue, ErrorMessage = "El puesto debe corresponder a un numero positivo")]
    [JsonPropertyName("fk_id_puesto")]
    public int Puesto { get; set; }
    
    [Required(ErrorMessage = "El departamento es obligatorio")]
    [Range(0, int.MaxValue, ErrorMessage = "El departamento debe corresponder a un numero positivo")]
    [JsonPropertyName("salario")]
    public double Salario { get; set; }
    
    [JsonPropertyName("fecha_ultimo_aumento")]
    public DateOnly? FechaUltimoAumento { get; set; }
    
    [Required(ErrorMessage = "La fecha de ingreso es obligatoria")]
    [JsonPropertyName("fecha_ingreso")]
    public DateOnly FechaIngreso { get; set; }
    
    [JsonPropertyName("fecha_de_baja")]
    public DateOnly FechaBaja { get; set; }
}