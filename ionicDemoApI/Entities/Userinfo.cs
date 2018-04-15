using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ionicDemoApI.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Des { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public ICollection<User> Users { get; set; }
    }

    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Des).HasMaxLength(20);
            builder.Property(x => x.CreateTime).IsRequired();
            builder.Property(x => x.ModifyTime).IsRequired();
        }
    }

    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }

    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.RoleId).IsRequired();
            builder.Property(x => x.Username).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(8);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(20);
            builder.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
