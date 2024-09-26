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

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var clinicas = await _clinicaVeterinariaService.ObterTodas();
        return Ok(clinicas);
    }

    [HttpGet("GetVeterinaryById")]
    public async Task<IActionResult> GetVeterinaryById(Guid id)
    {
        var clinica = await _clinicaVeterinariaService.ObterPorId(id);
        return Ok(clinica);
    }
}