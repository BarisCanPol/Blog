using Blog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.ORM.Map
{
    public class LikeMap : BaseMap<Like>
    {
        public LikeMap()
        {
            ToTable("dbo.Likes");
            Property(a => a.LikeNumber).IsOptional();


           // HasKey(w => new { w.AppUserID, w.ArticleID }); 
            HasRequired(a => a.Article)
                .WithMany(a => a.Likes)
                .HasForeignKey(a => a.ArticleID)
                .WillCascadeOnDelete(false);

            HasRequired(a => a.AppUser)
                .WithMany(a => a.Likes)
                .HasForeignKey(a => a.AppUserID)
                .WillCascadeOnDelete(false); 
            
        }
    }
}
