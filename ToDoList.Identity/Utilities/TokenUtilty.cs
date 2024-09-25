using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using ToDiList.Domain.Model.Security;

namespace ToDoList.Identity.Utilities
{
    public class TokenUtilty
    {
        public string CreateToken(/*ApplicationUserDto user*/)
        {
            //List<Claim> claims = new()
            //{
            // new Claim(ClaimTypes.Name, user.UserName),
            // new Claim(ClaimTypes.Role, "Admin")
            //};

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSetting:Token").Value!));

            //var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //var token = new JwtSecurityToken(
            //    _tokenSetting.Issuer,
            //    _tokenSetting.Audience,
            //    claims: claims,
            //    expires: DateTime.Now.AddDays(1),
            //    signingCredentials: cred
            // );

            //var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            //return jwt;

            return "";
        }
    }
}
