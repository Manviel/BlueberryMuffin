using BlueberryMuffin.Contracts;
using BlueberryMuffin.Data.Relation;
using BlueberryMuffin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlueberryMuffin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly UserManager<ApiUser> _userManager;

        public UsersController(IUsersRepository usersRepository, UserManager<ApiUser> userManager)
        {
            _usersRepository = usersRepository;
            _userManager = userManager;
        }

        // GET: api/Users
        /// <summary>Show list of users.</summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApiUser>>> GetAllUsers()
        {
            return await _usersRepository.GetAllAsync();
        }

        // GET api/Users/5
        /// <summary>Get user by id.</summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiUser>> GetUser(string id)
        {
            var user = await _usersRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        /// <summary>Changes the role of a specified user.</summary>
        /// <response code="400">Invalid role specified</response>
        /// <response code="404">User not found</response>
        /// <response code="200">Role updated successfully</response>
        [HttpPost]
        [Route("changeRole")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult> ChangeUserRole(string id, string newRole)
        {
            if (!new[] { RoleTypes.User, RoleTypes.Admin, RoleTypes.Manager }.Contains(newRole))
            {
                return BadRequest("Invalid role specified");
            }

            var user = await _usersRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var currentRoles = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            await _userManager.AddToRoleAsync(user, newRole);
            
            return Ok("Role updated successfully");
        }
    }
}
