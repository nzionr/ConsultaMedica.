using ConsultaMedica.DTOs;
using ConsultaMedica.Models;
using ConsultaMedica.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaMedica.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IEmailService _emailService;

        public AgendamentoService(
            IAgendamentoRepository agendamentoRepository,
            IMedicoRepository medicoRepository,
            IPacienteRepository pacienteRepository,
            IEmailService emailService)
        {
            _agendamentoRepository = agendamentoRepository;
            _medicoRepository = medicoRepository;
            _pacienteRepository = pacienteRepository;
            _emailService = emailService;
        }

        public async Task<Agendamento> AgendarConsulta(string idMedico, AgendamentoRequest request)
        {
            var medico = _medicoRepository.GetMedicoById(idMedico);
            if (medico == null)
            {
                throw new Exception("Médico não encontrado");
            }

            if (!_agendamentoRepository.MedicoDisponivel(idMedico, request.Data))
            {
                throw new Exception("Médico não está disponível nesta data");
            }

            var paciente = _pacienteRepository.GetPacienteById(request.PacienteId);
            if (paciente == null)
            {
                throw new Exception("Paciente não encontrado");
            }

            var agendamento = new Agendamento
            {
                Id = Guid.NewGuid().ToString(),
                Paciente = paciente,
                Medico = medico,
                Data = request.Data
            };

            _agendamentoRepository.CreateAgendamento(agendamento);

            var message = $"Olá {paciente.Nome}, sua consulta com o Dr(a). {medico.Nome} foi agendada para {request.Data}.";
            await _emailService.SendEmailAsync(paciente.Email, "Consulta Agendada", message);

            return agendamento;
        }

        public async Task<Agendamento> AgendarConsultaPorEspecialidade(string nomeEspecialidade, AgendamentoRequest request)
        {
            var medicos = _medicoRepository.GetMedicosByEspecialidade(nomeEspecialidade);
            var medico = medicos.FirstOrDefault(m => _agendamentoRepository.MedicoDisponivel(m.Id, request.Data));

            if (medico == null)
            {
                throw new Exception("Nenhum médico disponível nesta especialidade na data solicitada");
            }

            return await AgendarConsulta(medico.Id, request);
        }
    }
}
