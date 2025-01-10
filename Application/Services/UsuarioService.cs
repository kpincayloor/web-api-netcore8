
using Application.Interfaces;
using Domain.Entities;
using Infra.Data.Repositories.Repositories;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepository.GetAll();
        }

        public Usuario GetById(int id)
        {
            var usuario = _usuarioRepository.GetById(id);
            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuario no encontrado.");
            }
            return usuario;
        }

        public Task<Usuario> GetByUser(string user, string pass)
        {
            var usuario = _usuarioRepository.GetByUser(user, pass);
            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuario no encontrado.");
            }
            return usuario;
        }

        public void Add(Usuario usuario)
        {
            _usuarioRepository.Add(usuario);
        }

        public void Update(Usuario usuario)
        {
            _usuarioRepository.Update(usuario);
        }

        public void Delete(int id)
        {
            _usuarioRepository.Delete(id);
        }
    }
}