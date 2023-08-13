using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using Business.ValidationRules.FluentValidation;

namespace MvcProject.Controllers
{
    public class AuthorPanelController : Controller
    {
        // GET: AuthorPanel
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        AuthorManager authorManager = new AuthorManager(new EfAuthorDal());
        Context context = new Context();

        [HttpGet]
        public ActionResult AuthorProfile(int id = 0)
        {
            string p = (string)Session["AuthorMail"];
            id = context.Authors.Where(x => x.AuthorMail == p).Select(y => y.AuthorId).FirstOrDefault();
            var authorValue = authorManager.GetById(id);
            return View(authorValue);
        }

        [HttpPost]
        public ActionResult AuthorProfile(Author author)
        {
            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult results = authorValidator.Validate(author);
            if (results.IsValid)
            {
                authorManager.UpdateAuthor(author);
                return RedirectToAction("AllHeading", "AuthorPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult MyHeading(string p)
        {            
            p = (string)Session["AuthorMail"];
            var authorIdInfo = context.Authors.Where(x => x.AuthorMail == p).Select(y => y.AuthorId).FirstOrDefault();
            var headingValues = headingManager.GetHeadingListByAuthorId(authorIdInfo);
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {            
            List<SelectListItem> valueCategory = (from x in categoryManager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            ViewBag.valueCategory = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string authorMailInfo = (string)Session["AuthorMail"];
            var authorIdInfo = context.Authors.Where(x => x.AuthorMail == authorMailInfo).Select(y => y.AuthorId).FirstOrDefault();
            heading.HeadingCreationDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.AuthorId = authorIdInfo;
            heading.HeadingStatus = true;
            headingManager.AddHeading(heading);
            return RedirectToAction("MyHeading");
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
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetById(id);
            headingValue.HeadingStatus = false;
            headingManager.DeleteHeading(headingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int p = 1)
        {
            var headings = headingManager.GetHeadingList().ToPagedList(p, 4);
            return View(headings);
        }
    }
}

/*     <customErrors mode="On">
      <error statusCode="404" redirect="/ErrorPage/Page404/"/>
    </customErrors> 
*/