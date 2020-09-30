using Domain.Entities.Users;

using Infrastructure.Persistence;

using MediatR;

using Microsoft.IdentityModel.Tokens;

using Repo;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

using UserHandler.Querys;
using UserHandler.Responses;

namespace UserHandler.Handlers
{
    public class LoginHandler : IRequestHandler<LoginQuery, LoginResult>
    {
        IRepository<User, string> _user;
        public LoginHandler(IRepository<User, string> user)
        {
            _user = user;
        }
        public async Task<LoginResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = _user.Find(m => m.UserName == request.UserName).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            if (user.Password != request.Password)
            {
                return null;
            }
            return CreateJwt(user);
        }
        public LoginResult CreateJwt(User user)
        {
            var identity = GetIdentity(user);
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                   issuer: AuthOptions.ISSUER,
                   audience: AuthOptions.AUDIENCE,
                   notBefore: now,
                   claims: identity.Claims,
                   expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                   signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            LoginResult result = new LoginResult()
            {
                Token = encodedJwt,
                RefreshToken = RefreshToken(user),
                UserName = user.UserName
            };
            return result;
        }
        public string RefreshToken(User user)
        {
            Random random = new Random();
            user.RefreshToken = random.Next(int.MaxValue).ToString();
            _user.Update(user);
            return user.RefreshToken;
        }
        private ClaimsIdentity GetIdentity(User user)
        {

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),

                };
                foreach (var i in user.UserProjects)
                {
                    claims.Add(new Claim("project", i.ProjectId));

                }
                foreach (var i in user.UserServers)
                {
                    claims.Add(new Claim("server", i.ServerId));
                }
                ClaimsIdentity claimsIdentity =

                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
