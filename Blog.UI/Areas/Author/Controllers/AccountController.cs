using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.UI.Areas.Author.Controllers
{
    public class AccountController : Controller
    {
        // GET: Author/Account

        public ActionResult Index()
        {
            return View();
        }
    }
}