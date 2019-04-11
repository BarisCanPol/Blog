using Blog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.UI.Areas.Author.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Author/Home
        public ActionResult Index()
        {
            TempData["class"] = "custom-hide";

            var model = service.ArticleService.GetActive().OrderBy(x => x.PublishDate).Take(5);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View(model);
            }

            AppUser user = new AppUser();
            user = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name);
            if (user.Role == Blog.DAL.ORM.Enum.Role.Author)
            {
                TempData["class"] = "custom-show";

            }
            return View(model);
    }
}