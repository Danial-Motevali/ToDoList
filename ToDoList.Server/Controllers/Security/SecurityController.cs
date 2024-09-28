using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTO.EndPointsDto;
using ToDoList.EndPoint.Controllers.Base;

namespace ToDoList.EndPoint.Controllers.Security
{
    public class SecurityController : BaseController
    {

        [HttpPost]
        [Route("sign-up")]
        public IActionResult Register(RegisterInputDto input)
        {
            return Ok();
        }
    }
}
