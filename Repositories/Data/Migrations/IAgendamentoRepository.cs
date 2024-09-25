using ConsultaMedica.Data;
using ConsultaMedica.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultaMedica.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly AppDbContext _context;

        public AgendamentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateAgendamento(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            _context.SaveChanges();
        }

        public bool MedicoDisponivel(string idMedico, DateTime data)
        {
            return !_context.Agendamentos.Any(a => a.Medico.Id == idMedico && a.Data == data);
        }
    }
}
