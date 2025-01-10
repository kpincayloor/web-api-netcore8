using Application.Interfaces;
using Domain.Entities;
using Infra.Data.Repositories.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly ILogger<PersonaService> _logger;

        public PersonaService(IPersonaRepository personaRepository, ILogger<PersonaService> logger)
        {
            _personaRepository = personaRepository;
            _logger = logger;
        }

        public IEnumerable<Persona> GetAll()
        {
            _logger.LogInformation("Obteniendo todas las personas.");
            return _personaRepository.GetAll();
        }
        public Persona GetById(int id)
        {
            var persona = _personaRepository.GetById(id);
            if (persona == null)
            {
                throw new KeyNotFoundException("Persona no encontrada.");
            }
            return persona;
        }

        public void Add(Persona persona)
        {
            _logger.LogInformation("Agregando persona: {Persona}", persona);
            _personaRepository.Add(persona);
        }

        public void Update(Persona persona)
        {
            _personaRepository.Update(persona);
        }

        public void Delete(int id)
        {
            _logger.LogWarning("Eliminando persona con ID {Id}", id);
            _personaRepository.Delete(id);
        }
    }
}