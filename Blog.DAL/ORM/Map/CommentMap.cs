using Blog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.ORM.Map
{
    public class CommentMap : BaseMap<Comment>
    {
        public CommentMap()
        {
            ToTable("dbo.Comments");
            Property(a => a.Header).IsRequired();
            Property(a => a.Content).IsRequired();
            Property(a => a.CommentNumber).IsOptional();


            //HasKey(q=> new{q.AppUserID,q.ArticleID}); There is only one sentence instead of unders !
            HasRequired(a => a.AppUser)
                .WithMany(a => a.Comments)
                .HasForeignKey(a => a.AppUserID)
                .WillCascadeOnDelete(false);

            HasRequired(a => a.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(a => a.ArticleID)
                .WillCascadeOnDelete(false);
        }
    }
}
