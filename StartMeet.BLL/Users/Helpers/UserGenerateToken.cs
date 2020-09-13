using Microsoft.AspNetCore.Builder.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StartMeet.BLL.Configure;
using StartMeet.BLL.Users.Queries;
using StartMeet.DAL;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StartMeet.BLL.Users.Helpers
{
    public class UserGenerateToken : IUserGenerateToken
    {
        private readonly IGetUserIdByUserEmailQuery _getUserIdByUserEmailQuery;
        private readonly ApplicationSettings _applicationSettings;

        public UserGenerateToken(IGetUserIdByUserEmailQuery getUserIdByUserEmailQuery, 
            IOptions<ApplicationSettings> applicationSettings)
        {
            _getUserIdByUserEmailQuery = getUserIdByUserEmailQuery;
            _applicationSettings = applicationSettings.Value;
        }
        public UserToken Generate(string userEmail)
        {
            var userId = _getUserIdByUserEmailQuery;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", userId.ToString())
                    }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_applicationSettings.JWT_Secret)),
                        SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return new UserToken()
            {
                Token =token,
                UserId = userId.ToString()
            };
        }
    }
}
