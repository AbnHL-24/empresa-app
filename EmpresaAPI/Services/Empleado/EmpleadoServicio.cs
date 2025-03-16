using EmpresaAPI.Models.Empleado;
using EmpresaAPI.Repository.Empleado;

namespace EmpresaAPI.Services.Empleado;

public class EmpleadoServicio : IEmpleadoServicio
{
    private readonly IEmpleadoRepositorio _empleadoRepositorio;
    
    public EmpleadoServicio(IEmpleadoRepositorio empleadoRepositorio)
    {
        _empleadoRepositorio = empleadoRepositorio;
    }
    
    public async Task<IEnumerable<EmpleadoModel>> ObtenerEmpleadosAsync()
    {
        return await _empleadoRepositorio.ObtenerEmpleadosAsync();
    }

    public async Task<EmpleadoModel> ObtenerEmpleadoPorIdAsync(int id)
    {
        return await _empleadoRepositorio.ObtenerEmpleadoPorIdAsync(id);
    }

    public async Task CrearEmpleadoAsync(EmpleadoModel empleado)
    {
        var existente = await _empleadoRepositorio.ObtenerEmpleadoPorIdAsync(empleado.CuiEmpleado);
        if (existente != null)
        {
            throw new ApplicationException("El empleado ya existe");
        }
        await _empleadoRepositorio.CrearEmpleadoAsync(empleado);
    }

    public async Task ActualizarEmpleadoAsync(long id, EmpleadoModel empleado)
    {
        var existente = await _empleadoRepositorio.ObtenerEmpleadoPorIdAsync(id);
        if (existente == null)
        {
            throw new ApplicationException("El empleado no existe");
        }
        var otro = await _empleadoRepositorio.ObtenerEmpleadoPorIdAsync(empleado.CuiEmpleado);
        if (otro != null && otro.CuiEmpleado != id)
        {
            throw new ApplicationException("El empleado ya existe");
        }
        existente.CuiEmpleado = empleado.CuiEmpleado;
        existente.Nombre = empleado.Nombre;
        existente.Apellidos = empleado.Apellidos;
        existente.Telefono = empleado.Telefono;
        existente.correo = empleado.correo;
        existente.usuario = empleado.usuario;
        existente.contrasenya = empleado.contrasenya;
        existente.Puesto = empleado.Puesto;
        existente.Salario = empleado.Salario;
        existente.FechaUltimoAumento = empleado.FechaUltimoAumento;
        existente.FechaIngreso = empleado.FechaIngreso;
        existente.FechaBaja = empleado.FechaBaja;
        await _empleadoRepositorio.ActualizarEmpleadoAsync(empleado);
    }
}