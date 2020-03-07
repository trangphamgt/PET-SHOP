namespace BOSS.Data
{
    using BOSS.Model.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BossDbContext : DbContext
    {
        public BossDbContext()
            : base("BossDbConnecion")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }


        public virtual DbSet<Menu> Menus { set; get; }
        public virtual DbSet<MenuGroup> MenuGroups { set; get; }
        public virtual DbSet<Product> Products { set; get; }
        public virtual DbSet<ProductCategory> ProductCategories { set; get; }
        public virtual DbSet<Post> Posts { set; get; }
        public virtual DbSet<PostCategory> PostCategory { set; get; }
        public virtual DbSet<Tag> Tags { set; get; }
        public virtual DbSet<PostTag> PostTags { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<OrderDetail> OrderDetails { set; get; }


        public static BossDbContext Create()
        {
            return new BossDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
    
}