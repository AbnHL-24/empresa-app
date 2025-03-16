using EmpresaAPI.Models.Departamento;
using EmpresaAPI.Services.Departamento;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaAPI.Controllers.Departamento;

[Route("api/[controller]")]
[ApiController]
public class DepartamentoController : ControllerBase
{
    private readonly IDepartamentoServicio _departamentoServicio;
    
    public DepartamentoController(IDepartamentoServicio departamentoServicio)
    {
        _departamentoServicio = departamentoServicio;
    }
    
    // Metodo para obtener todos los departamentos.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartamentoModel>>> ObtenerDepartamentosAsync()
    {
        var departamentos = await _departamentoServicio.ObtenerDepartamentosAsync();
        return Ok(departamentos);
    }
    
    // Metodo para obtener un departamento por ID.
    [HttpGet("{id}")]
    public async Task<ActionResult<DepartamentoModel>> ObtenerDepartamentoPorIdAsync(int id)
    {
        var departamento = await _departamentoServicio.ObtenerDepartamentoPorIdAsync(id);
        if (departamento == null)
        {
            return NotFound(new {message = "Departamento no encontrado"});
        }
        return Ok(departamento);
    }
    
    // Metodo para crear un nuevo departamento.
    [HttpPost]
    public async Task<ActionResult> Crear([FromBody] DepartamentoModel departamento)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _departamentoServicio.CrearAsync(departamento);
            return CreatedAtAction(nameof(ObtenerDepartamentoPorIdAsync), new { id = departamento.IdDepartamento }, departamento);
        }
        catch (AggregateException e)
        {
            return Conflict(new { message = e.Message });
        }
    }
    
    // Metodo para actualizar un departamento existente.
    [HttpPut("{id}")]
    public async Task<ActionResult> Actualizar(int id, [FromBody] DepartamentoModel departamento)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _departamentoServicio.ActualizarAsync(id, departamento);
            return NoContent();
        }
        catch (ApplicationException e)
        {
            return NotFound(new {message = e.Message});
        }
    }
}