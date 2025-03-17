using EmpresaWebApp.Models.Departamento;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaWebApp.Controllers.Departamento;

public class DepartamentoController : Controller
{
    private HttpClient _httpClient;

    public DepartamentoController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("EmpresaAPI");
    }

    public async Task<IActionResult> Index()
    {
        var departamentos = await _httpClient.GetFromJsonAsync<IEnumerable<DepartamentoModel>>("departamento");
        
        if (departamentos is null)
            return NotFound();

        return View(departamentos);
    }

    public async Task<IActionResult> Edit(long id)
    {
        var departamento = await _httpClient.GetFromJsonAsync<DepartamentoModel>($"departamento/{id}");
        
        if (departamento is null)
            return NotFound();

        return View(departamento);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(DepartamentoModel departamento)
    {
        if (!ModelState.IsValid)
            return View(departamento);

        await _httpClient.PutAsJsonAsync($"departamento/{departamento.IdDepartamento}", departamento);
        return RedirectToAction("Index");
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(DepartamentoModel departamento)
    {
        if (!ModelState.IsValid)
            return View(departamento);

        await _httpClient.PostAsJsonAsync("departamento", departamento);
        return RedirectToAction("Index");
    }
}