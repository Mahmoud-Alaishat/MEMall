using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ME_Mall.Data;
using ME_Mall.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ataa.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly ApplicationDbContext _context;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IWebHostEnvironment webHostEnvironment,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _WebHostEnvironment = webHostEnvironment;
            _context = context;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            [DataType(DataType.Upload)]
            [NotMapped]
            public IFormFile ImageFile { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
             ViewData["userId"]= await _userManager.GetUserIdAsync(user);
            Username = userName;
           
                Input = new InputModel
            {
                PhoneNumber = phoneNumber,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            string fullName = user.FirstName + " " + user.LastName;
            ViewData["FullName"] = fullName;
            ViewData["profileImage"] = user.ProfilePath;
            if (this.User.IsInRole("Owner")){
                var stores = from s in _context.Stores
                             select s;
                var sName = stores.First(x => x.OwnerId == user.Id).StoreName;
                ViewData["sName"] = sName;
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            string PATH = "";

            if (Input.ImageFile != null)
            {
                string wwwrootPath = _WebHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "_" + Input.ImageFile.FileName;
                string path = Path.Combine(wwwrootPath + "/Images/" + fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await Input.ImageFile.CopyToAsync(fileStream);
                }

                PATH = fileName;
                user.ProfilePath = PATH;
            }
            

                //user.PhoneNumber = Input.PhoneNumber;

                _context.Update(user);
            await _context.SaveChangesAsync();
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";

           
            return RedirectToPage();
        }
    }
}
