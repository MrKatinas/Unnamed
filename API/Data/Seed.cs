using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace API.Data
{
    public class Seed
    {
        public static void SeedUsers(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (userManager.Users.Any()) 
                return;
            
            AddRoles(roleManager);
            
            AddAdminUser(userManager);
            AddUsers(userManager);
        }

        public static void AddRoles(RoleManager<Role> roleManager)
        {
            var roles = new List<Role>
            {
                new Role { Name = "User" },
                new Role { Name = "Admin" }
            };

            foreach (var role in roles)
            {
                roleManager.CreateAsync(role).Wait();
            }
        }

        public static void AddAdminUser(UserManager<User> userManager)
        {
            var adminUser = new User
            {
                UserName = "Admin"
            };

            var results = userManager.CreateAsync(adminUser, "pass").Result;

            if (results.Succeeded)
            {
                var admin = userManager.FindByNameAsync("Admin").Result;
                userManager.AddToRoleAsync(admin, "Admin");
            }
        }

        
        public static void AddUsers(UserManager<User> userManager)
        {
            var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
                
            foreach (var user in users)
            {
                userManager.CreateAsync(user, "pass").Wait();
                userManager.AddToRoleAsync(user, "User");
            }
        }
    }
}