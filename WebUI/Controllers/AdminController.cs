using LazyNews.Core.Contracts;
using LazyNews.Core.Models;
using LazyNews.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public const int RecordsPerPage = 10;

        IRepository<NewsEntry> context;

        public AdminController(IRepository<NewsEntry> newsContext)
        {
            context = newsContext;
        }



        public ActionResult Index(string newsSource = null)
        {
            return RedirectToAction("ShowData");
        }

        [Route("Admin")]
        public ActionResult ShowData(int? pageNum, string newsSource = null)
        {
            pageNum = pageNum ?? 0;
            ViewBag.IsEndOfRecords = false;
            if (Request.IsAjaxRequest())
            {

                HeadlineViewModel model = GetData(pageNum.Value, newsSource);

                ViewBag.isEndOfRecords = (model.NewsHeadlines.Any());

                return PartialView("_AdminData", model);
            }
            else
            {
                if (newsSource == null)
                {
                    ViewBag.models = GetData(pageNum.Value);

                    return View("Index", ViewBag.models);
                }
                else
                {
                    ViewBag.models = GetData(pageNum.Value, newsSource);

                    return View("Index", ViewBag.models);
                }
            }
        }

        public HeadlineViewModel GetData(int pageNum, string newsSource = null)
        {

            var headlinesObj = new HeadlineViewModel();

            int from = (pageNum * RecordsPerPage);


            if (newsSource != null)
            {

                List<NewsEntry> catObj = context.FindBySource(newsSource).OrderByDescending(e => e.TimeAdded).Skip(from).Take(10).ToList();
                headlinesObj.NewsHeadlines = catObj;
                return headlinesObj;
            }
            else
            {
                List<NewsEntry> Obj = context.Collection().Where(x => x.Category == null && x.Article != "").OrderByDescending(e => e.TimeAdded).Skip(from).Take(10).ToList();
                headlinesObj.NewsHeadlines = Obj;
                return headlinesObj;
            }
        }

        public ActionResult Details(int Id)
        {
            NewsEntry dbEntry = new NewsEntry();
            dbEntry = context.Find(Id);

            return PartialView("_ModalView", dbEntry);
        }

        public string Categorize(string category, int id)
        {
            var output = context.Find(id);

            output.Category = category;

            try
            {
                context.Update(output);
                context.Commit();
                return output.Headline;
            }
            catch (Exception ex)
            {
                return $"Error - {ex.ToString()}";
            }
        }
    }
}