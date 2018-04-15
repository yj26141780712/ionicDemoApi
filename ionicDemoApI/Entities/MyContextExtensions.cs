using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ionicDemoApI.Entities
{
    public static class MyContextExtensions
    {
        public static void EnsureSeedDataForContext(this MyContext myContext)
        {
            if (myContext.Roles.Any())
            {
                return;
            }
            var roles = new List<Role>
            {
                new Role{
                    Name="管理员",
                    Des="管理员",
                    CreateTime=DateTime.Now,
                    ModifyTime=DateTime.Now
                },
                new Role
                {
                    Name="超级管理员",
                    Des="超级管理员",
                    CreateTime=DateTime.Now,
                    ModifyTime=DateTime.Now
                },
                new Role
                {
                    Name="普通人员",
                    Des ="普通人员",
                    CreateTime =DateTime.Now,
                    ModifyTime=DateTime.Now
                }
            };
            myContext.Roles.AddRange(roles);
            myContext.SaveChanges();
        }

    }
}
