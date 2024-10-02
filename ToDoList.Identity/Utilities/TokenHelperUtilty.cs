using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDiList.Domain.Model.Security;
using ToDoList.Application.Contract.Utilities.IdentityLayer;
using ToDoList.Application.Settings;

namespace ToDoList.Identity.Utilities
{
    public class TokenHelperUtilty : ITokenHelperUtility
    {
        private readonly IdentitySetting _identitySetting;
        public TokenHelperUtilty(IOptions<IdentitySetting> identitySetting)
        {
            _identitySetting = identitySetting.Value;
        }

        public string CreateToken(ApplicationUser user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_identitySetting.SigningKey));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                _identitySetting.Issuer,
                _identitySetting.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_identitySetting.ExpiresTime),
                signingCredentials: cred
             );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
