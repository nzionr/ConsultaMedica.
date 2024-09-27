using ConsultaMedica.Models;
using ConsultaMedica.Repositories;
using System.Collections.Generic;

namespace ConsultaMedica.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public Medico GetMedicoById(string id)
        {
            return _medicoRepository.GetMedicoById(id);
        }

        public IEnumerable<Medico> GetMedicosByEspecialidade(string especialidade)
        {
            return _medicoRepository.GetMedicosByEspecialidade(especialidade);
        }
    }
}
