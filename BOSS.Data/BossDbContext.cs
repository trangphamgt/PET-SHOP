namespace BOSS.Data
{
    using BOSS.Model.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BossDbContext : IdentityDbContext<ApplicationUser>
    {
        public BossDbContext()
            : base("BossDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public static BossDbContext Create()
        {
            return new BossDbContext();
        }

        public virtual DbSet<Menu> Menus { set; get; }
        public virtual DbSet<Product> Products { set; get; }
        public virtual DbSet<ProductCategory> ProductCategories { set; get; }
        public virtual DbSet<Post> Posts { set; get; }
        public virtual DbSet<PostCategory> PostCategory { set; get; }
        public virtual DbSet<Tag> Tags { set; get; }
        public virtual DbSet<PostTag> PostTags { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<OrderDetail> OrderDetails { set; get; }
        public virtual DbSet<Comment> Comments { set; get; }
        public virtual DbSet<Error> Errors { set; get; }
        //public virtual DbSet<MenuGroup> MenuGroups { set; get; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole>().HasKey<string>(r => r.UserId);
            modelBuilder.Entity<IdentityUserRole>().HasKey<string>(r => r.RoleId);
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(r => r.UserId);

            base.OnModelCreating(modelBuilder);
        }


    }
    
}