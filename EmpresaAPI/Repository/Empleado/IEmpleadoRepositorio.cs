using EmpresaAPI.Models.Empleado;

namespace EmpresaAPI.Repository.Empleado;

public interface IEmpleadoRepositorio
{
    Task<IEnumerable<EmpleadoModel>> ObtenerEmpleadosAsync();
    Task<EmpleadoModel> ObtenerEmpleadoAsync(int id);
    Task CrearEmpleadoAsync(EmpleadoModel empleado);
    Task ActualizarEmpleadoAsync(EmpleadoModel empleado);
}