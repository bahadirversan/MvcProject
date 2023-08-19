using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        AuthorManager authorManager = new AuthorManager(new EfAuthorDal());

        public ActionResult Index()
        {
            var headingValues = headingManager.GetHeadingList();
            return View(headingValues);
        }

        public ActionResult HeadingReport()
        {
            var headingValues = headingManager.GetHeadingList();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            List<SelectListItem> valueAuthor = (from x in authorManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.AuthorName + " " + x.AuthorSurname,
                                                    Value = x.AuthorId.ToString()
                                                }).ToList();
            ViewBag.valueCategory = valueCategory;
            ViewBag.valueAuthor = valueAuthor;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingCreationDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.AddHeading(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            ViewBag.valueCategory = valueCategory;
            var headingValue = headingManager.GetById(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.UpdateHeading(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetById(id);
            headingValue.HeadingStatus = false;
            headingManager.DeleteHeading(headingValue);
            return RedirectToAction("Index");
        }
    }
}