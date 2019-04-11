using Blog.DAL.ORM.Entity;
using Blog.UI.Areas.Author.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.UI.Areas.Author.Controllers
{
    public class ArticleController : BaseController
    {
        private object comment;
                
        public ActionResult Add()
        {
            return View(service.CategoryService.GetActive());
        }
        public ActionResult Add(Article data)   //modelstate is valid nedir ?
        {
            data.AppUserID = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name).ID;
            data.AddDate = DateTime.Now;
            data.PublishDate = DateTime.Now;

            service.ArticleService.Add(data);
            return View("/home/index");
        }

        public ActionResult Show(Guid id)
        {
            ArticleCommentVM model = new ArticleCommentVM();
            model.Article = service.ArticleService.GetById(id);
            model.Comments = service.CommentService.GetDefault(x => x.ArticleID == id).OrderByDescending(x => x.AddDate).Take(10);
            model.Likes = service.LikeService.GetDefault(z => z.ArticleID == id).Count();
            return View(model);

        }

        public ActionResult AddComment(CommentVM data)
        {
            Comment comment = new Comment();
            comment.AppUserID = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name).ID;
            comment.ArticleID = data.ID;
            comment.Content = data.Content;
            comment.AddDate = DateTime.Now;
            service.CommentService.Add(comment);
            return Redirect("/Article/Show/" + data.ID);

        }
        public JsonResult AddLike(Guid id)
        {
            JsonLikeVM jt = new JsonLikeVM();
            Guid appUSerID = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name).ID;

            if (!(service.LikeService.Any(x=> x.AppUserID==appUSerID && x.ArticleID==id)
            {
                Like like = new Like();
                like.ArticleID = id;
                like.AppUserID = appUSerID;
                service.LikeService.Add(like);

                jt.Likes = service.LikeService.GetDefault(x => x.ArticleID == id).Count();
                jt.UserMessage = "Bu yazıyı daha önce beğendiniz";
                jt.Likes = service.LikeService.GetDefault(x => x.ArticleID == id).Count();
                return Json(jt, JsonRequestBehavior.AllowGet);
            }
        }
 
    }
}