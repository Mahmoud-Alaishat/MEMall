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
    public class OrderDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public OrderDetailsModel(ApplicationDbContext context,
                          UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        public List<ME_Mall.Models.JoinTable2> Order { get; set; }

        public async Task OnGetAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            string fullName = user.FirstName + " " + user.LastName;
            ViewData["FullName"] = fullName;
            ViewData["profileImage"] = user.ProfilePath;
            Order = (from o in _context.Orders
                     join op in _context.OrderProduct on o.Id equals op.OrderId
                     join p in _context.Products on op.ProductId equals p.Id
                     join s in _context.Status on o.OrderStatus equals s.Id
                     join u in _context.Units on p.UnitId equals u.Id
                     where o.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value && o.Id ==id
                     select new JoinTable2 { order = o, Status = s,orderProduct=op,product=p,Unit=u }).ToList();
        }
    }
}
