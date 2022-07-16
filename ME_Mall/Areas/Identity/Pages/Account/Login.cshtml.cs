using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ME_Mall.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ME_Mall.Models;
using Microsoft.AspNetCore.Http;

namespace Ataa.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly ApplicationDbContext _context;

        public LoginModel(SignInManager<User> signInManager, 
            ILogger<LoginModel> logger,
            UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
       

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var user = await _userManager.FindByEmailAsync(Input.Email);
                var result = await _signInManager.PasswordSignInAsync(user, Input.Password, Input.RememberMe, lockoutOnFailure: false);


                if (result.Succeeded)
                {
                  string fullName = user.FirstName + " " +user.LastName;
                    ViewData["FullName"] = fullName;
                    ViewData["profileImage"] = user.ProfilePath;
                   

                    if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
                    {
                        _logger.LogInformation("User logged in.");
                        ViewData["userID"] = _userManager.GetUserId(User);

                        //return LocalRedirect(returnUrl);
                        string userId = _context.User.Where(c => c.Email.Equals(Input.Email)).Select(e => e.Id).FirstOrDefault();
                        string userRole = _context.UserRoles.Where(x => x.UserId.Equals(userId)).Select(f => f.RoleId).FirstOrDefault();
                        string roleName = _context.Roles.Where(e => e.Id.Equals(userRole)).Select(u => u.Name).FirstOrDefault();
                        if (roleName.Equals("Admin"))
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else if (roleName.Equals("Owner"))
                        {
                                var stores = from s in _context.Stores
                                             select s;
                                var sName = stores.First(x => x.OwnerId == user.Id).StoreName;
                                HttpContext.Session.SetString("SName" ,sName);
                            
                            return RedirectToAction("Index", "Owner");
                        }
                        else if (roleName.Equals("Content Writer"))
                        {
                            return RedirectToAction("Index", "Media");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        return LocalRedirect(returnUrl);
                    }
                   
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Wrong Username or Password");
                    return Page();
                }
            }
            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
