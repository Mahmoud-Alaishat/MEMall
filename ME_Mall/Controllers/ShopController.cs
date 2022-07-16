using ME_Mall.Data;
using ME_Mall.Models;
using ME_Mall.Services.EmailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ME_Mall.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;


        public ShopController(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public IActionResult Index(string store, int? page)
        {
            try
            {
                var user = (from u in _context.User
                            where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                            select u).ToList();
                var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
                ViewBag.fullname = fullName;
                var profileImage = user.Select(x => x.ProfilePath).First();
                ViewBag.profileImage = profileImage;

                var stores = (from s in _context.Stores
                              join u in _context.User on s.OwnerId equals u.Id
                              join c in _context.Categories on s.CategoryId equals c.Id
                              where s.StoreName.Contains(store)
                              select new StoreOwner { Store = s, User = u, Category = c }).ToList();

                if (store == null)
                {
                     stores = (from s in _context.Stores
                               join u in _context.User on s.OwnerId equals u.Id
                               join c in _context.Categories on s.CategoryId equals c.Id
                               select new StoreOwner { Store = s, User = u, Category = c }).ToList();
                }
                var pager = new Pager(stores.Count(), page);

                var viewModel = new IndexViewModel<StoreOwner>
                {
                    Items = stores.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                    Pager = pager
                };


                var categories = _context.Categories;
                var Stores = Tuple.Create<IndexViewModel<StoreOwner>, IEnumerable<Category>>(viewModel, categories);
                return View(Stores);
            }
            catch
            {
                var stores = (from s in _context.Stores
                              join u in _context.User on s.OwnerId equals u.Id
                              join c in _context.Categories on s.CategoryId equals c.Id
                              where s.StoreName.Contains(store)
                              select new StoreOwner { Store = s, User = u, Category = c }).ToList();
                if (store == null)
                {
                    stores = (from s in _context.Stores
                              join u in _context.User on s.OwnerId equals u.Id
                              join c in _context.Categories on s.CategoryId equals c.Id
                              select new StoreOwner { Store = s, User = u, Category = c }).ToList();
                }

                var pager = new Pager(stores.Count(), page);

                var viewModel = new IndexViewModel<StoreOwner>
                {
                    Items = stores.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                    Pager = pager
                };


                var categories = _context.Categories;
                var Stores = Tuple.Create<IndexViewModel<StoreOwner>, IEnumerable<Category>>(viewModel, categories);
                return View(Stores);

            }
        }
        public IActionResult Store(int id, string product, int? page)
        {
            try
            {
                var user = (from u in _context.User
                            where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                            select u).ToList();
                var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
                ViewBag.fullname = fullName;
                var profileImage = user.Select(x => x.ProfilePath).First();
                ViewBag.profileImage = profileImage;
                var products = getAllProduct(id);
                if(product != null)
                {
                    products = products.Where(x => x.Product.Name.Contains(product)).ToList();
                }
                var sName = (from s in _context.Stores
                             where s.Id == id
                             select s).SingleOrDefault();
                ViewBag.sName = sName.StoreName;
                ViewBag.storeCover = sName.CoverImage;
                ViewBag.storeStatement = sName.StoreStatement;
                var pager = new Pager(products.Count(), page);

                var viewModel = new IndexViewModel<ProductSubCat>
                {
                    Items = products.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                    Pager = pager
                };
                var subcategories = products.Select(x => x.SubCategory.SubCategoryName).Distinct();
                var Products = Tuple.Create<IndexViewModel<ProductSubCat>, IEnumerable<string>>(viewModel, subcategories);
                ViewBag.sId = id;
                return View(Products);
            }
            catch
            {
                var products = getAllProduct(id);
                if (product != null)
                {
                    products = products.Where(x => x.Product.Name.Contains(product)).ToList();
                }
                var sName = (from s in _context.Stores
                             where s.Id == id
                             select s).SingleOrDefault();
                ViewBag.sName = sName.StoreName;
                ViewBag.storeCover = sName.CoverImage;
                ViewBag.storeStatement = sName.StoreStatement;
                var pager = new Pager(products.Count(), page);

                var viewModel = new IndexViewModel<ProductSubCat>
                {
                    Items = products.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                    Pager = pager
                };
                var subcategories = products.Select(x => x.SubCategory.SubCategoryName).Distinct();
                var Products = Tuple.Create<IndexViewModel<ProductSubCat>, IEnumerable<string>>(viewModel, subcategories);
                ViewBag.sId = id;
                return View(Products);
            }
        }
        public IActionResult Cart()
        {
            try
            {
                var user = (from u in _context.User
                            where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                            select u).ToList();
                var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
                ViewBag.fullname = fullName;
                var profileImage = user.Select(x => x.ProfilePath).First();
                ViewBag.profileImage = profileImage;
                var cart = HttpContext.Session.GetString("cart");//get key cart
                if (cart != null)
                {
                    List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                    if (dataCart.Count > 0)
                    {
                        ViewBag.carts = dataCart;
                        List<string> units = new List<string>() { "Kg" };
                        var uId = from u in _context.Units
                                  select u;
                        var uIds = uId.Where(x => units.Contains(x.UnitName)).ToList();
                        var uIDs = uIds.Select(x => x.Id);
                        ViewBag.uIds = uIDs;
                        decimal subTotal = 0;
                        foreach (var item in ViewBag.carts)
                        {
                            string txt_class = "quantity_" + item.Product.Id;
                            bool hasWeight = false;
                            foreach(var u in uIDs)
                            {
                                if (item.Product.UnitId.ToString().Contains(u.ToString()))
                                {
                                    hasWeight = true;
                                    break;
                                }
                            }
                            if (hasWeight)
                            {
                                item.Total = item.Product.Price * item.Value;
                            }
                            else
                            {
                                item.Total = item.Product.Price * item.Quantity;
                            }
                            subTotal += item.Total;
                        }
                        ViewBag.hasCoupon = false;
                        decimal shipping = 2;
                        var Coupon = HttpContext.Session.GetInt32("Coupon");
                        decimal Tot = 0;
                        if (Coupon != null)
                        {
                            decimal dis = ((decimal)(Coupon * 0.01) * ((decimal)subTotal + shipping));
                            Tot = (subTotal + shipping) - dis;
                            ViewBag.hasCoupon = true;
                        }
                        else
                        {
                            Tot = subTotal + shipping;
                        }
                        ViewBag.OrgTotal = Tot = subTotal + shipping;
                        HttpContext.Session.SetString("subTotal",subTotal.ToString());
                        HttpContext.Session.SetString("Total", Tot.ToString());
                        ViewBag.Total = HttpContext.Session.GetString("Total");
                        ViewBag.subTotal = HttpContext.Session.GetString("subTotal");
                        ViewBag.Coupon = Coupon;
                        ViewBag.CouponCode = HttpContext.Session.GetString("CouponCode");
                        HttpContext.Session.SetString("shipping", shipping.ToString());
                        ViewBag.shipping = HttpContext.Session.GetString("shipping");
                    }
                }
                return View();
            }
            catch
            {
                var cart = HttpContext.Session.GetString("cart");//get key cart
                if (cart != null)
                {
                    List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                    if (dataCart.Count > 0)
                    {
                        ViewBag.carts = dataCart;
                        List<string> units = new List<string>() { "Kg" };
                        var uId = from u in _context.Units
                                  select u;
                        var uIds = uId.Where(x => units.Contains(x.UnitName)).ToList();
                        var uIDs = uIds.Select(x => x.Id);
                        ViewBag.uIds = uIDs;
                        decimal subTotal = 0;
                        foreach (var item in ViewBag.carts)
                        {
                            string txt_class = "quantity_" + item.Product.Id;
                            bool hasWeight = false;
                            foreach (var u in uIDs)
                            {
                                if (item.Product.UnitId.ToString().Contains(u.ToString()))
                                {
                                    hasWeight = true;
                                    break;
                                }
                            }
                            if (hasWeight)
                            {
                                item.Total = item.Product.Price * item.Value;
                            }
                            else
                            {
                                item.Total = item.Product.Price * item.Quantity;
                            }
                            subTotal += item.Total;
                        }
                        ViewBag.hasCoupon = false;
                        decimal shipping = 2;
                        var Coupon = HttpContext.Session.GetInt32("Coupon");
                        decimal Tot = 0;
                        if (Coupon != null)
                        {
                            decimal dis = ((decimal)(Coupon * 0.01) * ((decimal)subTotal + shipping));
                            Tot = (subTotal + shipping) - dis;
                            ViewBag.hasCoupon = true;
                        }
                        else
                        {
                            Tot = subTotal + shipping;
                        }
                        HttpContext.Session.SetString("OrgTotal", (subTotal + shipping).ToString());
                        ViewBag.OrgTotal = HttpContext.Session.GetString("OrgTotal");
                        HttpContext.Session.SetString("subTotal", subTotal.ToString());
                        HttpContext.Session.SetString("Total", Tot.ToString());
                        ViewBag.Total = HttpContext.Session.GetString("Total");
                        ViewBag.subTotal = HttpContext.Session.GetString("subTotal");
                        ViewBag.Coupon = Coupon;
                        ViewBag.CouponCode = HttpContext.Session.GetString("CouponCode");
                        HttpContext.Session.SetString("shipping", shipping.ToString());
                        ViewBag.shipping = HttpContext.Session.GetString("shipping");
                    }
                }

                return View();
            }
        }
        [HttpPost]
        public IActionResult Cart(string Coupon)
        {
            try
            {
                var user = (from u in _context.User
                            where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                            select u).ToList();
                var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
                ViewBag.fullname = fullName;
                var profileImage = user.Select(x => x.ProfilePath).First();
                ViewBag.profileImage = profileImage;
                var cart = HttpContext.Session.GetString("cart");//get key cart
                if (cart != null)
                {
                    List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                    if (dataCart.Count > 0)
                    {
                        ViewBag.carts = dataCart;
                        List<string> units = new List<string>() { "Kg" };
                        var uId = from u in _context.Units
                                  select u;
                        var uIds = uId.Where(x => units.Contains(x.UnitName)).ToList();
                        var uIDs = uIds.Select(x => x.Id);
                        ViewBag.uIds = uIDs;
                        ApplyCoupon(Coupon);
                    }
                }
                return View();
            }
            catch
            {
                var cart = HttpContext.Session.GetString("cart");//get key cart
                if (cart != null)
                {
                    List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                    if (dataCart.Count > 0)
                    {
                        List<string> units = new List<string>() { "Kg" };
                        var uId = from u in _context.Units
                                  select u;
                        var uIds = uId.Where(x => units.Contains(x.UnitName)).ToList();
                        var uIDs = uIds.Select(x => x.Id);
                        ViewBag.uIds = uIDs;
                        ViewBag.carts = dataCart;
                        ApplyCoupon(Coupon);
                    }
                }
                return View();
            }
        }
        [Authorize(Roles = "User")]
        public IActionResult CheckOut()
        {
           if(HttpContext.Session.GetString("cart") == null | HttpContext.Session.GetString("cart") =="[]")
            {
               return RedirectToAction("Index");
            }
             var user = (from u in _context.User
                         where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                         select u).ToList();
             var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
             ViewBag.fullname = fullName;
             var profileImage = user.Select(x => x.ProfilePath).First();
             ViewBag.profileImage = profileImage;
             var email = user.Select(x => x.Email).First();
             ViewBag.email = email;
             var phone = user.Select(x => x.PhoneNumber).First();
             ViewBag.phone = phone;
             var cart = HttpContext.Session.GetString("cart");//get key cart
             if (cart != null)
             {
                 List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                 if (dataCart.Count > 0)
                 {
                     ViewBag.carts = dataCart;
                     List<string> units = new List<string>() { "Kg" };
                     var uId = from u in _context.Units
                               select u;
                     var uIds = uId.Where(x => units.Contains(x.UnitName)).ToList();
                     var uIDs = uIds.Select(x => x.Id);
                     ViewBag.uIds = uIDs;
                     ViewBag.Coupon = HttpContext.Session.GetInt32("Coupon");
                    decimal subTotal = 0;
                    decimal shipping = 2;
                    bool hasCoupon = false;
                    foreach (var item in dataCart)
                    {
                        decimal total = 0;
                        bool hasWeight = false;
                        foreach (var u in uIDs)
                        {
                            if (item.Product.UnitId.ToString().Contains(u.ToString()))
                            {
                                hasWeight = true;
                                break;
                            }
                        }
                        if (hasWeight)
                        {
                            total = item.Product.Price * item.Value;
                            item.Total = total;
                        }
                        else
                        {
                            total = item.Product.Price * item.Quantity;
                            item.Total = total;
                        }
                        subTotal += total;
                    }
                    decimal Tot = 0;
                    if (HttpContext.Session.GetInt32("Coupon") != null)
                    {
                        decimal dis = ((decimal)(@ViewBag.Coupon * 0.01) * ((decimal)subTotal + shipping));
                        Tot = (subTotal + shipping) - dis;
                        hasCoupon = true;
                    }
                    else
                    {
                        Tot = subTotal + shipping;
                    }
                    HttpContext.Session.SetString("FinalTotal", Tot.ToString());
                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                }
            }
             return View();
        }
        [HttpPost]
        public IActionResult CheckOut(string address, string notes, string cardNumber,int CVV,string holder,int month,int year)
        {
                var tot =Convert.ToDecimal(HttpContext.Session.GetString("FinalTotal"));
                var user = (from u in _context.User
                            where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                            select u).ToList();
                var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
                ViewBag.fullname = fullName;
                var profileImage = user.Select(x => x.ProfilePath).FirstOrDefault();
                ViewBag.profileImage = profileImage;
                var email = user.Select(x => x.Email).FirstOrDefault();
                ViewBag.email = email;
                var phone = user.Select(x => x.PhoneNumber).FirstOrDefault();
                ViewBag.phone = phone;
                var visaCard = (from v in _context.Bank
                           where v.CardNumber == cardNumber && v.CCV == CVV
                           && v.HolderName == holder
                           && v.ExpiryMonth == month && v.ExpiryYear == year
                           select v).SingleOrDefault();
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                if (dataCart.Count > 0)
                {
                    ViewBag.carts = dataCart;
                    List<string> units = new List<string>() { "Kg" };
                    var uId = from u in _context.Units
                              select u;
                    var uIds = uId.Where(x => units.Contains(x.UnitName)).ToList();
                    var uIDs = uIds.Select(x => x.Id);
                    ViewBag.uIds = uIDs;
                    ViewBag.Coupon = HttpContext.Session.GetInt32("Coupon");
                    decimal subTotal = 0;
                    decimal shipping = 2;
                    bool hasCoupon = false;
                    foreach (var item in dataCart)
                    {
                        decimal total = 0;
                        bool hasWeight = false;
                        foreach (var u in uIDs)
                        {
                            if (item.Product.UnitId.ToString().Contains(u.ToString()))
                            {
                                hasWeight = true;
                                break;
                            }
                        }
                        if (hasWeight)
                        {
                            total = item.Product.Price * item.Value;
                            item.Total = total;
                        }
                        else
                        {
                            total = item.Product.Price * item.Quantity;
                            item.Total = total;
                        }
                        subTotal += total;
                    }
                    decimal Tot = 0;
                    if (HttpContext.Session.GetInt32("Coupon") != null)
                    {
                        decimal dis = ((decimal)(@ViewBag.Coupon * 0.01) * ((decimal)subTotal + shipping));
                        Tot = (subTotal + shipping) - dis;
                        hasCoupon = true;
                    }
                    else
                    {
                        Tot = subTotal + shipping;
                    }
                    HttpContext.Session.SetString("FinalTotal", Tot.ToString());
                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                }
            }
            if (visaCard == null)
                {
                ViewBag.message = "Visa card entered is not found please make sure you have entered the card information correctly";
                }
                else 
                {
                if (tot > visaCard.Balance)
                {
                    ViewBag.message = "Card balance is less than the total";
                }
                else
                {

                     cart = HttpContext.Session.GetString("cart");//get key cart

                    List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                    if (dataCart.Count > 0)
                    {
                        ViewBag.carts = dataCart;
                        List<string> units = new List<string>() { "Kg" };
                        var uId = from u in _context.Units
                                  select u;
                        var uIds = uId.Where(x => units.Contains(x.UnitName)).ToList();
                        var uIDs = uIds.Select(x => x.Id);
                        ViewBag.uIds = uIDs;
                        ViewBag.Coupon = HttpContext.Session.GetInt32("Coupon");
                        Order order = new Order();
                        order.OrderDate = DateTime.Now;
                        order.OrderAddress = address;
                        order.Notes = notes;
                        order.TotalPrice = tot;
                        order.OrderStatus = 4;
                        order.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                        _context.Add(order);
                        _context.SaveChangesAsync();
                        //var ordId = (from o in _context.Orders
                        //             where o.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        //             select o.Id).LastOrDefault();
                        foreach (var item in dataCart)
                        {
                            OrderProduct orderProduct = new OrderProduct();
                            orderProduct.OrderId = order.Id;
                            orderProduct.ProductId = item.Product.Id;
                            orderProduct.ProductName = item.Product.Name;
                            orderProduct.Quantity = item.Quantity;
                            orderProduct.Value = item.Value;
                            orderProduct.Total = item.Total;
                            _context.Add(orderProduct);
                        }
                        _context.SaveChangesAsync();
                    }
                    return RedirectToAction(nameof(OrderSucceeded));
                }
             }
                
                return View();
           }
        

        public IActionResult ProductDetails(int id)
        {
            try
            {
                var user = (from u in _context.User
                            where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                            select u).ToList();
                var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
                ViewBag.fullname = fullName;
                var profileImage = user.Select(x => x.ProfilePath).First();
                ViewBag.profileImage = profileImage;
                var products = getDetailProduct(id);
                var sName = (from ps in _context.ProductStore
                             join s in _context.Stores on ps.storeId equals s.Id
                             where ps.productId ==id
                             select s.StoreName).SingleOrDefault();
                ViewBag.sName = sName;
                return View(products);
            }
            catch {
                var products = getDetailProduct(id);
                var sName = (from ps in _context.ProductStore
                             join s in _context.Stores on ps.storeId equals s.Id
                             where ps.productId == id
                             select s.StoreName).SingleOrDefault();
                ViewBag.sName = sName;
                return View(products);
            }
        }
        public IActionResult OrderSucceeded()
        {
           
                var user = (from u in _context.User
                            where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                            select u).ToList();
                var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
                ViewBag.fullname = fullName;
                var profileImage = user.Select(x => x.ProfilePath).First();
                ViewBag.profileImage = profileImage;
                var email = user.Select(x => x.Email).First();
                var orders = from o in _context.Orders
                             where o.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value
                             select o;
                var feedbacks = from f in _context.Feedback
                               where f.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value
                               select f;
                ViewBag.isFirstOrder = orders.Count();
                ViewBag.isSentFeedback = feedbacks.Count();
                var cart=  HttpContext.Session.GetString("cart");
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);

                var orderList = "<div style='color:#FFF;width:100%;border-radius:10px;'>Your order:<br/><br/><div style='background: #F28123;padding:24px;border-radius:10px;'>";
                var tot = HttpContext.Session.GetString("FinalTotal");;
                bool hasWeight = false;
                List<string> units = new List<string>() { "Kg" };

                var uId = from u in _context.Units
                          select u;
                var uIds = uId.Where(x => units.Contains(x.UnitName)).ToList();
                var uIDs = uIds.Select(x => x.Id);
                ViewBag.uIds = uIDs;
                var coupon = HttpContext.Session.GetInt32("Coupon");
                foreach (var item in dataCart)
                {
                foreach (var u in uIDs)
                {
                    if (item.Product.UnitId.ToString().Contains(u.ToString()))
                    {
                        hasWeight = true;
                        break;
                    }
                }
                if (hasWeight)
                {
                    orderList += "<div style='display: flex;justify-content:space-between;padding:4px;margin-bottom:3px;font-size:8px;width:100%'>" + "<div><strong style='padding:4px;margin-bottom:5px'>" + item.Product.Name + "</strong></div>" + " <div><strong style = 'padding:4px;margin-bottom:5px'> " + item.Value +"x" +item.Product.Price+ "</strong></div>" + "</div>";
                }
                else
                {
                    orderList += "<div style='display: flex;justify-content:space-between;padding:4px;margin-bottom:3px;font-size:10px;width:100%'>" + "<div><strong style='padding:4px;margin-bottom:5px'>" + item.Product.Name + "</strong></div>" + " <div><strong style = 'padding:4px;margin-bottom:5px'> " + item.Quantity + "x" + item.Product.Price + "</strong></div>" + "</div>";
                }
            }
            orderList += "<div style='display: flex;justify-content:space-between;padding:4px;margin-bottom:3px;font-size:10px;width:100%'>" + "<div><strong style='padding:4px;margin-bottom:5px'>Shipping" +  "</strong></div>" + " <div><strong style = 'padding:4px;margin-bottom:5px'>2 JOD" + "</strong></div>" + "</div>";
            if (coupon != null)
                {
                orderList += "<div style='display: flex;justify-content:space-between;padding:4px;margin-bottom:3px;font-size:10px;width:100%'>" + "<div><strong style='padding:4px;margin-bottom:5px'>Discount" + "</strong></div>" + " <div><strong style = 'padding:4px;margin-bottom:5px'>" +coupon+ "%</strong></div>" + "</div>";

            }
            orderList += "</div><p>we will keep you updated with your <span style='color:#F28123'>order status</span</p></div>";
                EmailDto mail = new EmailDto();
                mail.Subject = "Order #"+orders.Select(x=>x.Id).ToList().Last();
                mail.To = email;
            mail.Body = "<div><img style='border-radius:10px;width:100%' src='https://drive.google.com/uc?export=view&id=1Ael2Wom3ss4n3SrIOZETBvMTlpMzDtgw'  height='200'/></div><h4 style='color:#FFF'>Thank you For Choosing <strong style='color:#F28123'>MEMall</strong></h4>" + orderList + "<div style='margin-top:20px;margin-bottom:20px'><strong>Total: " + tot + " JOD</strong></div><div style:width:100%;><div><img style='border-radius:10px;width:100%' src='https://drive.google.com/uc?export=view&id=1AcfjJK73sYVI04L6UwZA5lEehM9qQRjP'  height='250'/></div></div>";
            IEmailService emailService = new EmailService(_config);
                EmailController emailController = new EmailController(emailService);
                emailController.SendEmail(mail);
                HttpContext.Session.Remove("cart");

            return View();
            
        }
        [HttpPost]
        public IActionResult OrderSucceeded(string feedback)
        {

            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            Feedback feed = new Feedback();
            feed.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            feed.FeedbackText = feedback;
            feed.FeedbackStatus = 1;
            _context.Add(feed);
            _context.SaveChangesAsync();

            return RedirectToAction(nameof(OrderSucceeded));

        }


        //GET ALL PRODUCT
        public List<ProductSubCat> getAllProduct(int id)
        {
            var products = (from p in _context.Products
                           join ps in _context.ProductStore on p.Id equals ps.productId
                           join s in _context.Stores on ps.storeId equals s.Id
                           join sc in _context.SubCategories on p.CategoryId equals sc.Id
                           join u in _context.Units on p.UnitId equals u.Id
                            where s.Id == id
                           select new ProductSubCat { Product=p,ProductStore=ps,Store=s,SubCategory=sc,Unit=u}).ToList();
            return products;
        }

        //GET DETAIL PRODUCT
        public ProductSubCat getDetailProduct(int id)
        {
            var product = (from p in _context.Products
                           join ps in _context.ProductStore on p.Id equals ps.productId
                           join s in _context.Stores on ps.storeId equals s.Id
                           join sc in _context.SubCategories on p.CategoryId equals sc.Id
                           join u in _context.Units on p.UnitId equals u.Id
                           where p.Id == id
                           select new ProductSubCat { Product = p, ProductStore = ps, Store = s, SubCategory = sc,Unit=u }).SingleOrDefault();
            return product;
        }
        public IActionResult addCart(int id)
        {
            var cart = HttpContext.Session.GetString("cart");//get key cart
            if (cart == null)
            {
                var product = getDetailProduct(id);
                List<Cart> listCart = new List<Cart>()
               {
                   new Cart
                   {
                       Product = product.Product,
                       Quantity = 1,
                       Value =1
                   }
               };
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(listCart));
                string.Join(",", listCart.Select(v => v.Product.Id).ToList()); // insert in product string of ids in order table

            }
            else 
            { 
            List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
            bool check = true;
            bool hasWeight = false;
            List<string> units = new List<string>() { "Kg" };
            var uId = from u in _context.Units
                      select u;
            var uIds = uId.Where(x => units.Contains(x.UnitName)).ToList();
            var uIDs = uIds.Select(x => x.Id);
            for (int i = 0; i < dataCart.Count; i++)
            {

                if (dataCart[i].Product.Id == id)
                {
                    foreach (var u in uIDs)
                    {
                        if (dataCart[i].Product.UnitId.ToString().Contains(u.ToString()))
                        {
                            hasWeight = true;
                            break;
                        }
                    }

                    if (hasWeight)
                    {
                        dataCart[i].Quantity = 1;
                        dataCart[i].Value++;
                    }
                    else
                    {
                        dataCart[i].Quantity++;
                        dataCart[i].Value++;
                    }
                    check = false;
                    hasWeight = false;
                }
            }
            if (check)
            {
                var product = getDetailProduct(id).Product;
               
                    Cart cart1 = new Cart();
                    cart1.Product = product;
                    cart1.Quantity = 1;
                    cart1.Value = 1;
                    dataCart.Add(cart1);
            }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
            }
           var storeID= getDetailProduct(id).Store.Id;
           return RedirectToAction(nameof(Store), new {id=storeID});
        }
        [HttpPost]
        public IActionResult addCartWithQuantity(int id, decimal quantity)
        {

            List<string> units = new List<string>() { "Kg" };
            var uId = from u in _context.Units
                      select u;
            var uIds = uId.Where(x => units.Contains(x.UnitName)).ToList();
            var uIDs = uIds.Select(x => x.Id);
            var cart = HttpContext.Session.GetString("cart");//get key cart
            if (cart == null)
            {
                List<Cart> listCart = new List<Cart>();
                var product = getDetailProduct(id);
                bool hasWeight = false;
                foreach (var u in units)
                {
                    if (product.Unit.UnitName.Contains(u))
                    {
                        hasWeight = true;
                        break;
                    }
                }
                if (hasWeight)
                {
                    Cart cart1 = new Cart();
                    cart1.Product = product.Product;
                    cart1.Quantity = 1;
                    cart1.Value = quantity;
                    listCart.Add(cart1);
                }
                else
                {
                    Cart cart1 = new Cart();
                    cart1.Product = product.Product;
                    cart1.Quantity = (int)quantity;
                    cart1.Value = quantity;
                    listCart.Add(cart1);
                }

                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(listCart));

            }
            else
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                bool check = true;
                bool hasWeight = false;

                for (int i = 0; i < dataCart.Count; i++)
                {
                   
                    if (dataCart[i].Product.Id == id)
                    {
                        foreach (var u in uIDs)
                        {
                            if (dataCart[i].Product.UnitId.ToString().Contains(u.ToString()))
                            {
                                hasWeight = true;
                                break;
                            }
                        }

                        if (hasWeight)
                        {
                            dataCart[i].Quantity=1;
                            dataCart[i].Value += quantity;
                        }
                        else
                        {
                            dataCart[i].Quantity += (int)quantity;
                            dataCart[i].Value += quantity;
                        }
                        check = false;
                        hasWeight = false;
                    }
                }
                if (check)
                {
                    var product = getDetailProduct(id).Product;
                    foreach (var u in uIDs)
                    {
                        if (product.UnitId.ToString().Contains(u.ToString()))
                        {
                            hasWeight = true;
                            break;
                        }
                    }
                    if (hasWeight)
                    {
                        Cart cart1 = new Cart();
                        cart1.Product = product;
                        cart1.Quantity = 1;
                        cart1.Value = quantity;
                        dataCart.Add(cart1);
                    }
                    else
                    {
                        Cart cart1 = new Cart();
                        cart1.Product = product;
                        cart1.Quantity = (int)quantity;
                        cart1.Value = quantity;
                        dataCart.Add(cart1);
                    }
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                // var cart2 = HttpContext.Session.GetString("cart");//get key cart
                //  return Json(cart2);
            }
            var storeID = getDetailProduct(id).Store.Id;

            return RedirectToAction(nameof(Store), new { id = storeID });
        }

        [HttpPost]
        public IActionResult updateCart(int id, decimal quantity)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                List<string> units = new List<string>() { "Kg" };
                var uId = from u in _context.Units
                          select u;
                var uIds = uId.Where(x => units.Contains(x.UnitName)).ToList();
                var uIDs = uIds.Select(x => x.Id);
                if (quantity > 0)
                {
                    bool hasWeight = false;
                    for (int i = 0; i < dataCart.Count; i++)
                    {
                        if (dataCart[i].Product.Id == id)
                        {
                            var product = getDetailProduct(id).Product;
                            foreach (var u in uIDs)
                            {
                                if (product.UnitId.ToString().Contains(u.ToString()))
                                {
                                    hasWeight = true;
                                    break;
                                }
                            }
                            if (hasWeight)
                            {
                                dataCart[i].Value = quantity;

                            }
                            else
                            {
                                dataCart[i].Quantity = (int)quantity;
                                dataCart[i].Value = quantity;

                            }
                            hasWeight = false;
                        }
                    }


                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                }
                var cart2 = HttpContext.Session.GetString("cart");
                return RedirectToAction(nameof(Cart));
            }
            return BadRequest();

        }
        public IActionResult deleteCart(int id)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);

                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Product.Id == id)
                    {
                        dataCart.RemoveAt(i);
                    }
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                return RedirectToAction(nameof(Cart));
            }
            return RedirectToAction(nameof(Cart));
        }

        public IActionResult incrementByOne(int id)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                {
                    for (int i = 0; i < dataCart.Count; i++)
                    {
                        if (dataCart[i].Product.Id == id)
                        {
                            dataCart[i].Quantity += 1;
                        }
                    }

                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                    return RedirectToAction(nameof(Cart));
                }
            }
            return RedirectToAction(nameof(Cart));
        }

        public IActionResult decrementByOne(int id)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                {
                    for (int i = 0; i < dataCart.Count; i++)
                    {
                        if (dataCart[i].Product.Id == id)
                        {
                            if (dataCart[i].Quantity == 1)
                            {
                                dataCart.RemoveAt(i);
                            }
                            else if(dataCart[i].Quantity > 1)
                            {
                                dataCart[i].Quantity -= 1;
                            }
                            break;
                        }
                    }

                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                    return RedirectToAction(nameof(Cart));
                }
            }
            return RedirectToAction(nameof(Cart));
        }

        public IActionResult ApplyCoupon(string Coupon)
        {
            var cart = HttpContext.Session.GetString("cart");
            var coupon = (from c in _context.Coupons
                         where c.CouponCode == Coupon
                         select c).ToList().SingleOrDefault();
            ViewBag.CouponCode = Coupon;
            HttpContext.Session.SetString("CouponCode", Coupon);
            if (coupon != null && coupon.IsActive==1 && coupon.ExpiryDate >= DateTime.Now)
            {
                HttpContext.Session.SetInt32("Coupon", coupon.DiscountValue);
                ViewBag.Coupon = HttpContext.Session.GetInt32("Coupon");

                return RedirectToAction(nameof(Cart));
            }
            if (coupon == null)
            {
                 //HttpContext.Session.SetString("Message", "The coupon is not available");
                ViewBag.Message = "The coupon is not available";


            }
            else if(coupon.ExpiryDate < DateTime.Now)
            {
                //HttpContext.Session.SetString("Message", "The coupon date has expired");
                ViewBag.Message = "The coupon date has expired";
            }
            return RedirectToAction(nameof(Cart));

        }

    }
}
