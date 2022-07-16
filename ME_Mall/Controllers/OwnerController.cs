using ME_Mall.Data;
using ME_Mall.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ME_Mall.Controllers
{
    [Authorize(Roles = "Owner")]
    public class OwnerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public OwnerController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager,
                              UserManager<User> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.roleManager = roleManager;
            _userManager = userManager;
            _WebHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var user = (from u in _context.User
                       where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                       select u).ToList();
            var fullName=user.Select(x => x.FirstName).First() + " " +user.Select(x => x.LastName).First();

            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            var stores = from s in _context.Stores
                         select s;
            var sName = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).StoreName;
            var sId= stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).Id;
            ViewBag.sName = sName;
            List<OrderStatisticsData> result = new List<OrderStatisticsData>();
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
                         where s.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value
                         select new JoinTable1 { store = s, order = or, orderProduct = op, product = p, productStore = ps, Unit = u, SubCategory = c }).ToList();

            oJoin.Select(c => c.SubCategory).Distinct().ToList().ForEach(s => {
                OrderStatisticsData ele = new OrderStatisticsData();
                ele.labels = s.SubCategoryName;
                ele.data = oJoin.Where(e => e.product.CategoryId == s.Id).Select(d => d.orderProduct.ProductId).Count();
                result.Add(ele);
            });
            ViewBag.total = oJoin.Count();
            ViewBag.products = (from p in _context.Products
                               join ps in _context.ProductStore on p.Id equals ps.productId
                               where ps.storeId == sId
                               select p).Count();
            ViewBag.subcategories = (from p in _context.Products
                                     join ps in _context.ProductStore on p.Id equals ps.productId
                                     join s in _context.SubCategories on p.CategoryId equals s.Id
                                     where ps.storeId == sId
                                     select s).Distinct().Count();
            ViewBag.revenue = oJoin.Sum(x => x.orderProduct.Total);
            return View(result);
        }
        public class OrderStatisticsData
        {
            public string labels { get; set; }
            public decimal data { get; set; }
        }
        public IActionResult Products()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;

            var stores = from s in _context.Stores
                      select s;
            var sName = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).StoreName;
            ViewBag.sName = sName;
            var sId = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).Id;
            var products = (from p in _context.Products
                          join ps in _context.ProductStore
                          on p.Id equals ps.productId
                           where ps.storeId == sId
                          select p).ToList();
            
            return View(products);
        }
        public IActionResult CreateProduct()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            var stores = from s in _context.Stores
                         select s;
            var sName = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).StoreName;
            ViewBag.sName = sName;
            List<SubCategory> subCat = new List<SubCategory>();
            subCat = (from s in _context.SubCategories select s).ToList();
            subCat.Insert(0, new SubCategory { Id = 0, SubCategoryName = "--Select Product Category--" });
            ViewBag.message = subCat;
            List<Unit> unit = new List<Unit>();
            unit = (from u in _context.Units select u).ToList();
            unit.Insert(0, new Unit { Id = 0, UnitName = "--Select Product Unit--" });
            ViewBag.message1 = unit;
            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct([Bind("Id,Name,ProductImage,Detail,Price,ImageFile,CategoryId,UnitId")] Product product)
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
                if (product.ImageFile != null)
                {
                    string wwwrootPath = _WebHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + product.ImageFile.FileName;
                    string path = Path.Combine(wwwrootPath + "/Images/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await product.ImageFile.CopyToAsync(fileStream);
                    }

                    product.ProductImage = fileName;
                }
            
                _context.Add(product);
                await _context.SaveChangesAsync();

                var stores = from s in _context.Stores
                             select s;
                var sName = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).StoreName;
                ViewBag.sName = sName;
                var sId = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).Id;
                ProductStore ps = new ProductStore();
                ps.productId = product.Id;
                ps.storeId = sId;
                _context.Add(ps);
               await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Products));
            }
            return View(product);
        }

        public async Task<IActionResult> EditProduct(int? id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            var stores = from s in _context.Stores
                         select s;
            var sName = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).StoreName;
            ViewBag.sName = sName;
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.pic = product.ProductImage;
            List<SubCategory> subCat = new List<SubCategory>();
            subCat = (from s in _context.SubCategories select s).ToList();
            subCat.Insert(0, new SubCategory { Id = 0, SubCategoryName = "--Select Food Category--" });
            ViewBag.message = subCat;
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, [Bind("Id,Name,ProductImage,Detail,Price,ImageFile,CategoryId")] Product product)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;

            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (product.ImageFile != null)
                    {
                        string wwwrootPath = _WebHostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + product.ImageFile.FileName;
                        string path = Path.Combine(wwwrootPath + "/Images/" + fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await product.ImageFile.CopyToAsync(fileStream);
                        }

                        product.ProductImage = fileName;
                    }
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Products));
            }
            return View(product);
        }
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            var stores = from s in _context.Stores
                         select s;
            var sName = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).StoreName;
            ViewBag.sName = sName;
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedProd(int id)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            var stores = from s in _context.Stores
                         select s;
            var sName = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).StoreName;
            ViewBag.sName = sName;
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Products));
        }
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
        public async Task<IActionResult> SalesByProductQReport()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            var stores = from s in _context.Stores
                         select s;
            var sId = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).Id;

            var sName = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).StoreName;
            ViewBag.sName = sName;
            List<SalesByProductQReportData> salesByProductQReportDatas = new List<SalesByProductQReportData>();

            List<Product> prod = new List<Product>();
            prod = (from p in _context.Products
                    join s in _context.ProductStore on p.Id equals s.productId
                    where s.storeId == sId
                    select p
                    ).ToList();
            prod.Insert(0, new Product { Id = 0, Name = "All Products" });
            ViewBag.message = prod;
            return View(salesByProductQReportDatas);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SalesByProductQReport(DateTime startDate, DateTime endDate, int product)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            var stores = from s in _context.Stores
                         select s;
            var sId = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).Id;

            var sName = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).StoreName;
            ViewBag.sName = sName;

            ViewBag.Date = endDate.Year + "/" + endDate.Month + "/" + endDate.Day + "   -   "+startDate.Year+ "/"+startDate.Month + "/"+startDate.Day;
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
                                where s.Id == sId && startDate.Date <= or.OrderDate.Date && endDate.Date >= or.OrderDate.Date
                                select new JoinTable { store = s, order = or, orderProduct = op, product = p, productStore = ps }).ToList();
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
            prod = (from p in _context.Products
                    join s in _context.ProductStore on p.Id equals s.productId
                    where s.storeId == sId
                    select p
                    ).ToList();
            prod.Insert(0, new Product { Id = 0, Name = "All Products" });
            ViewBag.message = prod;

            return View(salesByProductQReportDatas.OrderByDescending(x => x.Quantity));
        }
        public class SalesByProductQReportData
        {
            public int StoreId { get; set; }
            public string StoreName { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal Quantity { get; set; }
            public decimal Sales { get; set; }

        }
        public async Task<IActionResult> SalesByProductReport()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            var stores = from s in _context.Stores
                         select s;
            var sId = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).Id;

            var sName = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).StoreName;
            ViewBag.sName = sName;
            List<SalesByProductReportData> salesByProductReportDatas = new List<SalesByProductReportData>();           
            List<Product> prod = new List<Product>();
            prod = (from p in _context.Products
                    join s in _context.ProductStore on p.Id equals s.productId
                    where s.storeId == sId
                    select p
                    ).ToList();
            prod.Insert(0, new Product { Id = 0, Name = "All Products" });
            ViewBag.message = prod;
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
            var stores = from s in _context.Stores
                         select s;
            var sId = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).Id;

            var sName = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).StoreName;
            ViewBag.sName = sName;
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
                                where s.Id==sId && startDate.Date <= or.OrderDate.Date && endDate.Date >= or.OrderDate.Date
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
            prod = (from p in _context.Products
                    join s in _context.ProductStore on p.Id equals s.productId
                    where s.storeId == sId
                    select p
                    ).ToList();
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
            var stores = from s in _context.Stores
                         select s;
            var sName = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).StoreName;
            var sId = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).Id;
            ViewBag.sName = sName;
            List<User> users = new List<User>();
            var userRole = _userManager.GetUsersInRoleAsync("Owner").Result;
            users = userRole.OfType<User>().ToList();


            List<Product> product = new List<Product>();
            product = (from p in _context.Products 
                       join s in _context.ProductStore on p.Id equals s.productId
                       where s.storeId == sId
                       select p).ToList();
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
        public async Task<IActionResult> RevenueReport(DateTime startDate, DateTime endDate, int product)
        {
            List<RevenueReportData> revenueReportDatas = new List<RevenueReportData>();
            if (ModelState.IsValid)
            {
                var user = (from u in _context.User
                            where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                            select u).ToList();
                var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
                ViewBag.fullname = fullName;
                var profileImage = user.Select(x => x.ProfilePath).First();
                ViewBag.profileImage = profileImage;
                var stores = from s in _context.Stores
                             select s;
                var sName = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).StoreName;
                var sId = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).Id;
                ViewBag.sName = sName;
                ViewBag.Date = endDate.Year + "/" + endDate.Month + "/" + endDate.Day + "   -   " + startDate.Year + "/" + startDate.Month + "/" + startDate.Day;

                var ProductsStores = (from p in _context.Products
                                      join op in _context.OrderProduct on p.Id equals op.ProductId
                                      join or in _context.Orders on op.OrderId equals or.Id
                                      join ps in _context.ProductStore
                                      on p.Id equals ps.productId
                                      join s in _context.Stores
                                      on ps.storeId equals s.Id
                                      where startDate.Date <= or.OrderDate.Date && endDate.Date >= or.OrderDate.Date && s.Id == sId
                                      select new JoinTable { store = s, order = or, orderProduct = op, product = p, productStore = ps }).ToList();
                if (product != 0)
                {
                    ProductsStores = ProductsStores.Where(x => x.product.Id == product && startDate.Date <= x.order.OrderDate.Date && endDate.Date >= x.order.OrderDate.Date).ToList();
                }
                decimal total = 0;
                ProductsStores.GroupBy(k=>k.orderProduct.ProductId).ToList().ForEach(x =>
                {
                    RevenueReportData ele = new RevenueReportData();
                    ele.ProductId = x.Select(c => c.product.Id).First();
                    ele.ProductName = x.Select(c => c.orderProduct.ProductName).First();
                    ele.StoreId = x.Select(c => c.store.Id).First();
                    ele.StoreName = x.Select(c => c.store.StoreName).First();
                    ele.Sales = x.Select(c => c.orderProduct.Total).Sum();

                    //ProductsStores.Where(s => s.product.Id == x.product.Id).ToList().ForEach(v =>
                    //{
                    //    total += (v.product.Price * v.orderProduct.Quantity);
                    //});

                    //ele.Sales = total;
                    total += ele.Sales;
                    ViewBag.sName = ele.StoreName;
                    revenueReportDatas.Add(ele);
                });
                ViewBag.Sales = total;


                List<Product> prod = new List<Product>();
                prod = (from p in _context.Products
                        join s in _context.ProductStore on p.Id equals s.productId
                        where s.storeId == sId
                        select p).ToList();
                prod.Insert(0, new Product { Id = 0, Name = "All Products" });
                ViewBag.message = prod;
            }
            return View(revenueReportDatas);
        }

        public class RevenueReportData : SalesByProductQReportData
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal Sales { get; set; }
        }

        #region Owner Dashboard
        #region TotalRevenueChart
        [HttpGet]
        public JsonResult TotalRevenueChart()
        {
            FinalResult finalResult = new FinalResult();
            
            List<TotalRevenueChartData> result = new List<TotalRevenueChartData>();
            List<string> categories = new List<string>();

            //List<Order> oOrder = (from o in _context.Orders
            //                      select o).ToList();
            var stores = from s in _context.Stores
                         select s;
            var sId = stores.First(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value).Id;

            List<JoinTable> oOrder = (from p in _context.Products
                                  join op in _context.OrderProduct on p.Id equals op.ProductId
                                  join or in _context.Orders on op.OrderId equals or.Id
                                  join ps in _context.ProductStore
                                  on p.Id equals ps.productId
                                  join s in _context.Stores
                                  on ps.storeId equals s.Id
                                  where s.Id == sId
                                  select new JoinTable { store = s, order = or, orderProduct = op, product = p, productStore = ps }).ToList();

            oOrder.Select(c => c.order.OrderDate.Year).Distinct().ToList().ForEach(y =>
            {
                TotalRevenueChartData ele = new TotalRevenueChartData();
                ele.name = y.ToString();

                List<int> monthsPerYear = oOrder.Where(c => c.order.OrderDate.Year == y).Select(d => d.order.OrderDate.Month).Distinct().ToList();
                monthsPerYear.ForEach(m =>
                {
                    decimal sum = oOrder.Where(x => x.order.OrderDate.Month == m && x.order.OrderDate.Year == y).Sum(s => s.orderProduct.Total);
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
                         where s.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value
                         select new JoinTable1 { store = s, order = or, orderProduct = op, product = p, productStore = ps, Unit = u, SubCategory = c }).ToList();

            decimal total = oJoin.Select(d => d.orderProduct.ProductId).Count();
            result.total = total;
            ViewBag.total = total;
            oJoin.Select(c => c.SubCategory).Distinct().ToList().ForEach(s => {
                result.labels.Add(s.SubCategoryName);

                decimal perc = Math.Round((oJoin.Where(e => e.product.CategoryId == s.Id).Select(d => d.orderProduct.ProductId).Count() / total) * 100, 2);
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
