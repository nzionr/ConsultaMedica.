using ConsultaMedica.Models;
using System;
using System.Collections.Generic;

namespace ConsultaMedica.Repositories
{
    public interface IAgendamentoRepository
    {
        bool MedicoDisponivel(string idMedico, DateTime data);
        void CreateAgendamento(Agendamento agendamento);
        IEnumerable<Agendamento> GetAgendamentosByPacienteId(string pacienteId);
        IEnumerable<Agendamento> GetAgendamentosByMedicoId(string medicoId);
        Agendamento GetAgendamentoById(string agendamentoId);
        void DeleteAgendamento(Agendamento agendamento);
    }
}
