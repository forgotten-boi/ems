using Microsoft.AspNetCore.Http;
using EMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Services.Repositories
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _context;
        public UserService(IHttpContextAccessor context)
        {
            this._context = context;
        }

        public string GetLoggedInUser()
        {
            var claimsIdentity = _context.HttpContext.User;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            return claim.Value.ToString();
       

        }

    }
}
