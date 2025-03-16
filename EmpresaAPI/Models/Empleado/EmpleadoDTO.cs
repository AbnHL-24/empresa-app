﻿namespace EmpresaAPI.Models.Empleado;

public class EmpleadoDTO
{
    public long CuiEmpleado { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string? Telefono { get; set; }
    public string? correo { get; set; }
    public string usuario { get; set; }
    public string contrasenya { get; set; }
    public int Puesto { get; set; }
    public double Salario { get; set; }
    public DateOnly? UltimoAumento { get; set; }
    public DateOnly FechaIngreso { get; set; }
    public DateOnly FechaBaja { get; set; }
}