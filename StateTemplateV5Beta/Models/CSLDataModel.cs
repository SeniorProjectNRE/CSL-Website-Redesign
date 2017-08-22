namespace StateTemplateV5Beta
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using StateTemplateV5Beta.Models;
    using StateTemplateV5Beta.Models.HelperClasses;

    public partial class CSLDataModel : DbContext
    {
        public CSLDataModel()
            : base("name=CSLDataModel")
        {
        }

        public virtual DbSet<Blog> AddBlogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
