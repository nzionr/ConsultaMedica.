using ConsultaMedica.Models;
using ConsultaMedica.Repositories;
using System;
using System.Collections.Generic;

namespace ConsultaMedica.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;

        public ConsultaService(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public IEnumerable<Agendamento> ObterConsultasPorPaciente(string pacienteId)
        {
            return _agendamentoRepository.GetAgendamentosByPacienteId(pacienteId);
        }

        public IEnumerable<Agendamento> ObterConsultasPorMedico(string medicoId)
        {
            return _agendamentoRepository.GetAgendamentosByMedicoId(medicoId);
        }

        public void CancelarConsulta(string agendamentoId)
        {
            var agendamento = _agendamentoRepository.GetAgendamentoById(agendamentoId);
            if (agendamento == null)
            {
                throw new Exception("Agendamento não encontrado");
            }

            _agendamentoRepository.DeleteAgendamento(agendamento);
        }
    }
}
