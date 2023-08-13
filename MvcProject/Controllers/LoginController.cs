using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AuthorLoginManager authorLoginManager = new AuthorLoginManager(new EfAuthorDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Context context = new Context();
            var adminUserInfo = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName &&
            x.AdminPassword == admin.AdminPassword);

            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AuthorLogin(Author author)
        {
            //Context context = new Context();
            //var authorUserInfo = context.Authors.FirstOrDefault(x => x.AuthorMail == author.AuthorMail &&
            //x.AuthorPassword == author.AuthorPassword);

            var authorUserInfo = authorLoginManager.GetAuthor(author.AuthorMail, author.AuthorPassword);

            if (authorUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(authorUserInfo.AuthorMail, false);
                Session["AuthorMail"] = authorUserInfo.AuthorMail;
                return RedirectToAction("MyContent", "AuthorPanelContent");
            }
            else
            {
                return RedirectToAction("AuthorLogin");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}