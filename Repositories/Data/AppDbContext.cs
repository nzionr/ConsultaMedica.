using ConsultaMedica.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultaMedica.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
