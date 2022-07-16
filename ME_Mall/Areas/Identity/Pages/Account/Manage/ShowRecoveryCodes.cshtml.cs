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
    public class ShowRecoveryCodesModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public ShowRecoveryCodesModel(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
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

            if (RecoveryCodes == null || RecoveryCodes.Length == 0)
            {
                return RedirectToPage("./TwoFactorAuthentication");
            }
            ViewData["fullName"] = user.FirstName + " " + user.LastName;

            return Page();
        }
    }
}
