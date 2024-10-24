﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManager.Domain.Contract.Repository;
using TaskManager.Domain.Contract.Services;
using TaskManager.Domain.SystemEntity;
using TaskManager.Application.Utilities;

namespace TaskManager.Application.Services
{
    public class UserServices : IUserService
    {
        private readonly IGenericRepository<ApplicationUser> _userRepo;
        private readonly IConfiguration _configuration;

        public UserServices
            (
                IGenericRepository<ApplicationUser> userRepo,
                IConfiguration configuration
            )
        {
            _userRepo = userRepo;
            _configuration = configuration;
        }

        public (bool, string) CreateNewUser(string userName, string password)
        {
            ApplicationUser user = new()
            {
                UserName = userName,
                PasswordHash = PasswordHasherHelper.CreateHash(password)
            };
            if (user.PasswordHash == null)
                return (false, "Cant SignUp a new User");


            (bool, ApplicationUser) result = _userRepo.Insert(user);
            if (result.Item1)
            {
                return (true, null);
            }
            else
            {
                return (false, "Cant SignUp a new User");
            }
        }

        public string SignInAUser(string userName, string password)
        {
            var result = _userRepo.GetAll().Where(x => x.UserName == userName).FirstOrDefault();

            if (result == null)
                return null;

            bool validede = PasswordHasherHelper.ValidHash(password, result.PasswordHash);
            if (!validede)
                return null;

            return CreateAToken(userName, result.Id.ToString());
        }

        private string CreateAToken(string userName, string userId)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, userId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSetting:Token").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
             claims: claims,
             expires: DateTime.Now.AddDays(1),
             signingCredentials: cred
             );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
