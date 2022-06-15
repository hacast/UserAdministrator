using Microsoft.AspNetCore.Mvc;
using UserAdministrator.Services.BusinessValidator.Interface;
using UserAdministrator.Services.Commands;

namespace UserAdministrator.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService; 
        }

        [HttpGet()]
        public async Task<IActionResult> GetActivesAsync(int page = 1, int take = 100)
        {

            var personas = await _userService.GetActivesAsync(page, take);

            if (personas.HasItems)
            {
                return Ok(personas);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] CreateUserDTO request)
        {
            var response = await _userService.PostUser(request);

            if (response)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error al agregar el usuario.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutUser([FromBody] UpdateUserDTO request)
        {
            var response = await _userService.UpdateUser(request);

            if (response)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error al actualizar el usuario.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserDTO request)
        {
            var response = await _userService.DeleteUser(request);

            if (response)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error al eliminar el usuario.");
            }
        }
    }
}
