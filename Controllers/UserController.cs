using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI2.Models;
using UserManagementAPI2.Repositories;

namespace UserManagementAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

    //Register Email
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        if (_userRepository.GetUserByEmailAsync(user.Email) != null)
        {
            return BadRequest("Email already exists");
        }

        user.CreatedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;

        await _userRepository.CreateUserAsync(user);
        return Ok(user);
    }

     [HttpGet("{id}")]
     public async Task<IActionResult> GetUserById(int id)
     {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
     }

     [HttpPut("{id}")]
     public async Task<IActionResult>UpdateUser(int id, [FromBody] User user)
     {
        var existingUser = await _userRepository.GetUserByIdAsync(id);
        if (existingUser == null)
        {
            return NotFound();
        }

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.UpdatedAt = DateTime.UtcNow;

        await _userRepository.UpdateUserAsync(existingUser);
        return Ok(existingUser);

     }

     [HttpDelete("{id}")]
     public async Task<IActionResult> DeleteUser(int id)
     {
        await _userRepository.DeleteUserAsync(id);
        return Ok();
     }

    }
}