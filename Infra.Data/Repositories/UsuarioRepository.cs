using Domain.Entities;
using Infra.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public async Task<Usuario?> GetByUser(string user, string pass)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.User == user && u.Pass == pass);
        }

        public async Task<Usuario?> Add(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);

            if (await _context.SaveChangesAsync() > 0)
            {
                return usuario;
            }

            return null;
        }

        public void Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var usuario = GetById(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }
    }
}