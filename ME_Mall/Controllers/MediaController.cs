using ME_Mall.Data;
using ME_Mall.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ME_Mall.Controllers
{
    [Authorize(Roles = "Content Writer")]
    public class MediaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public MediaController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager,
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
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();

            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
         
            ViewBag.articles = (from a in _context.NewsAndArticles
                                where a.WriterId == User.FindFirst(ClaimTypes.NameIdentifier).Value
                                select a).Count();
            var art= (from a in _context.NewsAndArticles
                            where a.WriterId == User.FindFirst(ClaimTypes.NameIdentifier).Value
                            select a.Text).ToList();
            var word = 0;
            var letters = 0;
            List<string[]> words = new List<string[]>();
            art.ForEach(x => words.Add((x.Split(' ','\n','\r'))));
            foreach(var item in words)
            {
                foreach (var i in item)
                {
                    if (!String.IsNullOrEmpty(i))
                    {
                        word += 1;
                    }
                    letters += i.Length;
                }
            }
            ViewBag.words = word;
            //art.ForEach(x => letters += (x.Split(' ')).Length);
            ViewBag.letters = letters;
            var articles = (from a in _context.NewsAndArticles
                            where a.WriterId == User.FindFirst(ClaimTypes.NameIdentifier).Value
                            select a).OrderByDescending(x=>x.PostDate).Take(6).ToList();
            return View(articles);
        }
        public class OrderStatisticsData
        {
            public string labels { get; set; }
            public decimal data { get; set; }
        }

        public IActionResult Articles()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();

            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;

            var newsArticles = (from na in _context.NewsAndArticles
                                select na).ToList();
            return View(newsArticles);
        }
        
        public IActionResult WriteArticle()
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;
            ViewBag.month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> WriteArticle([Bind("Id,Title,Text,PostDate,WriterId,PostImg,ImageFile")] NewsAndArticles newsAndArticles)
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
                if (newsAndArticles.ImageFile != null)
                {
                    string wwwrootPath = _WebHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + newsAndArticles.ImageFile.FileName;
                    string path = Path.Combine(wwwrootPath + "/Images/Articles/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await newsAndArticles.ImageFile.CopyToAsync(fileStream);
                    }

                    newsAndArticles.PostImg = fileName;
                }
                newsAndArticles.PostDate = DateTime.Now;
                newsAndArticles.WriterId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _context.Add(newsAndArticles);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Articles));
            }
            return View(newsAndArticles);
        }
        
        public async Task<IActionResult> EditArticle(int? id)
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

            var article = await _context.NewsAndArticles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewBag.pic = article.PostImg;
            ViewBag.articleTitle = article.Title;
            ViewBag.text = article.Text;
            ViewBag.month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(article.PostDate.Month);
            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditArticle(int id, [Bind("Id,Title,Text,PostDate,WriterId,PostImg,ImageFile")] NewsAndArticles newsAndArticles)
        {
            var user = (from u in _context.User
                        where u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select u).ToList();
            var fullName = user.Select(x => x.FirstName).First() + " " + user.Select(x => x.LastName).First();
            ViewBag.fullname = fullName;
            var profileImage = user.Select(x => x.ProfilePath).First();
            ViewBag.profileImage = profileImage;

            if (id != newsAndArticles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (newsAndArticles.ImageFile != null)
                    {
                        string wwwrootPath = _WebHostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + newsAndArticles.ImageFile.FileName;
                        string path = Path.Combine(wwwrootPath + "/Images/Articles/" + fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await newsAndArticles.ImageFile.CopyToAsync(fileStream);
                        }

                        newsAndArticles.PostImg = fileName;
                    }
                    newsAndArticles.WriterId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                    _context.Update(newsAndArticles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(newsAndArticles.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Articles));
            }
            return View(newsAndArticles);
        }
        
        public async Task<IActionResult> ArticlePreview(int? id)
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

            var article = await _context.NewsAndArticles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewBag.month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(article.PostDate.Month);
            return View(article);
        }

        private bool ArticleExists(int id)
        {
            return _context.NewsAndArticles.Any(e => e.Id == id);
        }

        #region Content Writer Dashboard
        #region TotalRevenueChart
        [HttpGet]
        public JsonResult TotalArticlesChart()
        {
            FinalResult finalResult = new FinalResult();

            List<TotalArticlesChartData> result = new List<TotalArticlesChartData>();
            List<string> categories = new List<string>();

            var articles = (from a in _context.NewsAndArticles
                            where a.WriterId == User.FindFirst(ClaimTypes.NameIdentifier).Value
                            select a ).ToList();

            articles.Select(c => c.PostDate.Year).Distinct().ToList().ForEach(y =>
            {
                TotalArticlesChartData ele = new TotalArticlesChartData();
                ele.name = y.ToString();

                List<int> monthsPerYear = articles.Where(c => c.PostDate.Year == y).Select(d => d.PostDate.Month).Distinct().ToList();
                monthsPerYear.ForEach(m =>
                {
                    decimal sum = articles.Where(x => x.PostDate.Month == m && x.PostDate.Year == y).Count();
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
                oData = new List<TotalArticlesChartData>();
                oCategories = new List<string>();
            }
            public List<TotalArticlesChartData> oData { get; set; }
            public List<string> oCategories { get; set; }
        }
        public class TotalArticlesChartData
        {
            public TotalArticlesChartData()
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
