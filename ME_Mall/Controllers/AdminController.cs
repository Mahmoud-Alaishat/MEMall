using ME_Mall.Data;
using ME_Mall.Models;
using ME_Mall.Services.EmailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ME_Mall.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly IConfiguration _config;

        public AdminController(ApplicationDbContext context,RoleManager<IdentityRole> roleManager,
                               UserManager<User> userManager, IWebHostEnvironment webHostEnvironment,
                                IConfiguration config)
        {       
            _context = context;
            this.roleManager = roleManager;
            _userManager = userManager;
            _WebHostEnvironment = webHostEnvironment;
            _config = config;
        }
        public IActionResult Index()
        {
            List<OrderStatisticsData> result = new List<OrderStatisticsData>();
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            ViewBag.total = (from o in _context.OrderProduct
                             select o).Count();
            var oJoin = (from p in _context.Products
                         join op in _context.OrderProduct on p.Id equals op.ProductId
                         join or in _context.Orders on op.OrderId equals or.Id
                         join ps in _context.ProductStore
                         on p.Id equals ps.productId
                         join s in _context.Stores
                         on ps.storeId equals s.Id
                         join u in _context.Units
                         on p.UnitId equals u.Id
                         join c in _context.SubCategories
                         on p.CategoryId equals c.Id
                         select new JoinTable1 { store = s, order = or, orderProduct = op, product = p, productStore = ps, Unit = u, SubCategory = c }).ToList();

            oJoin.Select(c => c.SubCategory).Distinct().ToList().ForEach(s => {
                OrderStatisticsData ele =new OrderStatisticsData();
                ele.labels=s.SubCategoryName;
                ele.data= oJoin.Where(e => e.product.CategoryId == s.Id).Select(d => d.orderProduct.ProductId).Count();
                result.Add(ele);
            });
            ViewBag.owners = _userManager.GetUsersInRoleAsync("Owner").Result.Count();
            ViewBag.users = _userManager.GetUsersInRoleAsync("User").Result.Count();
            ViewBag.categories = (from c in _context.Categories
                                  select c).Count();
            ViewBag.subcategories = (from s in _context.SubCategories
                                  select s).Count();
            ViewBag.revenue = oJoin.Sum(x => x.orderProduct.Total);
            return View(result);
        }
        public class OrderStatisticsData
        {
            public string labels { get; set; }
            public decimal data { get; set; }
        }
        public IActionResult AccountSettings()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            return View();
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("CreateRole", "Admin");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        // GET: Categories
        public async Task<IActionResult> Categories()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            return View(await _context.Categories.OrderBy(x => x.Id).ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> CategoryDetails(int? id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult CreateCategory()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory([Bind("Id,CategoryName")] Category category)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Categories));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> EditCategory(int? id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(int id, [Bind("Id,CategoryName")] Category category)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Categories));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedCat(int id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Categories));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

        // GET: SubCategories
        public async Task<IActionResult> SubCategories()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            return View(await _context.SubCategories.OrderBy(x=>x.Id).ToListAsync());
        }

        // GET: SubCategories/Details/5
        public async Task<IActionResult> SubCategoryDetails(int? id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _context.SubCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }

        // GET: SubCategories/Create
        public IActionResult CreateSubCategory()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            List<Category> cat = new List<Category>();
            cat = (from c in _context.Categories select c).ToList();
            cat.Insert(0, new Category { Id = 0, CategoryName = "--Select Category Name--" });
            ViewBag.message = cat;
            return View();
        }

        // POST: SubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubCategory([Bind("Id,SubCategoryName,CategoryId")] SubCategory subCategory)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (ModelState.IsValid)
            {
                _context.Add(subCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SubCategories));
            }
            return View(subCategory);
        }

        // GET: SubCategories/Edit/5
        public async Task<IActionResult> EditSubCategory(int? id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory == null)
            {
                return NotFound();
            }
            List<Category> cat = new List<Category>();
            cat = (from c in _context.Categories select c).ToList();
            cat.Insert(0, new Category { Id = 0, CategoryName = "--Select Category Name--" });
            ViewBag.message = cat;
            return View(subCategory);
        }

        // POST: SubCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSubCategory(int id, [Bind("Id,SubCategoryName,CategoryId")] SubCategory subCategory)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (id != subCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubCategoryExists(subCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(SubCategories));
            }
            return View(subCategory);
        }

        // GET: SubCategories/Delete/5
        public async Task<IActionResult> DeleteSubCategory(int? id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _context.SubCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }

        // POST: SubCategories/Delete/5
        [HttpPost, ActionName("DeleteSubCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedSubCat(int id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            var subCategory = await _context.SubCategories.FindAsync(id);
            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(SubCategories));
        }

        private bool SubCategoryExists(int id)
        {
            return _context.SubCategories.Any(e => e.Id == id);
        }
        // GET: Stores
        public async Task<IActionResult> Stores()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            var Stores = (from u in _context.User
                            join s in _context.Stores
                            on u.Id equals s.OwnerId
                            join c in _context.Categories
                            on s.CategoryId equals c.Id
                            select new StoreOwner { User=u,Store=s,Category=c}).ToList();
            return View(Stores);
        }

        // GET: Stores/Details/5
        public async Task<IActionResult> StoreDetails(int? id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Stores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // GET: Stores/Create
        public IActionResult CreateStore()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            List<Category> cat = new List<Category>();
            cat = (from c in _context.Categories select c).ToList();
            cat.Insert(0, new Category { Id = 0, CategoryName = "--Select Category Name--" });
            ViewBag.message = cat;
            List<User> owners = new List<User>();
            var ownerRole = _userManager.GetUsersInRoleAsync("Owner").Result;
            var ids = (from i in _context.Stores
                      select i.OwnerId).ToList();
            owners = ownerRole.OfType<User>().Where(x=>!ids.Contains(x.Id)).ToList();
            
            owners.Insert(0, new User { Id = "0", FirstName = "--Select Owner Name--" });
            ViewBag.message1 = owners;
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStore([Bind("Id,StoreName,OwnerId,CategoryId,CoverImage,ImageFile3,StoreStatement")] Store store)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (ModelState.IsValid)
            {
                if (store.ImageFile3 != null)
                {
                    string wwwrootPath = _WebHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + store.ImageFile3.FileName;
                    string path = Path.Combine(wwwrootPath + "/Images/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await store.ImageFile3.CopyToAsync(fileStream);
                    }

                    store.CoverImage = fileName;
                }
                _context.Add(store);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Stores));
            }
            return View(store);
        }

        // GET: Stores/Edit/5
        public async Task<IActionResult> EditStore(int? id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Stores.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }
            List<Category> cat = new List<Category>();
            cat = (from c in _context.Categories select c).ToList();
            cat.Insert(0, new Category { Id = 0, CategoryName = "--Select Category Name--" });
            ViewBag.message = cat;
            List<User> owners = new List<User>();
            var ownerRole = _userManager.GetUsersInRoleAsync("Owner").Result;
            var ids = (from i in _context.Stores
                       select i.OwnerId).ToList();
            owners = ownerRole.OfType<User>().ToList();

            owners.Insert(0, new User { Id = "0", FirstName = "--Select Owner Name--" });
            ViewBag.message1 = owners;
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStore(int id, [Bind("Id,StoreName,OwnerId,CategoryId,CoverImage,ImageFile3,StoreStatement")] Store store)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (id != store.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (store.ImageFile3 != null)
                    {
                        string wwwrootPath = _WebHostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + store.ImageFile3.FileName;
                        string path = Path.Combine(wwwrootPath + "/Images/" + fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await store.ImageFile3.CopyToAsync(fileStream);
                        }

                        store.CoverImage = fileName;
                    }
                    _context.Update(store);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreExists(store.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Stores));
            }
            return View(store);
        }

        // GET: Stores/Delete/5
        public async Task<IActionResult> DeleteStore(int? id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Stores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("DeleteStore")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedStore(int id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            var store = await _context.Stores.FindAsync(id);
            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Stores));
        }

        private bool StoreExists(int id)
        {
            return _context.Stores.Any(e => e.Id == id);
        }
        public IActionResult Users()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            List<User> users = new List<User>();
            var userRole = _userManager.GetUsersInRoleAsync("User").Result;
            users = userRole.OfType<User>().ToList();
            
            return View(users);
        }

        public IActionResult CreateUser()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(string email,string username,string firstname,string lastname,string phonenumber, IFormFile ImageFile, string password)
        {
            var USER = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = USER.Select(x => x.FirstName).First() + " " + USER.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = USER.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            string PATH = "";
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    string wwwrootPath = _WebHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                    string path = Path.Combine(wwwrootPath + "/Images/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(fileStream);
                    }

                    PATH = fileName;
                }
                var user = new User { Email = email, UserName = username, FirstName = firstname, LastName = lastname, PhoneNumber = phonenumber, ProfilePath = PATH,EmailConfirmed=true,PhoneNumberConfirmed=true};
                var result = await _userManager.CreateAsync(user, password);
                await _userManager.AddToRoleAsync(user, "User");
               
                return RedirectToAction(nameof(Users));

            }
            return View();
        }
        public IActionResult Owners()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            List<User> users = new List<User>();
            var userRole = _userManager.GetUsersInRoleAsync("Owner").Result;
            users = userRole.OfType<User>().ToList();

            return View(users);
        }

        public IActionResult CreateOwner()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOwner(string email, string username, string firstname, string lastname, string phonenumber, IFormFile ImageFile, string password)
        {
            var USER = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = USER.Select(x => x.FirstName).First() + " " + USER.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = USER.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            string PATH = "";
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    string wwwrootPath = _WebHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                    string path = Path.Combine(wwwrootPath + "/Images/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(fileStream);
                    }

                    PATH = fileName;
                }
                var user = new User { Email = email, UserName = username, FirstName = firstname, LastName = lastname, PhoneNumber = phonenumber, ProfilePath = PATH, EmailConfirmed = true, PhoneNumberConfirmed = true };
                var result = await _userManager.CreateAsync(user, password);
                await _userManager.AddToRoleAsync(user, "Owner");

                return RedirectToAction(nameof(Owners));

            }
            return View();
        }

        public IActionResult ContentWriters()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            List<User> users = new List<User>();
            var userRole = _userManager.GetUsersInRoleAsync("Content Writer").Result;
            users = userRole.OfType<User>().ToList();

            return View(users);
        }

        public IActionResult AddContentWriter()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddContentWriter(string email, string username, string firstname, string lastname, string phonenumber, IFormFile ImageFile, string password)
        {
            var USER = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = USER.Select(x => x.FirstName).First() + " " + USER.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = USER.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            string PATH = "";
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    string wwwrootPath = _WebHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                    string path = Path.Combine(wwwrootPath + "/Images/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(fileStream);
                    }

                    PATH = fileName;
                }
                var user = new User { Email = email, UserName = username, FirstName = firstname, LastName = lastname, PhoneNumber = phonenumber, ProfilePath = PATH, EmailConfirmed = true, PhoneNumberConfirmed = true };
                var result = await _userManager.CreateAsync(user, password);
                await _userManager.AddToRoleAsync(user, "Content Writer");

                return RedirectToAction(nameof(ContentWriters));

            }
            return View();
        }

        public async Task<IActionResult> SalesByProductQReport()
        {
            List<SalesByProductQReportData> salesByProductQReportDatas = new List<SalesByProductQReportData>();

            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            List<User> users = new List<User>();
            var userRole = _userManager.GetUsersInRoleAsync("Owner").Result;
            users = userRole.OfType<User>().ToList();
           
           
            List<Product> prod = new List<Product>();
            prod = (from p in _context.Products select p).ToList();
            prod.Insert(0, new Product { Id = 0, Name = "All Products" });
            ViewBag.message = prod;
            return View(salesByProductQReportDatas);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SalesByProductQReport(DateTime startDate,DateTime endDate,int product)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            ViewBag.Date = endDate.Year + "/" + endDate.Month + "/" + endDate.Day + "   -   " + startDate.Year + "/" + startDate.Month + "/" + startDate.Day;

            List<SalesByProductQReportData> salesByProductQReportDatas = new List<SalesByProductQReportData>();
            if (ModelState.IsValid)
            {
                var Products = (from p in _context.Products
                                join op in _context.OrderProduct on p.Id equals op.ProductId
                                join or in _context.Orders on op.OrderId equals or.Id
                                join ps in _context.ProductStore
                                on p.Id equals ps.productId
                                join s in _context.Stores
                                on ps.storeId equals s.Id
                                join u in _context.Units
                                on p.UnitId equals u.Id
                                where startDate.Date <= or.OrderDate.Date && endDate.Date >= or.OrderDate.Date
                                select new JoinTable { store = s, order = or, orderProduct = op, product = p, productStore = ps,Unit=u }).ToList();
                if (product != 0)
                {
                    Products = Products.Where(x => x.product.Id == product && startDate.Date <= x.order.OrderDate.Date && endDate.Date >= x.order.OrderDate.Date).ToList();
                }
                Products.GroupBy(k => k.orderProduct.ProductId).ToList().ForEach(x =>
                {
                    decimal total = 0;
                    SalesByProductQReportData ele = new SalesByProductQReportData();
                    ele.ProductId = x.Select(c => c.product.Id).First();
                    ele.ProductName = x.Select(c => c.orderProduct.ProductName).First();
                    ele.StoreName = x.Select(c => c.store.StoreName).First();
                    ele.UnitName  =  x.Select(x => x.Unit.UnitName).First();
                    List<string> units = new List<string>() { "Kg" };
                    bool hasWeight = false;
                    var uId = from u in _context.Units
                              select u;
                    var uIds = uId.Where(x => units.Contains(x.UnitName)).ToList();
                    var uIDs = uIds.Select(x => x.Id);

                    foreach (var u in uIDs)
                    {
                        if (x.Select(c => c.product.UnitId).First().ToString().Contains(u.ToString()))
                        {
                            hasWeight = true;
                            break;
                        }
                    }

                    if (hasWeight)
                    {
                        ele.Quantity = x.Select(c => c.orderProduct.Value).Sum();
                    }
                    else
                    {
                        ele.Quantity = x.Select(c => c.orderProduct.Quantity).Sum();
                    }
                    hasWeight = false;
                    salesByProductQReportDatas.Add(ele);
                });


            }
            List<Product> prod = new List<Product>();
            prod = (from p in _context.Products select p).ToList();
            prod.Insert(0, new Product { Id = 0, Name = "All Products" });
            ViewBag.message = prod;

            return View(salesByProductQReportDatas.OrderByDescending(x=>x.Quantity));
        }
       public class SalesByProductQReportData
        {
            public int StoreId { get; set; }
            public string StoreName { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string UnitName { get; set; }
            public decimal Quantity { get; set; }
            public decimal Sales { get; set; }

        }
        public async Task<IActionResult> SalesByProductReport()
        {
            List<SalesByProductReportData> salesByProductReportDatas = new List<SalesByProductReportData>();

            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            List<User> users = new List<User>();
            var userRole = _userManager.GetUsersInRoleAsync("Owner").Result;
            users = userRole.OfType<User>().ToList();


            List<Product> product = new List<Product>();
            product = (from p in _context.Products select p).ToList();
            product.Insert(0, new Product { Id = 0, Name = "All Products" });
            ViewBag.message = product;
            return View(salesByProductReportDatas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SalesByProductReport(DateTime startDate, DateTime endDate, int product)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            ViewBag.Date = endDate.Year + "/" + endDate.Month + "/" + endDate.Day + "   -   " + startDate.Year + "/" + startDate.Month + "/" + startDate.Day;
            List<SalesByProductReportData> salesByProductReportDatas = new List<SalesByProductReportData>();
            if (ModelState.IsValid)
            {
                var Products = (from p in _context.Products
                              join op in _context.OrderProduct on p.Id equals op.ProductId
                              join or in _context.Orders on op.OrderId equals or.Id
                              join ps in _context.ProductStore
                              on p.Id equals ps.productId
                              join s in _context.Stores
                              on ps.storeId equals s.Id
                              where startDate.Date <= or.OrderDate.Date && endDate.Date >= or.OrderDate.Date
                              select new JoinTable { store = s, order = or, orderProduct = op, product = p, productStore = ps }).ToList();
                if (product != 0)
                {
                    Products = Products.Where(x => x.product.Id == product && startDate.Date <= x.order.OrderDate.Date && endDate.Date >= x.order.OrderDate.Date).ToList();
                }
                Products.ToList().ForEach(x =>
                {
                    decimal total = 0;
                    SalesByProductReportData ele = new SalesByProductReportData();
                    ele.ProductId = x.product.Id;
                    ele.ProductName = x.product.Name;


                    Products.Where(s => s.product.Id == x.product.Id).ToList().ForEach(v =>
                    {
                        total += (v.product.Price * v.orderProduct.Quantity);
                    });

                    ele.Sales = total;
                    ViewBag.Sales = total;
                    salesByProductReportDatas.Add(ele);
                });


            }
            List<Product> prod = new List<Product>();
            prod = (from p in _context.Products select p).ToList();
            prod.Insert(0, new Product { Id = 0, Name = "All Products" });
            ViewBag.message = prod;

            return View(salesByProductReportDatas.OrderByDescending(x=>x.Sales));
        }
        public class SalesByProductReportData
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal Sales { get; set; }

        }

        public async Task<IActionResult> RevenueReport()
        {
            List<RevenueReportData> revenueReportDatas = new List<RevenueReportData>();

            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            List<User> users = new List<User>();
            var userRole = _userManager.GetUsersInRoleAsync("Owner").Result;
            users = userRole.OfType<User>().ToList();


            List<Product> product = new List<Product>();
            product = (from p in _context.Products select p).ToList();
            product.Insert(0, new Product { Id = 0, Name = "All Products" });
            ViewBag.message = product;
            List<Store> store = new List<Store>();
            store = (from s in _context.Stores select s).ToList();
            store.Insert(0, new Store { Id = 0, StoreName = "All Stores" });
            ViewBag.message1 = store;
            return View(revenueReportDatas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RevenueReport(DateTime startDate, DateTime endDate, int product,int store)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            ViewBag.Date = endDate.Year + "/" + endDate.Month + "/" + endDate.Day + "   -   " + startDate.Year + "/" + startDate.Month + "/" + startDate.Day;
            List<RevenueReportData> revenueReportDatas = new List<RevenueReportData>();
            if (ModelState.IsValid)
            {
                var ProductsStores = (from p in _context.Products
                                join op in _context.OrderProduct on p.Id equals op.ProductId
                                join or in _context.Orders on op.OrderId equals or.Id
                                join ps in _context.ProductStore
                                on p.Id equals ps.productId
                                join s in _context.Stores
                                on ps.storeId equals s.Id
                                join u in _context.Units
                                on p.UnitId equals u.Id
                                where startDate.Date <= or.OrderDate.Date && endDate.Date >= or.OrderDate.Date
                                select new JoinTable { store = s, order = or, orderProduct = op, product = p, productStore = ps,Unit= u}).ToList();
                if (product != 0 && store !=0)
                {
                    ProductsStores = ProductsStores.Where(x => x.product.Id == product && x.store.Id==store && startDate.Date <= x.order.OrderDate.Date && endDate.Date >= x.order.OrderDate.Date).ToList();
                }
                else if (product != 0 && store == 0)
                {
                    ProductsStores = ProductsStores.Where(x => x.product.Id == product && startDate.Date <= x.order.OrderDate.Date && endDate.Date >= x.order.OrderDate.Date).ToList();
                }
                else if (product == 0 && store != 0)
                {
                    ProductsStores = ProductsStores.Where(x => x.store.Id == store && startDate.Date <= x.order.OrderDate.Date && endDate.Date >= x.order.OrderDate.Date).ToList();
                }
                ProductsStores.GroupBy(k => k.orderProduct.ProductId).ToList().ForEach(x =>
                {
                    decimal total = 0;
                    RevenueReportData ele = new RevenueReportData();
                    ele.ProductId = x.Select(c => c.product.Id).First();
                    ele.ProductName = x.Select(c => c.orderProduct.ProductName).First();
                    ele.StoreId = x.Select(c => c.store.Id).First();
                    ele.StoreName = x.Select(c => c.store.StoreName).First();
                    ele.Sales = x.Select(c => c.orderProduct.Total).Sum();



                    total += ele.Sales;
                    ViewBag.sName = ele.StoreName;
                    revenueReportDatas.Add(ele);
                });


            }
            List<Product> prod = new List<Product>();
            prod = (from p in _context.Products select p).ToList();
            prod.Insert(0, new Product { Id = 0, Name = "All Products" });
            ViewBag.message = prod;
            List<Store> Store = new List<Store>();
            Store = (from s in _context.Stores select s).ToList();
            Store.Insert(0, new Store { Id = 0, StoreName = "All Stores" });
            ViewBag.message1 = Store;

            return View(revenueReportDatas);
        }

        public class RevenueReportData : SalesByProductQReportData
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal Sales { get; set; }
        }


        public IActionResult Home()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            var design= (from s in _context.Design
                        where s.Id.StartsWith("Slider")
                        select s).ToList().LastOrDefault();
            return View(design);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Home([Bind("Id,SlideImage1,ImageFile1,SlideImage2,ImageFile2,SlideImage3,ImageFile3,SubText1,SubText2,SubText3,MainText1,MainText2,MainText3,UserId")] Design design)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;

            if (design.ImageFile1 != null)
                    {
                        string wwwrootPath = _WebHostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + design.ImageFile1.FileName;
                        string path = Path.Combine(wwwrootPath + "/Images/Sliders/" + fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await design.ImageFile1.CopyToAsync(fileStream);
                        }

                design.SlideImage1 = fileName;
                    }
            if (design.ImageFile2 != null)
            {
                string wwwrootPath = _WebHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "_" + design.ImageFile2.FileName;
                string path = Path.Combine(wwwrootPath + "/Images/Sliders/" + fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await design.ImageFile2.CopyToAsync(fileStream);
                }

                design.SlideImage2 = fileName;
            }
            if (design.ImageFile3 != null)
            {
                string wwwrootPath = _WebHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "_" + design.ImageFile3.FileName;
                string path = Path.Combine(wwwrootPath + "/Images/Sliders/" + fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await design.ImageFile3.CopyToAsync(fileStream);
                }
                design.SlideImage3 = fileName;
            }

            var id = (from s in _context.Design
                     where s.Id.StartsWith("Slider")
                     select s).ToList().LastOrDefault();
            if (id ==null)
            {
                design.Id = "Slider" + 1;
            }
            else
            {
                string strId = id.Id.Substring(6);
                
                int newID = int.Parse(strId);
                newID += 1;
                design.Id = "Slider" + newID;
            }
           
           
            _context.Add(design);
            await _context.SaveChangesAsync();

            return View(design);
        }
        public IActionResult AdvertiseDiscounts()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            var ad= (from s in _context.Design
                         where s.Id.StartsWith("Ad")
                         select s).ToList().LastOrDefault();
            return View(ad);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdvertiseDiscounts([Bind("Id,SlideImage1,ImageFile1,SlideImage2,ImageFile2,SlideImage3,ImageFile3,SubText1,SubText2,SubText3,MainText1,MainText2,MainText3,UserId")] Design design)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;

            if (design.ImageFile1 != null)
            {
                string wwwrootPath = _WebHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "_" + design.ImageFile1.FileName;
                string path = Path.Combine(wwwrootPath + "/Images/Ads/" + fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await design.ImageFile1.CopyToAsync(fileStream);
                }

                design.SlideImage1 = fileName;
            }
           
            var id = (from s in _context.Design
                      where s.Id.StartsWith("Ad")
                      select s).ToList().LastOrDefault();
            if (id == null)
            {
                design.Id = "Ad" + 1;
            }
            else
            {
                string strId = id.Id.Substring(6);
                int newID = int.Parse(strId);
                newID += 1;
                design.Id = "Ad" + newID;
            }


            _context.Add(design);
            await _context.SaveChangesAsync();

            return View(design);
        }

        public IActionResult ManageFeedback()
        {

            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
           var feedback = (from f in _context.Feedback
                        join u in _context.User on f.UserId equals u.Id
                        join s in _context.Status on f.FeedbackStatus equals s.Id
                        select new FeedbackUser { Feedback = f, User = u, Status = s }).ToList();
            List<Status> stat = new List<Status>();
            stat = (from s in _context.Status select s).Take(3).ToList();
            stat.Insert(0, new Status { Id = 0, StatusName = "Filter by feedback status (All)" });
            ViewBag.message = stat;
            return View(feedback.OrderByDescending(x=>x.Feedback.Id));
        }

        [HttpPost]
        public IActionResult ManageFeedback(int? id)
        {

            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
           
               var feedback = (from f in _context.Feedback
                            join u in _context.User on f.UserId equals u.Id
                            join s in _context.Status on f.FeedbackStatus equals s.Id
                            where f.FeedbackStatus == id
                            select new FeedbackUser { Feedback = f, User = u, Status = s }).ToList();
            if (id == 0 | id == null)
            {
                 feedback = (from f in _context.Feedback
                                join u in _context.User on f.UserId equals u.Id
                                join s in _context.Status on f.FeedbackStatus equals s.Id
                                select new FeedbackUser { Feedback = f, User = u, Status = s }).ToList();
            }
            List<Status> stat = new List<Status>();
            stat = (from s in _context.Status select s).Take(3).ToList();
            stat.Insert(0, new Status { Id = 0, StatusName = "Filter by feedback status (All)" });
            ViewBag.message = stat;
            return View(feedback.OrderByDescending(x=>x.Feedback.Id));
        }
        public async Task<IActionResult> Approve(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedback.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id, [Bind("Id,FeedbackText,FeedbackStatus,UserId0")] Feedback feedback)
        {
            if (id != feedback.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var feed = _context.Feedback.First(a => a.Id == id);
                    feed.FeedbackStatus = 2;
                    _context.SaveChanges();
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedBackExists(feedback.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ManageFeedback));
            }
            return View(feedback);
        }


        public async Task<IActionResult> Reject(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedback.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id, [Bind("Id,FeedbackText,FeedbackStatus,UserId")] Feedback feedback)
        {
            if (id != feedback.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var feed = _context.Feedback.First(a => a.Id == id);
                    feed.FeedbackStatus = 3;
                    _context.SaveChanges();
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedBackExists(feedback.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ManageFeedback));
            }
            return View(feedback);
        }

        private bool FeedBackExists(int id)
        {
            return _context.Feedback.Any(e => e.Id == id);
        }

        public IActionResult Inbox()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            var messages = (from m in _context.contactUs
                            where m.ShowHide == 1
                            select m).ToList();
            return View(messages.OrderByDescending(x=>x.Date));
        }

        
        public IActionResult Trash()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            var messages = (from m in _context.contactUs
                            where m.ShowHide == 0
                            select m).ToList();
            return View(messages.OrderByDescending(x => x.Date));
        }
        public async Task<IActionResult> Message(int? id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.contactUs.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }
        
        public async Task<IActionResult> MoveToTrash(int? id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.contactUs.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            message.ShowHide = 0;
            _context.Update(message);
            _context.SaveChanges();
            return RedirectToAction(nameof(Inbox));
        }
        
        public async Task<IActionResult> Recover(int? id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.contactUs.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            message.ShowHide = 1;
            _context.Update(message);
            _context.SaveChanges();
            return RedirectToAction(nameof(Trash));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedMessage(int id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            var message = await _context.contactUs.FindAsync(id);
            _context.contactUs.Remove(message);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Trash));
        }

        [HttpPost]
        public async Task<IActionResult> Reply(int id, string subject, string email,string name,string message)
        {

            EmailDto mail = new EmailDto();
            mail.Subject = "Re:"+subject;
            mail.To = email;
            mail.Body = message;
            IEmailService emailService = new EmailService(_config);
            EmailController emailController = new EmailController(emailService);
            emailController.SendEmail(mail);
                 _context.SaveChanges();
                  await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Inbox));
        }


        #region Admin Dashboard
        #region TotalRevenueChart
        [HttpGet]
        public JsonResult TotalRevenueChart()
        {
            FinalResult finalResult = new FinalResult();

            List<TotalRevenueChartData> result = new List<TotalRevenueChartData>();
            List<string> categories = new List<string>();

            List<Order> oOrder = (from o in _context.Orders
                                  select o).ToList();

            oOrder.Select(c => c.OrderDate.Year).Distinct().ToList().ForEach(y =>
            {
                TotalRevenueChartData ele = new TotalRevenueChartData();
                ele.name = y.ToString();

                List<int> monthsPerYear = oOrder.Where(c => c.OrderDate.Year == y).Select(d => d.OrderDate.Month).Distinct().ToList();
                monthsPerYear.ForEach(m =>
                {
                    decimal sum = oOrder.Where(x => x.OrderDate.Month == m && x.OrderDate.Year == y).Sum(s => s.TotalPrice);
                    ele.data.Add(sum);
                    if (!categories.Contains(Months(m)))
                    {
                        categories.Add(Months(m));
                    }
                });
                result.Add(ele);
            });
            finalResult.oData.AddRange(result);
            finalResult.oCategories.AddRange(categories);
            return Json(finalResult);
        }
        public class FinalResult
        {
            public FinalResult()
            {
                oData = new List<TotalRevenueChartData>();
                oCategories = new List<string>();
            }
            public List<TotalRevenueChartData> oData { get; set; }
            public List<string> oCategories { get; set; }
        }
        public class TotalRevenueChartData
        {
            public TotalRevenueChartData()
            {
                data = new List<decimal>();
            }
            public string name { get; set; }
            public List<decimal> data { get; set; }
        }
        public string Months(int id)
        {
            string month = "";
            switch (id)
            {
                case 1:
                    month = "Jan"; break;
                case 2:
                    month = "Feb"; break;
                case 3:
                    month = "Mar"; break;
                case 4:
                    month = "Apr"; break;
                case 5:
                    month = "May"; break;
                case 6:
                    month = "June"; break;
                case 7:
                    month = "July"; break;
                case 8:
                    month = "Aug"; break;
                case 9:
                    month = "Sep"; break;
                case 10:
                    month = "Oct"; break;
                case 11:
                    month = "Nov"; break;
                case 12:
                    month = "Dec"; break;
            }
            return month;
        }
        #endregion

        #region OrderStatisticsChart
        [HttpGet]
        public JsonResult OrderStatisticsChart()
        {
            OrderStatisticsChartData result = new OrderStatisticsChartData();
            var oJoin = (from p in _context.Products
                                      join op in _context.OrderProduct on p.Id equals op.ProductId
                                      join or in _context.Orders on op.OrderId equals or.Id
                                      join ps in _context.ProductStore
                                      on p.Id equals ps.productId
                                      join s in _context.Stores
                                      on ps.storeId equals s.Id
                                      join u in _context.Units
                                      on p.UnitId equals u.Id
                                      join c in _context.SubCategories
                                      on p.CategoryId equals c.Id
                                      select new JoinTable1 { store = s, order = or, orderProduct = op, product = p, productStore = ps, Unit = u , SubCategory = c}).ToList();

            decimal total = oJoin.Select(d => d.orderProduct.ProductId).Count();
            result.total = total;
            ViewBag.total = total;
            oJoin.Select(c => c.SubCategory).Distinct().ToList().ForEach(s => {
                result.labels.Add(s.SubCategoryName);

                decimal perc = Math.Round((oJoin.Where(e => e.product.CategoryId == s.Id).Select(d => d.orderProduct.ProductId).Count() / total) * 100,2);
                result.data.Add(perc);
            });
            return Json(result);
        }


        public class OrderStatisticsChartData
        {
            public OrderStatisticsChartData()
            {
                data = new List<decimal>();
                labels = new List<string>();
            }
            public decimal total { get; set; }
            public List<decimal> data { get; set; }
            public List<string> labels { get; set; }
        }
        #endregion
        #endregion
    }
}
