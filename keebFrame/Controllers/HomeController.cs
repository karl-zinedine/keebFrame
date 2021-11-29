using keebFrame.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace keebFrame.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly keebFrameContext _context;

        public HomeController(keebFrameContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Posts.ToListAsync();

            Posts post = new Posts
            {
                PId = data.First().PId,
            };

            ViewBag.Message = post;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<String> GetPosts()
        {
            //var data = await _context.Posts.FirstOrDefaultAsync();
            var data = await _context.Posts.ToListAsync();

            List<Posts> allPosts = data;
            //return Json(new { data = data }, System.Web.Mvc.JsonRequestBehavior.AllowGet);
            return JsonConvert.SerializeObject(data);
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
