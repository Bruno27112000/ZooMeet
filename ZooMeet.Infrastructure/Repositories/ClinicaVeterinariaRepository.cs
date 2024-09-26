using Microsoft.EntityFrameworkCore;
using ZooMeet.Domain.Entities;
using ZooMeet.Domain.Repositories;
using ZooMeet.Infrastructure.Context;

namespace ZooMeet.Infrastructure.Repositories
{
    public class ClinicaVeterinariaRepository : IClinicaVeterinariaRepository
    {
        private readonly ZooMeetDbContext _context;

        public ClinicaVeterinariaRepository(ZooMeetDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClinicaVeterinaria>> ObterTodasAsync()
        {
            return await _context.ClinicasVeterinarias.ToListAsync();
        }

        public async Task<ClinicaVeterinaria> ObterPorIdAsync(Guid id)
        {
            return await _context.ClinicasVeterinarias.FindAsync(id);
        }
        public async Task AdicionarAsync(ClinicaVeterinaria clinicaVeterinaria)
        {
            await _context.ClinicasVeterinarias.AddAsync(clinicaVeterinaria);
            await _context.SaveChangesAsync();
        }
    }
}