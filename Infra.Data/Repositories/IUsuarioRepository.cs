

using Domain.Entities;

namespace Infra.Data.Repositories.Repositories
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
        Task<Usuario> GetByUser(string user, string pass);
        Task<Usuario> Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
    }
}