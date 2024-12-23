﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarshipServer.Data;
using StarshipServer.Data.Models;

namespace StarshipServer.Controllers // TODO namespace not in textbook?
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class SeedController(  // TODO this is dependency injection, but the book saves these as private readonly in a constructor.  Didn't have to do this in class tho.
        ApplicationDbContext db,
        RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager
        // TODO use IWebHostEnvironment env if needed
        // TODO use IConfiguration configuration if needed - this is needed to take default passwords from a secrets.json (which I'm not using yet)
        ) : ControllerBase
    {

        [HttpPost("Users")]
        public async Task<IActionResult> ImportUsersAsync()
        {
            (string name, string email) = ("Han Solo", "nerfherder@bespin.com");
            ApplicationUser user = new ApplicationUser()
            {
                UserName = name,
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            if (await userManager.FindByEmailAsync(email) is not null)
            {
                return Ok(user);
            }

            // If not found, this will create a user in the database.
            // More direct form of textbook stuff.  Clearly the problem is that the DB doesn't exist.
            IdentityResult result = await userManager.CreateAsync(user, "Artoo-D2");
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            await db.SaveChangesAsync();

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult> CreateDefaultUsers()
        {
            // setup the default role names
            string role_RegisteredUser = "RegisteredUser";
            string role_Administrator = "Administrator";

            // create the default roles (if they don't exist yet)
            if (await roleManager.FindByNameAsync(role_RegisteredUser) == null)
                await roleManager.CreateAsync(new
                 IdentityRole(role_RegisteredUser));
            if (await roleManager.FindByNameAsync(role_Administrator) == null)
                await roleManager.CreateAsync(new
                 IdentityRole(role_Administrator));

            // create a list to track the newly added users
            var addedUserList = new List<ApplicationUser>();
            // check if the admin user already exists
            var email_Admin = "yoda@jedi.com";
            if (await userManager.FindByNameAsync(email_Admin) == null)
            {
                // create a new admin ApplicationUser account
                var user_Admin = new ApplicationUser()
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = email_Admin,
                    Email = email_Admin,
                };

                // TODO insert the admin user into the DB
                await userManager.CreateAsync(user_Admin, "Artoo-D2");

                // assign the "RegisteredUser" and "Administrator" roles
                await userManager.AddToRoleAsync(user_Admin, role_RegisteredUser);
                await userManager.AddToRoleAsync(user_Admin, role_Administrator);

                // confirm the e-mail and remove lockout
                user_Admin.EmailConfirmed = true;
                user_Admin.LockoutEnabled = false;

                // add the admin user to the added users list
                addedUserList.Add(user_Admin);
            }
            // check if the standard user already exists
            var email_User = "luke@jedi.com";
            if (await userManager.FindByNameAsync(email_User) == null)
            {
                // create a new standard ApplicationUser account
                var user_User = new ApplicationUser()
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = email_User,
                    Email = email_User
                };

                // insert the standard user into the DB
                await userManager.CreateAsync(user_User, "Artoo-D2");

                // assign the "RegisteredUser" role
                await userManager.AddToRoleAsync(user_User, role_RegisteredUser);
                // confirm the e-mail and remove lockout
                user_User.EmailConfirmed = true;
                user_User.LockoutEnabled = false;

                // add the standard user to the added users list
                addedUserList.Add(user_User);
            }

            // if we added at least one user, persist the changes into the DB
            if (addedUserList.Count > 0)
                await db.SaveChangesAsync();

            return new JsonResult(new
            {
                Count = addedUserList.Count,
                Users = addedUserList
            });

        }
    }

}
