using EmpresaAPI.DbContext;
using EmpresaAPI.Models.Empleado;
using Microsoft.EntityFrameworkCore;

namespace EmpresaAPI.Repository.Empleado;

public class EmpleadoRepositorio : IEmpleadoRepositorio
{
    private readonly EmpresaApiContext _context;
    
    public EmpleadoRepositorio(EmpresaApiContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<EmpleadoModel>> ObtenerEmpleadosAsync()
    {
        return await _context.Empleados.ToListAsync();
    }

    public async Task<EmpleadoModel?> ObtenerEmpleadoPorIdAsync(long id)
    {
        return await _context.Empleados.FindAsync(id);
    }

    public async Task CrearEmpleadoAsync(EmpleadoModel empleado)
    {
        await _context.Empleados.AddAsync(empleado);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarEmpleadoAsync(EmpleadoModel empleado)
    {
        var empleado2 = await _context.Empleados.FindAsync(empleado.CuiEmpleado);
        empleado2.Nombre = empleado.Nombre;
        empleado2.Apellidos = empleado.Apellidos;
        empleado2.Telefono = empleado.Telefono;
        empleado2.correo = empleado.correo;
        empleado2.usuario = empleado.usuario;
        empleado2.contrasenya = empleado.contrasenya;
        empleado2.Puesto = empleado.Puesto;
        empleado2.Salario = empleado.Salario;
        empleado2.FechaUltimoAumento = empleado.FechaUltimoAumento;
        empleado2.FechaIngreso = empleado.FechaIngreso;
        empleado2.FechaBaja = empleado.FechaBaja;
        
        await _context.SaveChangesAsync();
    }
}