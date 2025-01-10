
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUsuarioService
    {
        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        IEnumerable<Usuario> GetAll();

        /// <summary>
        /// Obtiene un usuario por su identificador.
        /// </summary>
        Usuario GetById(int id);

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        void Add(Usuario usuario);

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        void Update(Usuario usuario);

        /// <summary>
        /// Elimina un usuario por su identificador.
        /// </summary>
        void Delete(int id);

        Task<Usuario> GetByUser(string user, string pass);
    }
}