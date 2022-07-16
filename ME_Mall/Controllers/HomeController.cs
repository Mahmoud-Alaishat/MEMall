using ME_Mall.Data;
using ME_Mall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ME_Mall.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
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
                var design = (from s in _context.Design
                              where s.Id.StartsWith("Slider")
                              select s).ToList().LastOrDefault();
                ViewBag.slide1 = design.SlideImage1;
                ViewBag.slide2 = design.SlideImage2;
                ViewBag.slide3 = design.SlideImage3;
                ViewBag.main1 = design.MainText1;
                ViewBag.main2 = design.MainText2;
                ViewBag.main3 = design.MainText3;
                ViewBag.sub1 = design.SubText1;
                ViewBag.sub2 = design.SubText2;
                ViewBag.sub3 = design.SubText3;
                var feedback = (from f in _context.Feedback
                                join u in _context.User on f.UserId equals u.Id
                                join s in _context.Status on f.FeedbackStatus equals s.Id
                                where f.FeedbackStatus == 2
                                select new FeedbackUser { Feedback = f, User = u, Status = s }).ToList();
                ViewBag.feedCount = feedback.Count();
                var ad = (from s in _context.Design
                          where s.Id.StartsWith("Ad")
                          select s).ToList().LastOrDefault();
                ViewBag.show = true;
                if (ad != null)
                {
                    ViewBag.adImg = ad.SlideImage1;
                    ViewBag.text1 = ad.SubText1;
                    ViewBag.text2 = ad.MainText1;
                    ViewBag.orangeText = ad.SubText2;
                    ViewBag.discount = ad.MainText2;
                }
                else
                {
                    ViewBag.show = false;
                }
                var articles = (from a in _context.NewsAndArticles
                                join u in _context.User on a.WriterId equals u.Id
                                select new ArticleUser { NewsAndArticles = a, User = u }).OrderByDescending(x => x.NewsAndArticles.PostDate).ToList().Take(3);
                ViewBag.artCount = articles.Count();
                var feedArt = Tuple.Create<List<FeedbackUser>, IEnumerable<ArticleUser>>(feedback, articles);
                return View(feedArt);
            }
            catch
            {
                var design = (from s in _context.Design
                              where s.Id.StartsWith("Slider")
                              select s).ToList().LastOrDefault();
                ViewBag.slide1 = design.SlideImage1;
                ViewBag.slide2 = design.SlideImage2;
                ViewBag.slide3 = design.SlideImage3;
                ViewBag.main1 = design.MainText1;
                ViewBag.main2 = design.MainText2;
                ViewBag.main3 = design.MainText3;
                ViewBag.sub1 = design.SubText1;
                ViewBag.sub2 = design.SubText2;
                ViewBag.sub3 = design.SubText3;
                var feedback = (from f in _context.Feedback
                                join u in _context.User on f.UserId equals u.Id
                                join s in _context.Status on f.FeedbackStatus equals s.Id
                                where f.FeedbackStatus == 2
                                select new FeedbackUser { Feedback = f, User = u, Status = s }).ToList();
                ViewBag.feedCount = feedback.Count();
                var ad = (from s in _context.Design
                          where s.Id.StartsWith("Ad")
                          select s).ToList().LastOrDefault();
                ViewBag.show = true;
                if (ad != null)
                {
                    ViewBag.adImg = ad.SlideImage1;
                    ViewBag.text1 = ad.SubText1;
                    ViewBag.text2 = ad.MainText1;
                    ViewBag.orangeText = ad.SubText2;
                    ViewBag.discount = ad.MainText2;
                }
                else
                {
                    ViewBag.show = false;
                }
                var articles = (from a in _context.NewsAndArticles
                                join u in _context.User on a.WriterId equals u.Id
                                select new ArticleUser {NewsAndArticles=a,User=u }).OrderByDescending(x => x.NewsAndArticles.PostDate).ToList().Take(3);
                ViewBag.artCount = articles.Count();
                var feedArt = Tuple.Create<List<FeedbackUser>, IEnumerable<ArticleUser>>(feedback, articles);
                return View(feedArt);
            }

        }

        public IActionResult About()
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
                var feedback = (from f in _context.Feedback
                                join u in _context.User on f.UserId equals u.Id
                                join s in _context.Status on f.FeedbackStatus equals s.Id
                                where f.FeedbackStatus == 2
                                select new FeedbackUser { Feedback = f, User = u, Status = s }).ToList();
                ViewBag.feedCount = feedback.Count();
                var ad = (from s in _context.Design
                          where s.Id.StartsWith("Ad")
                          select s).ToList().LastOrDefault();
                ViewBag.show = true;
                if (ad != null)
                {
                    ViewBag.adImg = ad.SlideImage1;
                    ViewBag.text1 = ad.SubText1;
                    ViewBag.text2 = ad.MainText1;
                    ViewBag.orangeText = ad.SubText2;
                    ViewBag.discount = ad.MainText2;
                }
                else
                {
                    ViewBag.show = false;
                }
                return View(feedback);
            }
            catch
            {
                var feedback = (from f in _context.Feedback
                                join u in _context.User on f.UserId equals u.Id
                                join s in _context.Status on f.FeedbackStatus equals s.Id
                                where f.FeedbackStatus == 2
                                select new FeedbackUser { Feedback = f, User = u, Status = s }).ToList();
                ViewBag.feedCount = feedback.Count();
                var ad = (from s in _context.Design
                          where s.Id.StartsWith("Ad")
                          select s).ToList().LastOrDefault();
                ViewBag.show = true;
                if (ad != null)
                {
                    ViewBag.adImg = ad.SlideImage1;
                    ViewBag.text1 = ad.SubText1;
                    ViewBag.text2 = ad.MainText1;
                    ViewBag.orangeText = ad.SubText2;
                    ViewBag.discount = ad.MainText2;
                }
                else
                {
                    ViewBag.show = false;
                }
                return View(feedback);

            }
        }
        public IActionResult News()
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
                return View();
            }
            catch
            {
                return View();

            }
        }
        public IActionResult ContactUs()
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
                return View();
            }
            catch
            {
                return View();
            }
        }
        

        public IActionResult Error(int code)
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
                ViewData["ErrorMessage"] = $"Error occurred. The ErrorCode is: {code}";
                return View("~/Views/Shared/Error.cshtml");
            }
            catch
            {
                ViewData["ErrorMessage"] = $"Error occurred. The ErrorCode is: {code}";
                return View("~/Views/Shared/Error.cshtml");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessageContactUs([Bind("Id,Name,Email,Phone,Subject,Message,Date,ShowHide")] ContactUs contactUs)
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
                contactUs.Date = DateTime.Now;
                _context.Add(contactUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ContactUs));
            }
            catch
            {
                contactUs.Date = DateTime.Now;
                _context.Add(contactUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ContactUs));
            }
        }

    }
}
