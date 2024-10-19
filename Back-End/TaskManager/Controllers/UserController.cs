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
        [Route("SignUp")]
        public IActionResult SignUp(UserSignUpDto signUpInput)
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
    }
}
