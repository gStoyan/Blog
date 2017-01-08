using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static Blog.Models.ApplicationUser;

namespace Blog.Models
{
    public class Article
    {
        private ICollection<Comment> comments;
        public Article()
        {
            this.comments = new HashSet<Comment>();
        }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        private ICollection<Tag> tags;
        public void ArticleTag()
        {
            this.tags = new HashSet<Tag>();
        }

        public Article (string authorId,string title,string content,int categoryId)
        {
            this.AuthorId = authorId;
            this.Title = title;
            this.Content = content;
            this.CategoryId = categoryId;
            this.tags = new HashSet<Tag>();
            this.comments = new HashSet<Comment>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        

        public virtual ApplicationUser Author { get; set; }

        public bool IsAuthor(string name)
        {
            return this.Author.UserName.Equals(name);
        }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}