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
    public class GenerateRecoveryCodesModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<GenerateRecoveryCodesModel> _logger;
        private readonly ApplicationDbContext _context;

        public GenerateRecoveryCodesModel(
            UserManager<User> userManager,
            ILogger<GenerateRecoveryCodesModel> logger,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }

        [TempData]
        public string[] RecoveryCodes { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
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

            var isTwoFactorEnabled = await _userManager.GetTwoFactorEnabledAsync(user);
            if (!isTwoFactorEnabled)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                throw new InvalidOperationException($"Cannot generate recovery codes for user with ID '{userId}' because they do not have 2FA enabled.");
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

            var isTwoFactorEnabled = await _userManager.GetTwoFactorEnabledAsync(user);
            var userId = await _userManager.GetUserIdAsync(user);
            if (!isTwoFactorEnabled)
            {
                throw new InvalidOperationException($"Cannot generate recovery codes for user with ID '{userId}' as they do not have 2FA enabled.");
            }

            var recoveryCodes = await _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10);
            RecoveryCodes = recoveryCodes.ToArray();

            _logger.LogInformation("User with ID '{UserId}' has generated new 2FA recovery codes.", userId);
            StatusMessage = "You have generated new recovery codes.";
            return RedirectToPage("./ShowRecoveryCodes");
        }
    }
}