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

    public async Task<EmpleadoModel> ObtenerEmpleadoPorIdAsync(long id)
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
        _context.Empleados.Update(empleado);
        await _context.SaveChangesAsync();
    }
}