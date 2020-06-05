using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize(Policy = "RequireAdminRole")]
    [ApiController] 
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public AdminController(DataContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        
        /// <summary>
        /// Gets list of users with their roles.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUsersWithRoles()
        {
            var userList = await _context.Users
                .OrderBy(u => u.UserName)
                .Select(user => new
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Roles = (from userRole in user.UserRoles
                        join role in _context.Roles
                            on userRole.RoleId
                            equals role.Id
                        select role.Name).ToList()
                }).ToListAsync();
            
            return Ok(userList);
        }

        /// <summary>
        /// Updates single user roles.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleEditDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditUserRoles(string id, RoleEditDto roleEditDto)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound("User with that id doesn't exist");

            var userRoles = await _userManager.GetRolesAsync(user);

            var selectedRoles = roleEditDto?.RoleNames;
            
            // Checking if one of the roles is invalid
            if (!IsRolesValid(selectedRoles))
                return BadRequest("Incorrect roles");
            
            // Add only the new roles
            var results = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

            if (!results.Succeeded)
                return BadRequest("Failed To add to roles");
            
            // Removes all old roles, that was not selected.
            results = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));
            
            if (!results.Succeeded)
                return BadRequest("Failed To remove to roles");

            
            return Ok(await _userManager.GetRolesAsync(user));
        }

        /// <summary>
        /// Checks if all roles are Exist
        /// </summary>
        /// <param name="roles"></param>
        /// <returns>Returns false if one the roles doesn't exist</returns>
        private bool IsRolesValid(List<string> roles)
        {
            if (roles == null)
                return false;
            
            // Gets all available roles.
            var validRoles = _roleManager.Roles.Select(role => role.Name);

            // checks if all roles exist 
            return roles.All(role => validRoles.Contains(role));
        }
    }
}