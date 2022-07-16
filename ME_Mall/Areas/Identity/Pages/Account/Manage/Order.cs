using ME_Mall.Data;
using ME_Mall.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ataa.Areas.Identity.Pages.Account.Manage
{
    public class OrderModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public OrderModel(ApplicationDbContext context,
                          UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        public List<ME_Mall.Models.JoinTable2> Orders { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            string fullName = user.FirstName + " " + user.LastName;
            ViewData["FullName"] = fullName;
            ViewData["profileImage"] = user.ProfilePath;
            Orders = (from o in _context.Orders
                      join s in _context.Status on o.OrderStatus equals s.Id
                      where o.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value
                      select new JoinTable2 {order=o,Status=s }).OrderByDescending(x=>x.order.OrderDate).ToList();
        }
    }
}
