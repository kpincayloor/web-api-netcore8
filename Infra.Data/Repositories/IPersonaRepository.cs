


using Domain.Entities;

namespace Infra.Data.Repositories.Repositories
{
    public interface IPersonaRepository
    {
        IEnumerable<Persona> GetAll();
        Persona GetById(int id);
        void Add(Persona persona);
        void Update(Persona persona);
        void Delete(int id);
    }
}
