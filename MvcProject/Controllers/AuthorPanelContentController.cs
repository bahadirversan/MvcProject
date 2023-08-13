using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class AuthorPanelContentController : Controller
    {
        // GET: AuthorPanelContent
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();

        public ActionResult MyContent(string p)
        {           
            p = (string)Session["AuthorMail"];
            var authorIdInfo = context.Authors.Where(x => x.AuthorMail == p).Select(y => y.AuthorId).FirstOrDefault();
            var contentValues = contentManager.GetContentListByAuthor(authorIdInfo);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["AuthorMail"];
            var authorIdInfo = context.Authors.Where(x => x.AuthorMail == mail).Select(y => y.AuthorId).FirstOrDefault();
            content.ContentCreationDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.AuthorId = authorIdInfo;
            content.ContentStatus = true;
            contentManager.AddContent(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}