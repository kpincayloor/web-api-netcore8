



using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPersonaService
    {
        /// <summary>
        /// Obtiene todas las personas.
        /// </summary>
        IEnumerable<Persona> GetAll();

        /// <summary>
        /// Obtiene una persona por su identificador.
        /// </summary>
        Persona GetById(int id);

        /// <summary>
        /// Crea una nueva persona.
        /// </summary>
        void Add(Persona persona);

        /// <summary>
        /// Actualiza una persona existente.
        /// </summary>
        void Update(Persona persona);

        /// <summary>
        /// Elimina una persona por su identificador.
        /// </summary>
        void Delete(int id);
    }
}
