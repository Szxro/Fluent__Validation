using Microsoft.AspNetCore.Mvc;
using Models;
using Validations.Services;
using FluentValidation;
using Validatiors;

namespace Validations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _services;
        public UserController(IUserServices services)
        {
            _services = services;
        }

        [HttpPost]

        public async Task<ActionResult<ServiceResponse<List<User>>>> sendUser(User request)
        {
            return Ok(await _services.postAUser(request));
        }
    }
}
