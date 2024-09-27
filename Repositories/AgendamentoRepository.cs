using ConsultaMedica.Data;
using ConsultaMedica.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsultaMedica.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly AppDbContext _context;

        public AgendamentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool MedicoDisponivel(string idMedico, DateTime data)
        {
            return !_context.Agendamentos.Any(a => a.Medico.Id == idMedico && a.Data.Date == data.Date);
        }

        public void CreateAgendamento(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            _context.SaveChanges();
        }

        public IEnumerable<Agendamento> GetAgendamentosByPacienteId(string pacienteId)
        {
            return _context.Agendamentos
                .Include(a => a.Paciente)
                .Include(a => a.Medico)
                .Where(a => a.Paciente.Id == pacienteId)
                .ToList();
        }

        public IEnumerable<Agendamento> GetAgendamentosByMedicoId(string medicoId)
        {
            return _context.Agendamentos
                .Include(a => a.Paciente)
                .Include(a => a.Medico)
                .Where(a => a.Medico.Id == medicoId)
                .ToList();
        }

        public Agendamento GetAgendamentoById(string agendamentoId)
        {
            return _context.Agendamentos
                .Include(a => a.Paciente)
                .Include(a => a.Medico)
                .FirstOrDefault(a => a.Id == agendamentoId);
        }

        public void DeleteAgendamento(Agendamento agendamento)
        {
            _context.Agendamentos.Remove(agendamento);
            _context.SaveChanges();
        }
    }
}
