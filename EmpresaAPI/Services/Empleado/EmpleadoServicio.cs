using System.Runtime.InteropServices.JavaScript;
using EmpresaAPI.Models.AumentoSalario;
using EmpresaAPI.Models.Empleado;
using EmpresaAPI.Repository.AumentoSalario;
using EmpresaAPI.Repository.Empleado;

namespace EmpresaAPI.Services.Empleado;

public class EmpleadoServicio : IEmpleadoServicio
{
    private readonly IEmpleadoRepositorio _empleadoRepositorio;
    private readonly IAumentoSalarioRepositorio _aumentoSalarioRepositorio;
    
    public EmpleadoServicio(IEmpleadoRepositorio empleadoRepositorio, IAumentoSalarioRepositorio aumentoSalarioRepositorio)
    {
        _empleadoRepositorio = empleadoRepositorio;
        _aumentoSalarioRepositorio = aumentoSalarioRepositorio;
    }
    
    public async Task<IEnumerable<EmpleadoModel>> ObtenerEmpleadosAsync()
    {
        return await _empleadoRepositorio.ObtenerEmpleadosAsync();
    }

    public async Task<EmpleadoModel> ObtenerEmpleadoPorIdAsync(int id)
    {
        var empleado = await _empleadoRepositorio.ObtenerEmpleadoPorIdAsync(id);

        if (empleado is null)
        {
            throw new ApplicationException($"El empleado con {id} no existe");
        }
        
        return empleado;
    }

    public async Task CrearEmpleadoAsync(EmpleadoModel empleado)
    {
        var empleadoDb = await _empleadoRepositorio.ObtenerEmpleadoPorIdAsync(empleado.CuiEmpleado);
        if (empleadoDb != null)
            throw new ApplicationException("El empleado ya existe");
        
        empleadoDb = await _empleadoRepositorio.ObtenerEmpleadoPorIdAsync(empleado.CuiEmpleado);
        if (empleadoDb != null)
            throw new ApplicationException("El empleado con el cui ingresado ya existe");
        
        await _empleadoRepositorio.CrearEmpleadoAsync(empleado);
    }

    public async Task ActualizarEmpleadoAsync(long id, EmpleadoModel empleado)
    {
        var empleadoDb = await _empleadoRepositorio.ObtenerEmpleadoPorIdAsync(id);
        if (empleadoDb == null)
        {
            throw new ApplicationException($"El empleado con el cui: {id} no existe");
        }
        var otro = await _empleadoRepositorio.ObtenerEmpleadoPorIdAsync(empleado.CuiEmpleado);
        if (otro != null && otro.CuiEmpleado != id)
        {
            throw new ApplicationException("El empleado con el cui ingresado ya existe");
        }
        /*empleadoDb.CuiEmpleado = empleado.CuiEmpleado;
        empleadoDb.Nombre = empleado.Nombre;
        empleadoDb.Apellidos = empleado.Apellidos;
        empleadoDb.Telefono = empleado.Telefono;
        empleadoDb.correo = empleado.correo;
        empleadoDb.usuario = empleado.usuario;
        empleadoDb.contrasenya = empleado.contrasenya;
        empleadoDb.Puesto = empleado.Puesto;
        empleadoDb.Salario = empleado.Salario;
        empleadoDb.FechaUltimoAumento = empleado.FechaUltimoAumento;
        empleadoDb.FechaIngreso = empleado.FechaIngreso;
        empleadoDb.FechaBaja = empleado.FechaBaja;*/
        await _empleadoRepositorio.ActualizarEmpleadoAsync(empleado);
    }

    public async Task ActualizarSalarioAsync(long id, int porcentaje, EmpleadoModel empleado)
    {
        var empleadoDb = await _empleadoRepositorio.ObtenerEmpleadoPorIdAsync(id);
        if (empleadoDb == null)
        {
            throw new ApplicationException($"El empleado con el cui: {id} no existe");
        }
        var otro = await _empleadoRepositorio.ObtenerEmpleadoPorIdAsync(empleado.CuiEmpleado);
        if (otro != null && otro.CuiEmpleado != id)
        {
            throw new ApplicationException("El empleado con el cui ingresado ya existe");
        }
        double salarioAnterior = empleadoDb.Salario;
        double nuevoSalario = empleadoDb.Salario + (empleadoDb.Salario * (porcentaje / 100));
        var fechaActual = DateOnly.FromDateTime(DateTime.Now);
        empleadoDb.Salario = nuevoSalario;
        AumentoSalarioModel aumentoSalario = new AumentoSalarioModel(id, nuevoSalario, porcentaje, fechaActual);
        await _empleadoRepositorio.ActualizarEmpleadoAsync(empleadoDb);
        await _aumentoSalarioRepositorio.CrearAumentoSalario(aumentoSalario);
    }
}