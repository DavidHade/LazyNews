using LazyNews.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LazyNews.Core.Contracts;
using LazyNews.DataAccess.SQL;
using LazyNews.Core.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public const int RecordsPerPage = 10;

        IRepository<NewsEntry> context = new SQLRepository<LazyNews.Core.Models.NewsEntry>(new DataContext());

        // TODO - Fix zero parameter constructor error
        //public HomeController(IRepository<LazyNews.Core.Models.NewsEntry> newsContext)
        //{
        //    context = newsContext;
        //}

        public HomeController()
        {
            ViewBag.RecordsPerPage = RecordsPerPage;
        }


        public ActionResult Index(string newsSource = null)
        {
            return RedirectToAction("ShowData");
        }

        [Route("")]
        public ActionResult ShowData(int? pageNum, string newsSource=null)
        {
            pageNum = pageNum ?? 0;
            ViewBag.IsEndOfRecords = false;
            if (Request.IsAjaxRequest())
            {
                //HeadlineViewModel projects = GetData(pageNum.Value, newsSource);
                HeadlineViewModel model = GetData(pageNum.Value, newsSource);
                //ViewBag.IsEndOfRecords = (projects.NewsHeadlines.Any());
                ViewBag.isEndOfRecords = (model.NewsHeadlines.Any());
                //return PartialView("_ProjectData", projects);
                return PartialView("_ProjectData", model);
            }
            else
            {
                if (newsSource == null)
                {
                    ViewBag.models = GetData(pageNum.Value);

                    return View("Index", ViewBag.models);
                }else
                {
                    ViewBag.models = GetData(pageNum.Value, newsSource);

                    return View("Index", ViewBag.models);
                }   
            }
        }

        public HeadlineViewModel GetData(int pageNum, string newsSource=null)
        {
            //NewsDBDataContext dc = new NewsDBDataContext();
            var headlinesObj = new HeadlineViewModel();
            
            int from = (pageNum * RecordsPerPage);

            
            if (newsSource != null)
            {
                //List<LazyNews.Core.Models.NewsEntry> catObj = (from x in dc.NewsEntries where x.NewsSource == newsSource select x).OrderByDescending(e => e.TimeAdded).Skip(from).Take(10).ToList();
                //List<NewsEntry> catObj = context.FindHeadlines(newsSource).OrderByDescending(e => e.TimeAdded).Skip(from).Take(10).ToList();
                List<NewsEntry> catObj = context.FindHeadlines(newsSource).OrderByDescending(e => e.TimeAdded).Skip(from).Take(10).ToList();
                headlinesObj.NewsHeadlines = catObj;
                return headlinesObj;
            }
            else
            {
                List<NewsEntry> Obj = context.Collection().OrderByDescending(e => e.TimeAdded).Skip(from).Take(10).ToList();
                headlinesObj.NewsHeadlines = Obj;
                return headlinesObj;
            }  
        }

        public ActionResult Details(int Id)
        {
            NewsEntry dbEntry = new LazyNews.Core.Models.NewsEntry();
            dbEntry = context.Find(Id);

            return PartialView("_ModalView", dbEntry);
        }

        //[Route("About")]
        public ActionResult About()
        {
            //return View();
            // Redirect to main page instead
            return RedirectToAction("ShowData");
        }
        public ActionResult Contact()
        {
            //return View(); 
            // Redirect to main page instead
            return RedirectToAction("ShowData");
        }
    }
}