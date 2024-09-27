using ConsultaMedica.Data;
using ConsultaMedica.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConsultaMedica.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly AppDbContext _context;

        public MedicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Medico GetMedicoById(string id)
        {
            return _context.Medicos.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Medico> GetMedicosByEspecialidade(string especialidade)
        {
            return _context.Medicos.Where(m => m.Especialidade == especialidade).ToList();
        }
    }
}
