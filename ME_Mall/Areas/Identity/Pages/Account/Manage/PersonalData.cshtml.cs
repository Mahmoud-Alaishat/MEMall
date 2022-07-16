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
    public class PersonalDataModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<PersonalDataModel> _logger;
        private readonly ApplicationDbContext _context;


        public PersonalDataModel(
            UserManager<User> userManager,
            ILogger<PersonalDataModel> logger,
             ApplicationDbContext context)
        {
            _userManager = userManager;
            _logger = logger;
            _context = context;            
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            string fullName = user.FirstName + " " + user.LastName;
            ViewData["FullName"] = fullName;
            ViewData["profileImage"] = user.ProfilePath;
            if (this.User.IsInRole("Owner"))
            {
                ViewData["sName"] = HttpContext.Session.GetString("SName");
            }
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            ViewData["fullName"] = user.FirstName + " " + user.LastName;

            return Page();
        }
    }
}