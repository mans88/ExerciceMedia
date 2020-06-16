namespace MediaLibrary.DAL.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Models : DbContext
    {
        public Models()
            : base("name=Entities")
        {
        }

        public virtual DbSet<Category> CATEGORY { get; set; }
        public virtual DbSet<Media> MEDIA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.MEDIA)
                .WithMany(e => e.CATEGORY)
                .Map(m => m.ToTable("MEDIACATEGORY").MapLeftKey("id_1").MapRightKey("id"));

            modelBuilder.Entity<Media>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Media>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<Media>()
                .Property(e => e.path)
                .IsUnicode(false);
        }
    }
}