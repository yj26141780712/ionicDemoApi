using ionicDemoApI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ionicDemoApI.Services
{
    public class UserinfoService
    {
        public static UserinfoService Current{ get; } = new UserinfoService();
        public List<Role> Roles { get; }
        public UserinfoService()
        {
            Roles = new List<Role>
            {
                new Role
                {
                    Id=1,
                    Name="普通人员1",
                    Des="普通人员",
                    Users = new List<User>{
                        new User
                        {
                            Id=1,
                            Username="yangjie1",
                            Name="杨杰1",
                            Password="Aa123"
                        },
                         new User
                        {
                            Id=2,
                            Username="yangjie2",
                            Name="杨杰1",
                            Password="Aa123"
                        },
                        new User
                        {
                            Id=3,
                            Username="yangjie3",
                            Name="杨杰1",
                            Password="Aa123"
                        }
                    }

                },
                new Role
                {
                    Id=2,
                    Name="管理员",
                    Des="管理员",
                    Users = new List<User>{
                        new User
                        {
                            Id=4,
                            Username="admin1",
                            Name="admin1",
                            Password="Aa123"
                        },
                         new User
                        {
                            Id=5,
                            Username="admin2",
                            Name="admin2",
                            Password="Aa123"
                        },
                    }

                },new Role
                {
                    Id=3,
                    Name="超级管理员",
                    Des="超级管理员",
                    Users = new List<User>{
                        new User
                        {
                            Id=6,
                            Username="root",
                            Name="root",
                            Password="Aa123"
                        },
                    }

                },
            };
        }
    }
}
