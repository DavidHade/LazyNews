using LazyNews.Core.Contracts;
using LazyNews.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        IRepository<NewsEntry> context;

        public AdminController(IRepository<NewsEntry> newsContext)
        {
            context = newsContext;
        }



        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<NewsEntry> model = context.Collection().OrderByDescending(e => e.TimeAdded).Take(10).ToList();

            return View(model);
        }
    }
}