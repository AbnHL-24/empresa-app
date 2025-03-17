using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EmpresaAPI.Models.Empleado;

[Table("empleado")]
public class EmpleadoModel
{
    [Key]
    [JsonPropertyName("cui_empleado")]
    [Column("cui_empleado")]
    public long CuiEmpleado { get; set; }
    
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre debe tener menos de 100 caracteres")]
    [JsonPropertyName("nombre")]
    [Column("nombre")]
    public string Nombre { get; set; }
    
    [Required(ErrorMessage = "Los apellidos son obligatorios")]
    [StringLength(125, ErrorMessage = "Los apellidos deben tener menos de 125 caracteres")]
    [JsonPropertyName("apellidos")]
    [Column("apellidos")]
    public string Apellidos { get; set; }
    
    [Range(0, int.MaxValue, ErrorMessage = "El telefono no puede ser un numero negativo")]
    [JsonPropertyName("telefono")]
    [Column("telefono")]
    public int? Telefono { get; set; }
    
    [StringLength(50, ErrorMessage = "El correo debe tener menos de 50 caracteres")]
    [JsonPropertyName("correo")]
    [Column("correo")]
    public string? correo { get; set; }
    
    [Required(ErrorMessage = "El usuario es obligatorio")]
    [StringLength(50, ErrorMessage = "El usuario debe tener menos de 50 caracteres")]
    [JsonPropertyName("usuario")]
    [Column("usuario")]
    public string usuario { get; set; }
    
    [Required(ErrorMessage = "La constraseña es obligatoria")]
    [StringLength(255, ErrorMessage = "La contraseña debe tener menos de 255 caracteres")]
    [JsonPropertyName("contrasenya")]
    [Column("contrasenya")]
    public string contrasenya { get; set; }
    
    [Required(ErrorMessage = "El puesto es obligatorio")]
    [Range(0, int.MaxValue, ErrorMessage = "El puesto debe corresponder a un numero positivo")]
    [JsonPropertyName("fk_id_puesto")]
    [Column("fk_id_puesto")]
    public int Puesto { get; set; }
    
    [Required(ErrorMessage = "El departamento es obligatorio")]
    [Range(0, double.MaxValue, ErrorMessage = "El departamento debe corresponder a un numero positivo")]
    [JsonPropertyName("salario")]
    [Column("salario")]
    public double Salario { get; set; }
    
    [JsonPropertyName("fecha_ultimo_aumento")]
    [Column("fecha_ultimo_aumento")]
    public DateTime? FechaUltimoAumento { get; set; }
    
    [Required(ErrorMessage = "La fecha de ingreso es obligatoria")]
    [JsonPropertyName("fecha_ingreso")]
    [Column("fecha_ingreso")]
    public DateTime? FechaIngreso { get; set; }
    
    [JsonPropertyName("fecha_de_baja")]
    [Column("fecha_de_baja")]
    public DateTime? FechaBaja { get; set; }
}