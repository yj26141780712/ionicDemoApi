using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ionicDemoApI.Entities
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
           : base(options)
        {
            //Database.EnsureCreated(); //如果没有数据库会自动创建一个数据库 但是如果数据库需要变更此方法就不合适 应该采用迁移 Migration
            Database.Migrate();
            //自动创建表，如果Entity有改到就更新到表结构
            //Database.SetInitializer<MyContext>(new MigrateDatabaseToLatestVersion<BlogAppContext, ReportingDbMigrationsConfiguration>());
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        //设置连接字符串的方法
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("xxxx connection string");
        //    base.OnConfiguring(optionsBuilder);
        //}

        //设置实体 数据库属性
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>().HasKey(x => x.Id);
        //    modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired().HasMaxLength(50);
        //    modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(8,2)");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
