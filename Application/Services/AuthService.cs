using Application.Helper;
using Application.Interfaces;
using Domain.Entities;
using Infra.Data.Repositories.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly JWT _jwt;
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthService(IOptions<JWT> jwt, IUsuarioRepository usuarioRepository)
        {
            _jwt = jwt.Value;
            _usuarioRepository = usuarioRepository;
        }
        //Login 
        public async Task<Auth> GetTokenAsync(AuthRequest model)
        {
            var authModel = new Auth();

            var user = await _usuarioRepository.GetByUser(model.User, model.Pass);

            if (user is null)
            {
                authModel.Message = "Usuario o clave incorrecta.";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Username = user.User;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;

            return authModel;
        }
        private async Task<JwtSecurityToken> CreateJwtToken(Usuario user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.User),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
