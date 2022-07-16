using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ME_Mall.Data;
using ME_Mall.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Ataa.Areas.Identity.Pages.Account.Manage
{
    public class ResetAuthenticatorModel : PageModel
    {
        UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        ILogger<ResetAuthenticatorModel> _logger;
        private readonly ApplicationDbContext _context;


        public ResetAuthenticatorModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<ResetAuthenticatorModel> logger,
             ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            string fullName = user.FirstName + " " + user.LastName;
            ViewData["FullName"] = fullName;
            ViewData["profileImage"] = user.ProfilePath;
            if (this.User.IsInRole("Owner"))
            {
                var stores = from s in _context.Stores
                             select s;
                var sName = stores.First(x => x.OwnerId == user.Id).StoreName;
                ViewData["sName"] = sName;
            }
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            ViewData["fullName"] = user.FirstName + " " + user.LastName;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await _userManager.SetTwoFactorEnabledAsync(user, false);
            await _userManager.ResetAuthenticatorKeyAsync(user);
            _logger.LogInformation("User with ID '{UserId}' has reset their authentication app key.", user.Id);
            
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your authenticator app key has been reset, you will need to configure your authenticator app using the new key.";

            return RedirectToPage("./EnableAuthenticator");
        }
    }
}