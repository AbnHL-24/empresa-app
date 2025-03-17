using EmpresaWebApp.Models.Empleado;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaWebApp.Controllers;

public class EmpleadoController : Controller
{
    private HttpClient _httpClient;
    
    public EmpleadoController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("EmpresaAPI");
    }

    public async Task<IActionResult> Index()
    {
        var empleados = await _httpClient.GetFromJsonAsync<IEnumerable<EmpleadoModel>>("empleado");

        if (empleados is null)
            return NotFound();
        
        return View(empleados);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var empleado = await _httpClient.GetFromJsonAsync<EmpleadoModel>($"empleado/{id}");
        
        if (empleado is null)
            return NotFound();
        
        return View(empleado);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EmpleadoModel empleado)
    {
        if (!ModelState.IsValid)
            return View(empleado);
        
        await _httpClient.PutAsJsonAsync($"empleado/{empleado.CuiEmpleado}",
            empleado);
        return RedirectToAction("Index");
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmpleadoModel empleado)
    {
        if (!ModelState.IsValid)
            return View(empleado);
        
        await _httpClient.PostAsJsonAsync("empleado", empleado);
        return RedirectToAction("Index");
    }
}