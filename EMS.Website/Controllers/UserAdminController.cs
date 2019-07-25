using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using EMS.Website.Models;
using EMS.Website.Models.AccountViewModels;
using EMS.Website.Services;
using System.Net;
using EMS.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;

namespace EMS.Website.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("[controller]/[action]")]
    public class UserAdminController : Controller
    {
        public UserAdminController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)     {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        //
        // GET: /Users/
        public async Task<ActionResult> Index()
        {
            var userList = _userManager.Users.ToList();
            foreach (var user in userList)
            {
                var roles = await _userManager.GetRolesAsync(user);
                user.JobPost = string.Join(',', roles);
            }
            return View(_userManager.Users.ToList());
        }

        //
        // GET: /Users/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new StatusCodeResult(400);
            }
            var user = await _userManager.FindByIdAsync(id);

            ViewBag.RoleNames = await _userManager.GetRolesAsync(user);

            return View(user);
        }

        //
        // GET: /Users/Create
        public async Task<ActionResult> Create()
        {
            //Get the list of Roles
            //ViewBag.RoleId = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");
            ViewBag.RoleId = _roleManager.Roles.ToList();

            var teamleadList = await _userManager.GetUsersInRoleAsync("TeamLead");
            ViewBag.TeamLead = teamleadList.ToList().ConvertAll(p =>
            {
                return new SelectListItem()
                {
                    Text = p.FirstName + " " + p.LastName,
                    Value = p.Id
                };
            });

            return View();
        }

        //
        // POST: /Users/Create
        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel userViewModel, params string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var imagePath = await FileHelper.FileUploadDataAsync(userViewModel.DisplayPicture, "DisplayPicture");
                var user = new ApplicationUser
                                { UserName = userViewModel.Username,
                                  FirstName = userViewModel.FirstName,
                                  LastName = userViewModel.LastName,
                                  Email = userViewModel.Email,
                                  DisplayPicture =  imagePath
                                };
                                  user.EmailConfirmed = true;
                var adminresult = await _userManager.CreateAsync(user, userViewModel.Password);

                //Add User to the selected Roles 
                if (adminresult.Succeeded)
                {
                    if (selectedRoles != null)
                    {
                        var result = await _userManager.AddToRolesAsync(user, selectedRoles);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("",result.Errors.First().Code + ": " + result.Errors.First().Description);
                            ViewBag.RoleId = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
                            return View();
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", adminresult.Errors.First().Description);
                    ViewBag.RoleId = new SelectList(_roleManager.Roles, "Name", "Name");
                    return View();

                }
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(_roleManager.Roles, "Name", "Name");
            return View();
        }

        //
        // GET: /Users/Edit/1
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Convert.ToInt32(HttpStatusCode.BadRequest));
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var teamleadList = await _userManager.GetUsersInRoleAsync("TeamLead");
            ViewBag.TeamLead = teamleadList.ToList().ConvertAll(p =>
            {
                return new SelectListItem()
                {
                    Text = p.FirstName + " " + p.LastName,
                    Value = p.Id
                };
            });
            return View(new EditUserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                JobPost = user.JobPost,

                ImagePath = user.DisplayPicture,
                RolesList = _roleManager.Roles.ToList().Select(x => new SelectListItem()
                {
                    Selected = userRoles.Contains(x.Name),
                    Text = x.Name,
                    Value = x.Name
                })
            }); 
        }

        //
        // POST: /Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditUserViewModel editUser, params string[] selectedRole)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(editUser.Id);
                if (user == null)
                {
                    return NotFound();
                }

                user.UserName = editUser.Username;
                user.Email = editUser.Email;
                user.FirstName = editUser.FirstName;
                user.LastName = editUser.LastName;
                user.JobPost = editUser.JobPost;
             
                var imagePath = await FileHelper.FileUploadDataAsync(editUser.DisplayPicture, "DisplayPicture");
                user.DisplayPicture = imagePath;
                var userRoles = await _userManager.GetRolesAsync(user);

                selectedRole = selectedRole ?? new string[] { };

                var result = await _userManager.AddToRolesAsync(user, selectedRole.Except(userRoles).ToArray<string>());

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(result.Errors.First().Code, result.Errors.First().Description);
                    return View();
                }
                result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRole).ToArray<string>());

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(result.Errors.First().Code, result.Errors.First().Description);
                    return View();
                }
                return RedirectToAction("Index");
            }

            var teamleadList = await _userManager.GetUsersInRoleAsync("TeamLead");
            ViewBag.TeamLead = teamleadList.ToList().ConvertAll(p =>
            {
                return new SelectListItem()
                {
                    Text = p.FirstName + " " + p.LastName,
                    Value = p.Id
                };
            });

            ModelState.AddModelError("", "Something failed.");
            return View();
        }

        //
        // GET: /Users/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                }

                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError(result.Errors.First().Code, result.Errors.First().Description);
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
