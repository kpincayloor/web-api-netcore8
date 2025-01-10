using Domain.Entities;
using Infra.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly AppDbContext _context;

        public PersonaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Persona> GetAll()
        {
            return _context.Personas.ToList();
        }

        public Persona GetById(int id)
        {
            return _context.Personas
                .FirstOrDefault(u => u.Id == id);
        }

        public void Add(Persona persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();
        }

        public void Update(Persona persona)
        {
            _context.Personas.Update(persona);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var persona = GetById(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                _context.SaveChanges();
            }
        }
    }
}
