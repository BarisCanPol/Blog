using Blog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.ORM.Map
{
    public class ArticleMap : BaseMap<Article>
    {
        public ArticleMap()
        {
            ToTable("dbo.Articles");
            Property(d => d.Header).HasMaxLength(100).IsRequired();
            Property(d => d.Content).HasMaxLength(100).IsRequired();


            HasRequired(h => h.Category)
                .WithMany(h => h.Articles)
                .HasForeignKey(h => h.CategoryID)
                .WillCascadeOnDelete(false);

            HasRequired(j => j.AppUser)
                .WithMany(j => j.Articles)
                .HasForeignKey(j => j.AppUserID)
                .WillCascadeOnDelete(false);
                

            HasMany(f => f.Likes)
                .WithRequired(f => f.Article)
                .HasForeignKey(f => f.ArticleID)
                .WillCascadeOnDelete(false);

            HasMany(g => g.Comments)
                .WithRequired(g => g.Article)
                .HasForeignKey(g => g.ArticleID)
                .WillCascadeOnDelete(false);

        }
    }
}
