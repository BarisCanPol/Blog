using Blog.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.UI.Areas.Author.Controllers
{
    public class BaseController : Controller
    {
        // GET: Author/Base
        protected EntityService service = new EntityService();
    }
}