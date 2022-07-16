using ME_Mall.Data;
using ME_Mall.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ME_Mall.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsController( ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(int? page)
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
                var article = (from a in _context.NewsAndArticles
                               join u in _context.User on a.WriterId equals u.Id
                               select new ArticleUser { NewsAndArticles = a, User = u }).OrderByDescending(x => x.NewsAndArticles.PostDate).ToList();
                var pager = new Pager(article.Count(), page);

                var viewModel = new IndexViewModel<ArticleUser>
                {
                    Items = article.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                    Pager = pager
                };
                return View(viewModel);
            }
            catch
            {
                var article = (from a in _context.NewsAndArticles
                               join u in _context.User on a.WriterId equals u.Id
                               select new ArticleUser { NewsAndArticles = a, User = u }).OrderByDescending(x=>x.NewsAndArticles.PostDate).ToList();
                var pager = new Pager(article.Count(), page);

                var viewModel = new IndexViewModel<ArticleUser>
                {
                    Items = article.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                    Pager = pager
                };
                return View(viewModel);
            }
        }
        public async Task<IActionResult> Article(int? id)
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

                if (id == null)
                {
                    return NotFound();
                }
                var article = (from a in _context.NewsAndArticles
                                join u in _context.User on a.WriterId equals u.Id
                                where a.Id == id
                                select new ArticleUser { NewsAndArticles = a, User = u }).ToList().SingleOrDefault();
                if (article == null)
                {
                    return NotFound();
                }
                ViewBag.month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(article.NewsAndArticles.PostDate.Month);
                var articles = (from a in _context.NewsAndArticles
                               join u in _context.User on a.WriterId equals u.Id
                               where a.Id != id
                               select a ).OrderByDescending(x=>x.PostDate).Take(5).ToList();
                var result = Tuple.Create<ArticleUser, List<NewsAndArticles>>(article, articles);
                return View(result);
            }
            catch
            {
                if (id == null)
                {
                    return NotFound();
                }
                var article = (from a in _context.NewsAndArticles
                               join u in _context.User on a.WriterId equals u.Id
                               where a.Id == id
                               select new ArticleUser { NewsAndArticles = a, User = u }).ToList().SingleOrDefault();
                if (article == null)
                {
                    return NotFound();
                }
                ViewBag.month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(article.NewsAndArticles.PostDate.Month);
                var articles = (from a in _context.NewsAndArticles
                                join u in _context.User on a.WriterId equals u.Id
                                where a.Id != id
                                select a).OrderByDescending(x => x.PostDate).Take(5).ToList();
                var result = Tuple.Create<ArticleUser, List<NewsAndArticles>>(article, articles);
                return View(result);
            }
        }
        
    }
}
