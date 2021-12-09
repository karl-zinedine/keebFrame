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
using Microsoft.IdentityModel.Protocols;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

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
        private SqlConnection con;

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

        //Post method to add details    
        [HttpPost]
        public ActionResult AddPosts(Posts obj)
        {
            AddPostDetails(obj);
            return View();
        }

        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
            con = new SqlConnection(constr);

        }
        //To add Records into database     
        private void AddPostDetails(Posts obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddPost", con); //TODO: replace AddEmp with actual stored procedure name
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Title", obj.PTitle);
            com.Parameters.AddWithValue("@Question", obj.PQuestion);
            com.Parameters.AddWithValue("@Answer", obj.PAnswer);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
    }
}
