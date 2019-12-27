using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public const int RecordsPerPage = 10;

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
                HeadlineViewModel projects = GetData(pageNum.Value, newsSource);
                ViewBag.IsEndOfRecords = (projects.NewsHeadlines.Any());
                return PartialView("_ProjectData", projects);
            }
            else
            {
                if (newsSource == null)
                {
                    ViewBag.Projects = GetData(pageNum.Value);

                    return View("Index");
                }else
                {
                    ViewBag.Projects = GetData(pageNum.Value, newsSource);

                    return View("Index");
                }   
            }
        }

        public HeadlineViewModel GetData(int pageNum, string newsSource=null)
        {
            NewsDBDataContext dc = new NewsDBDataContext();
            var headlinesObj = new HeadlineViewModel();
            
            int from = (pageNum * RecordsPerPage);

            
            if (newsSource != null)
            {
                List<NewsEntry> catObj = (from x in dc.NewsEntries where x.NewsSource == newsSource select x).OrderByDescending(e => e.TimeAdded).Skip(from).Take(10).ToList();
                headlinesObj.NewsHeadlines = catObj;
                return headlinesObj;
            }
            else
            {
                List<NewsEntry> Obj = (from e in dc.NewsEntries select e).OrderByDescending(e => e.TimeAdded).Skip(from).Take(10).ToList();
                headlinesObj.NewsHeadlines = Obj;
                return headlinesObj;
            }  
        }

        public ActionResult Details(int Id)
        {
            NewsDBDataContext dc = new NewsDBDataContext();
            var Obj = new HeadlineViewModel();

            List<NewsEntry> dbEntry = (from e in dc.NewsEntries where e.id == Id select e).ToList();
            Obj.NewsHeadlines = dbEntry;
            
            

            return PartialView("_ModalView", Obj);
        }

        //[Route("About")]
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}