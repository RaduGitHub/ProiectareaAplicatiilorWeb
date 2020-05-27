using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameForum.ApplicationLogic.Abstractions;
using GameForum.DataAccess;
using GameForum.EFDataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameForum.Controllers
{
    public class AdminController : Controller
    {
        private IGame gameRepository;
        //private readonly GameForumDbContext dbContext;
        private IUser userRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(IGame gameRepository, ApplicationLogic.Abstractions.IUser userRepository, UserManager<IdentityUser> userManager)
        {
            this.gameRepository = gameRepository;
            this.userRepository = userRepository;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser()
        {

            var users = userRepository.GetAll();

            ViewData.Model = users;

            return View(users);
        }

        public async Task<IActionResult> Delete(string ID)
        {
            var user = userRepository.GetUserByUserId(Guid.Parse(ID));
            userRepository.Delete(user);
            var userIdentity = await _userManager.FindByIdAsync(ID);
            var rolesForUser = await _userManager.GetRolesAsync(userIdentity);
            
            if (rolesForUser.Count() > 0)
            {
                foreach (var item in rolesForUser.ToList())
                {
                    var result = await _userManager.RemoveFromRoleAsync(userIdentity, "User");
                }
            }

            await _userManager.DeleteAsync(userIdentity);

            return RedirectToAction("DeleteUser", "Admin");
        }

        public async Task<IActionResult> AddToAdmin(string ID)
        {
            var user = userRepository.GetUserByUserId(Guid.Parse(ID));
            //userRepository.Delete(user);
            user.IsAdmin = true;
            userRepository.Update(user);
            var userIdentity = await _userManager.FindByIdAsync(ID);
            var rolesForUser = await _userManager.GetRolesAsync(userIdentity);

            if (rolesForUser.Count() > 0)
            {
                foreach (var item in rolesForUser.ToList())
                {
                    var result = await _userManager.RemoveFromRoleAsync(userIdentity, "User");
                    var result2 = await _userManager.AddToRoleAsync(userIdentity, "Admin");
                }
            }

            return RedirectToAction("DeleteUser", "Admin");
        }

        public async Task<IActionResult> DowngradeUser(string ID)
        {
            var user = userRepository.GetUserByUserId(Guid.Parse(ID));
            //userRepository.Delete(user);
            user.IsAdmin = false;
            userRepository.Update(user);
            var userIdentity = await _userManager.FindByIdAsync(ID);
            var rolesForUser = await _userManager.GetRolesAsync(userIdentity);

            if (rolesForUser.Count() > 0)
            {
                foreach (var item in rolesForUser.ToList())
                {
                    var result = await _userManager.RemoveFromRoleAsync(userIdentity, "Admin");
                    var result2 = await _userManager.AddToRoleAsync(userIdentity, "User");
                }
            }

            return RedirectToAction("DeleteUser", "Admin");
        }
    }
    
}