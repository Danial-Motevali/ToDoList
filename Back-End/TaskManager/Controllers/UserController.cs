using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using TaskManager.Application.Dto;
using TaskManager.Domain.Contract.Services;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController
            (
                IUserService userService
            )
        {
            _userService = userService;
        }



        [HttpPost]
        [Route("Register")]
        public IActionResult Register(UserSignUpDto signUpInput)
        {
            ResultDto result = new();

            (bool, string) IsSuccess = _userService.CreateNewUser(signUpInput.UserName, signUpInput.Password);

            if (IsSuccess.Item1)
            {
                result.IsSuccess = true;
                result.ErrorMessage = null;
                result.Data = null;
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorMessage = "Cant sign a new user";
                result.Data = IsSuccess.Item2;
            }

            return Ok(result);
        }



        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserSignInDto signInInput)
        {
            string token = _userService.SignInAUser(signInInput.UserName, signInInput.Password);
            if(token == null)
            {
               return Ok(new ResultDto()
               {
                   IsSuccess = false,
                   Data = null,
                   ErrorMessage = "Cant SignIn the User"
               });
            }

            return Ok(new ResultDto()
            {
                IsSuccess = true,
                Data = token,
                ErrorMessage = "SignIn Successfuly"
            });
        }
    }
}
