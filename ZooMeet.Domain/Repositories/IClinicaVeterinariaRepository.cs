using ZooMeet.Domain.Entities;

namespace ZooMeet.Domain.Repositories
{
    public interface IClinicaVeterinariaRepository
    {
        Task<ClinicaVeterinaria> ObterPorIdAsync(Guid id);
        Task<IEnumerable<ClinicaVeterinaria>> ObterTodasAsync();
        Task AdicionarAsync(ClinicaVeterinaria clinicaVeterinaria);
    }
}