using EmpresaAPI.Models.Empleado;
using EmpresaAPI.Repository.Empleado;
using EmpresaAPI.Services.Empleado;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaAPI.Controllers.Empleado;

[Route("api/[controller]")]
[ApiController]
public class EmpleadoController : ControllerBase
{
    private readonly IEmpleadoServicio _empleadoServicio;
    
    public EmpleadoController(IEmpleadoServicio empleadoServicio)
    {
        _empleadoServicio = empleadoServicio;
    }
    
    // Metodo para obtener todos los empleados.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmpleadoModel>>> ObtenerEmpleadosAsync()
    {
        var empleados = await _empleadoServicio.ObtenerEmpleadosAsync();
        return Ok(empleados);
    }
    
    // MEtodo para obtener un departamento por ID.
    [HttpGet("{id}")]
    public async Task<ActionResult<EmpleadoModel>> ObtenerEmpleadoPorIdAsync(int id)
    {
        var empleado = await _empleadoServicio.ObtenerEmpleadoPorIdAsync(id);
        return Ok(empleado);
    }
    
    // Metodo para crear un nuevo departamento.
    [HttpPost]
    public async Task<ActionResult> Crear([FromBody] EmpleadoModel empleado)
    {
        try
        {
            await _empleadoServicio.CrearEmpleadoAsync(empleado);
            return CreatedAtAction(nameof(ObtenerEmpleadoPorIdAsync), new { id = empleado.CuiEmpleado }, empleado);
        }
        catch (Exception e)
        {
            return Conflict(new { message = e.Message });
        }
    }
    
    // Medoto para actualizar un departamento existente
    [HttpPut("{id}")]
    public async Task<ActionResult> Actualizar(long id, [FromBody] EmpleadoModel empleado)
    {
        try
        {
            await _empleadoServicio.ActualizarEmpleadoAsync(id, empleado);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(new {message = e.Message});
        }
    }

    [HttpPut("{id}/aumento")]
    public async Task<ActionResult> ActualizarSalario(long id,[FromQuery] int porcentaje, [FromBody] EmpleadoModel empleado)
    {
        try
        {
            await _empleadoServicio.ActualizarSalarioAsync(id, porcentaje, empleado);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(new {message = e.Message});
        }
    }
}