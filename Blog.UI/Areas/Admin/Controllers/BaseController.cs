using Blog.BLL.Service;
using Blog.DAL.ORM.Context;
using Blog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.UI.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected EntityService service;
        public BaseController()
        {
            service = new EntityService();
        }
       

       
    }
}