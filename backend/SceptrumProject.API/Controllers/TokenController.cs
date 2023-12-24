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
        [HttpPost("Login")]
        public async Task<ActionResult<TokenUsuario>> Login([FromBody] LoginDTO loginDto)
        {
            var resultado = await _auth.Authenticate(loginDto.Email, loginDto.Password);

            return resultado ?
                GerarTokenJwt(loginDto) :
                ExibirRespostaErro("Dados de login inválidos.", 401);
        }

        [Authorize]
        [HttpPost("Registrar")]
        public async Task<ActionResult> Registrar([FromBody] LoginDTO loginDto)
        {
            var resultado = await _auth.RegisterUser(loginDto.Email, loginDto.Password);

            return resultado ?
                Ok($"Usuário: {loginDto.Email} criado com sucesso.") :
                ExibirRespostaErro("Dados de registro inválidos.", 400);
        }

        [Authorize]
        [HttpGet("VerificarTokenValido")]
        public async Task<ActionResult> VerificarTokenValido()
        {
            string bearerToken = HttpContext.Request.Headers["Authorization"].ToString();

            if (String.IsNullOrEmpty(bearerToken))
                return BadRequest();

            var tokenValido = VerificarValidadeToken(bearerToken);

            return tokenValido ?
                Ok(tokenValido) :
                ExibirRespostaErro("Token inválido ou expirado", 401);
        }

        private bool VerificarValidadeToken(string bearerToken)
        {
            if (String.IsNullOrEmpty(bearerToken))
                return false;

            string tokenJwt = bearerToken.Replace("Bearer ", "");

            var secret = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]);
            var chaveSecreta = new SymmetricSecurityKey(secret);

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(tokenJwt, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey = chaveSecreta
                }, out SecurityToken tokenValido);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private TokenUsuario GerarTokenJwt(LoginDTO loginDto)
        {
            // Declarações do usuário
            var claims = new[]
            {
                new Claim("email", loginDto.Email),
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

            return new TokenUsuario()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(tokenJwt),
                Expiration = expiration
            };
        }

        private ObjectResult ExibirRespostaErro(string mensagem, int statusCode)
        {
            ModelState.AddModelError(string.Empty, mensagem);
            return new ObjectResult(ModelState) { StatusCode = statusCode };
        }
    }
}
