using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZooMeet.Application.Services;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ClinicasVeterinariasController : ControllerBase
{
    private readonly ClinicaVeterinariaService _clinicaVeterinariaService;

    public ClinicasVeterinariasController(ClinicaVeterinariaService clinicaVeterinariaService)
    {
        _clinicaVeterinariaService = clinicaVeterinariaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clinicas = await _clinicaVeterinariaService.ObterTodas();
        return Ok(clinicas);
    }
}