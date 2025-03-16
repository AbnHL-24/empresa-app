using EmpresaAPI.Models.Empleado;
using EmpresaAPI.Repository.Empleado;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaAPI.Controllers.Empleado;

[Route("ape/[controller]")]
[ApiController]
public class EmpleadoController : ControllerBase
{
    private readonly IEmpleadoRepositorio _empleadoRepositorio;
    
    public EmpleadoController(IEmpleadoRepositorio empleadoRepositorio)
    {
        _empleadoRepositorio = empleadoRepositorio;
    }
    
    // Metodo para obtener todos los empleados.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmpleadoModel>>> ObtenerEmpleadosAsync()
    {
        var data = await _empleadoRepositorio.ObtenerEmpleadosAsync();
        return Ok(data);
    }
    
    // MEtodo para obtener un departamento por ID.
    [HttpGet("{id}")]
    public async Task<ActionResult<EmpleadoModel>> ObtenerEmpleadoPorIdAsync(int id)
    {
        var empleado = await _empleadoRepositorio.ObtenerEmpleadoPorIdAsync(id);
        if (empleado == null)
        {
            return NotFound(new {message = "Empleado no encontrado"});
        }
        return Ok(empleado);
    }
    
    // Metodo para crear un nuevo departamento.
    [HttpPost]
    public async Task<ActionResult> Crear([FromBody] EmpleadoModel empleado)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            await _empleadoRepositorio.CrearEmpleadoAsync(empleado);
            return CreatedAtAction(nameof(ObtenerEmpleadoPorIdAsync), new { id = empleado.CuiEmpleado }, empleado);
        }
        catch (Exception e)
        {
            return Conflict(new { message = e.Message });
        }
    }
    
    // Medoto para actualizar un departamento existente
    [HttpPut("{id}")]
    public async Task<ActionResult> Actualizar([FromBody] EmpleadoModel empleado)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _empleadoRepositorio.ActualizarEmpleadoAsync(empleado);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(new {message = e.Message});
        }
    }
}