using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Comment
    {
        public Comment()
        {

        }

        public Comment(string authorId, string content, int articleId)
        {
            this.AuthorId = authorId;
            this.Content = content;
            this.ArticleId = articleId;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Content { get; set; }
       
        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

    }
}