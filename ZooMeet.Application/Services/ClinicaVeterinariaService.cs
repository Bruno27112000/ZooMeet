using ZooMeet.Domain.Entities;
using ZooMeet.Domain.Repositories;

namespace ZooMeet.Application.Services
{
    public class ClinicaVeterinariaService
    {
        private readonly IClinicaVeterinariaRepository _clinicaVeterinariaRepository;

        public ClinicaVeterinariaService(IClinicaVeterinariaRepository clinicaVeterinariaRepository)
        {
            _clinicaVeterinariaRepository = clinicaVeterinariaRepository;
        }

        public async Task<IEnumerable<ClinicaVeterinaria>> ObterTodas()
        {
            return await _clinicaVeterinariaRepository.ObterTodasAsync();
        }

        public async Task<ClinicaVeterinaria> ObterPorId(Guid id)
        {
            return await _clinicaVeterinariaRepository.ObterPorIdAsync(id);
        }

        public async Task AdicionarClinica(ClinicaVeterinaria clinicaVeterinaria)
        {
            await _clinicaVeterinariaRepository.AdicionarAsync(clinicaVeterinaria);
        }
    }
}