using Blog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.ORM.Map
{
    public class AppUserMap : BaseMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");
            Property(x => x.UserName).HasMaxLength(50).IsRequired();
            Property(x => x.Password).HasMaxLength(50).IsRequired();
            Property(c => c.Email).IsOptional();
            Property(v => v.FirstName).IsOptional();
            Property(b => b.LastName).IsOptional();
            Property(n => n.BirthDate).IsOptional();
            Property(m => m.Role).IsOptional();
            Property(o => o.Gender).IsOptional();

            HasMany(z => z.Articles)
                .WithRequired(z => z.AppUser)
                .HasForeignKey(z => z.AppUserID)
                .WillCascadeOnDelete(false);

            HasMany(a => a.Comments)
                .WithRequired(a => a.AppUser)
                .HasForeignKey(a => a.AppUserID)
                .WillCascadeOnDelete(false);

            HasMany(s => s.Likes)
                .WithRequired(s => s.AppUser)
                .HasForeignKey(s => s.AppUserID)
                .WillCascadeOnDelete(false);


        }
    }
}
