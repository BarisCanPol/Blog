using Blog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.ORM.Map
{
    public class CategoryMap : BaseMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.Categories");
            Property(k => k.CategoryName).HasMaxLength(50).IsOptional();
            Property(k => k.Description).HasMaxLength(50).IsOptional();

            HasMany(k => k.Articles)
                .WithRequired(k => k.Category)
                .HasForeignKey(k => k.CategoryID)
                .WillCascadeOnDelete(false);
        }
    }
}
