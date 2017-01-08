using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class CommentController : Controller
    {
       

        [Authorize]
        public ActionResult Create()
        {
            using (var database = new BlogDbContext())
            {
                var model = new ArticleViewModel();
                 model.Comments = database.Comments                    
                    .ToList();
                return View(model);
            }
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var database = new BlogDbContext())
                {
                    var authorId = database.Users
                        .Where(a => a.UserName == this.User.Identity.Name)
                        .First()
                        .Id;
                    var comment = new Comment(authorId, model.Content, model.CommentId);

                    

                    comment.AuthorId = authorId;

                    database.Comments.Add(comment);
                    database.SaveChanges();


                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}