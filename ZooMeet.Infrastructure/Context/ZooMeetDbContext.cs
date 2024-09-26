using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using ZooMeet.Domain.Entities;

namespace ZooMeet.Infrastructure.Context
{
    public class ZooMeetDbContext : DbContext
    {
        public DbSet<ClinicaVeterinaria> ClinicasVeterinarias { get; set; }

        public ZooMeetDbContext(DbContextOptions<ZooMeetDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração adicional para a entidade ClinicaVeterinaria
            modelBuilder.Entity<ClinicaVeterinaria>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Nome).IsRequired().HasMaxLength(150);
                entity.Property(c => c.Endereco).IsRequired().HasMaxLength(300);
                entity.Property(c => c.Cidade).IsRequired().HasMaxLength(100);
            });
        }
    }
}