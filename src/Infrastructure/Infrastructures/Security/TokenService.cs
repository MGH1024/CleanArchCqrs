using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Contracts.Infrastructure.Identity;
using Application.Features.Authentications.Commands.RegisterUser;
using Application.Models.Identity;
using CustomAuth.Helpers;
using Domain.Entities.Security;
using Infrastructures.Extensions.IdentityHelpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructures.Identity;

public class TokenService : ITokenService
    {
        private DateTime _accessTokenExpiration;
        private readonly TokenOption _tokenOption;
        public TokenService(IConfiguration configuration)
        {
            _tokenOption = configuration.GetSection("TokenOption").Get<TokenOption>();
            
        }
        public AccessTokenDto CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.AccessTokenExpiration);
            var key = SecurityKeyHelper.CreateSecurityKey(_tokenOption.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(key);
            var jwt = CreateJwtSecurityToken(user, signingCredentials, operationClaims);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtTokenHandler.WriteToken(jwt);

            return new AccessTokenDto
            {
                Token = token,
                Expiration = _accessTokenExpiration,
            };
        }

        private JwtSecurityToken CreateJwtSecurityToken(User user,SigningCredentials signingCredentials,List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer : _tokenOption.Issuer,
                audience: _tokenOption.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims : SetClaim(user,operationClaims),
                signingCredentials:signingCredentials
                ) ;
            return jwt;
        }
        private static IEnumerable<Claim> SetClaim(User user,List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddEmail(user.Email);
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddName($"{user.FirstName}.{user.LastName}");
            claims.AddRoles(operationClaims.Select(c=>c.Name).ToArray());

            return claims;
        }
    }