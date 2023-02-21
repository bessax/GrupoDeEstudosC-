using ByteBank.API.Request.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ByteBank.API.Helpers
{
    public class GenerateToken
    {
        private readonly IConfiguration configuration;
        public GenerateToken(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        internal UserTokenDTO GenerateUserToken(UserDTO user)
        {
            //Configurações a serem usadas no Token a ser gerado.
            var myClaims = new[]
            {
               new Claim(JwtRegisteredClaimNames.UniqueName,user.Email),
               new Claim("alura","c#"),
               new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            //Gerar uma chave simétrica
            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["JWTKey:key"]));

            //Faz uma assinatura da chave
            var credenciais = new SigningCredentials(chave,SecurityAlgorithms.HmacSha256);

            //Expiration
            var expiracao = configuration["JWTTokenConfiguration:ExpireHours"];
            var expiracaoEmHoras = DateTime.UtcNow.AddHours(double.Parse(expiracao));

            //Gerando Token
            JwtSecurityToken? token = null;
            try
            {
                token = new JwtSecurityToken(
                claims: myClaims,
                expires: expiracaoEmHoras,
                issuer: configuration["JWTTokenConfiguration:Issuer"],
                audience: configuration["JWTTokenConfiguration:Audience"],
                signingCredentials: credenciais
                );
            }
            catch (Exception)
            {

                throw new ArgumentException("Problemas na criação do token JWT.");
            }
            
            return new UserTokenDTO()
            {
                Authenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiracaoEmHoras,
                Message = "Token JWT gerado com sucesso!"
            };
        }
    }
}
