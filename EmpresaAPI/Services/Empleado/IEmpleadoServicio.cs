using EmpresaAPI.Models.Empleado;

namespace EmpresaAPI.Services.Empleado;

public interface IEmpleadoServicio
{
    Task<IEnumerable<EmpleadoModel>> ObtenerEmpleadosAsync();
    Task<EmpleadoModel> ObtenerEmpleadoPorIdAsync(int id);
    Task CrearEmpleadoAsync(EmpleadoModel empleado);
    Task ActualizarEmpleadoAsync(long id, EmpleadoModel empleado);
    Task ActualizarSalarioAsync(long id, int porcentaje, EmpleadoModel empleado);
}