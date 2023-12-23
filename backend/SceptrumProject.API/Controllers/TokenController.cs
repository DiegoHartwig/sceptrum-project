// Projeto: Sceptrum Project
// Autor: Diego Hartwig
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SceptrumProject.API.DTO;
using SceptrumProject.Domain.SecurityAccount;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SceptrumProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _auth;
        private readonly IConfiguration _configuration;

        public TokenController(IAuthenticate auth, IConfiguration configuration)
        {
            _auth = auth ?? throw new ArgumentNullException(nameof(auth));
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginDTO loginDto)
        {
            var result =  await _auth.Authenticate(loginDto.Email, loginDto.Password);

            if (result)
            {
                return GenerateToken(loginDto);
            } 
            else
            {
                ModelState.AddModelError(string.Empty, "Dados de login inválidos.");
                return BadRequest(ModelState);
            }
        }

        [Authorize]
        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] LoginDTO loginDto)
        {
            var result = await _auth.RegisterUser(loginDto.Email, loginDto.Password);

            if (result)
            {
                return Ok($"Usuário: {loginDto.Email} criado com sucesso.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Dados de registro inválidos.");
                return BadRequest(ModelState);
            }
        }

        private UserToken GenerateToken(LoginDTO loginDto)
        {
            // Declarações do usuário
            var claims = new[]
            {
                new Claim("email", loginDto.Email),
                new Claim("minhaclaim", "valordaclaim"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Gerando chave privada para assinar o token
            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            // Gerar assinatura digital do token
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            // Definindo tempo de expiração do token
            var expiration = DateTime.UtcNow.AddMinutes(5);

            // Gerando o token
            JwtSecurityToken tokenJwt = new JwtSecurityToken(
                // Emissor
                issuer: _configuration["Jwt:Issuer"],
                // Audiencia
                audience: _configuration["Jwt:Audience"],
                // Claims
                claims: claims,
                // Tempo de expiração
                expires: expiration,
                // Assinatura Digital
                signingCredentials: credentials
                );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(tokenJwt),
                Expiration = expiration
            };
        }
    }
}
