using Blog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.UI.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            TempData["class"] = "custom-hide";
            var model = service.ArticleService.GetActive().OrderByDescending(x => x.AddDate).Take(5);

            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View(model);
            }
           
            AppUser user = new AppUser();
            user = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name);
            if (user.Role==DAL.ORM.Enum.Role.Admin)
            {
                TempData["class"] = "custom-show";
            }
            return View(model);
        }
    }
}