using ConsultaMedica.Data;
using ConsultaMedica.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ConsultaMedica.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly AppDbContext _context;

        public PacienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public Paciente GetPacienteById(string id)
        {
            return _context.Pacientes.FirstOrDefault(p => p.Id == id);
        }

        public void CreatePaciente(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
        }
    }
}
