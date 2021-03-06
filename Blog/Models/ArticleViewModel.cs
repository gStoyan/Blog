﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Models
{
    public class ArticleViewModel : Controller
    {
      

        public int Id { get; set; }

        public string  Tags { get; set; }

        [ForeignKey("Comment")]
        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public new string Content { get; set; }

        public string AuthorId { get; set; }
        public List<Category> Categories { get; internal set; }
        public List<Comment> Comments { get; internal set; }
    }
}