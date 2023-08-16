using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p)
        {
            var values = contentManager.GetContentList(p);
            return View(values);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.GetContentListByHeadingId(id);
            return View(contentValues);
        }
    }
}