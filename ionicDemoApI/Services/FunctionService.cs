using ionicDemoApI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ionicDemoApI.Services
{
    public class FunctionService
    {
        public static FunctionService Current { get; } = new FunctionService();
        public List<Function> Functions { get; }
        public FunctionService()
        {
            Functions = new List<Function>
            {
                new Function { Id=1,ParentId=0,ModuleName="监控管理",path="",
                    ChildFunc = new List<Function> {
                        new Function{ Id=11,ParentId=1,ModuleName="实时数据",path="",row="2",col="1" },
                        new Function{ Id=12,ParentId=1,ModuleName="机器图表",path="",row="1",col="1"  },
                        new Function{ Id=13,ParentId=1,ModuleName="润滑信息",path="",row="1",col="1" },
                        new Function{ Id=14,ParentId=1,ModuleName="机器列表",path="",row="1",col="1"  },
                        new Function{ Id=15,ParentId=1,ModuleName="",path="" ,row="1",col="1" },
                    }
                },
                new Function { Id=2,ParentId=0,ModuleName="远程详情",path="",
                    ChildFunc= new List<Function> {
                        new Function{ Id=21,ParentId=2,ModuleName="参数信息",path="",row="2",col="1" },
                        new Function{ Id=22,ParentId=2,ModuleName="通信诊断",path="",row="1",col="1" },
                        new Function{ Id=23,ParentId=2,ModuleName="实时温度",path="",row="1",col="1"},
                        new Function{ Id=24,ParentId=2,ModuleName="远程解码",path="",row="1",col="1" },
                        new Function{ Id=25,ParentId=2,ModuleName="",path="",row="1",col="1" },
                    }
                },
                new Function { Id=3,ParentId=0,ModuleName="系统管理",path="",
                    ChildFunc= new List<Function> {
                        new Function{ Id=31,ParentId=3,ModuleName="注塑机管理",path="",row="2",col="1" },
                        new Function{ Id=32,ParentId=3,ModuleName="区片管理",path="" ,row="1",col="1" },
                        new Function{ Id=33,ParentId=3,ModuleName="公司管理",path="",row="1",col="1" },
                        new Function{ Id=34,ParentId=3,ModuleName="",path="",row="1",col="2" },
                    }
                },

            };
        }
    }
}
