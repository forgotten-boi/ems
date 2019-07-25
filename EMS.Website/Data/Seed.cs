using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EMS.Website.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EMS.DataAccess;
using EMS.Entity.Entities;
using System.Linq;

namespace EMS.Website
{
    public static class Seed
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            //adding customs roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "Employee", "TeamLead", "Finance" };

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                //creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //creating a super user who could maintain the web app
            var poweruser = new ApplicationUser
            {
                UserName = Configuration.GetSection("AppSettings")["UserEmail"],
                Email = Configuration.GetSection("AppSettings")["UserEmail"]
            };

            string userPassword = Configuration.GetSection("AppSettings")["UserPassword"];
            var user = await UserManager.FindByEmailAsync(Configuration.GetSection("AppSettings")["UserEmail"]);

            if(user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the "Admin" role 
                    await UserManager.AddToRoleAsync(poweruser, "Admin");

                }
            }
        }

        public static async Task CreateMstExpenses(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            
            var _contextManager = serviceProvider.GetRequiredService<ProjectDbContext>();
           
            if (_contextManager.MstExpenses == null || _contextManager.MstExpenses.ToList().Count == 0)
            {
                List<MstExpenses> expenses = Configuration.GetSection("MstExpense").Get<List<MstExpenses>>();
                await _contextManager.MstExpenses.AddRangeAsync(expenses);
                await _contextManager.SaveChangesAsync();
            }

        }
    }
}