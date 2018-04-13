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
        public List<Machine> Machines { get; }
        public FunctionService()
        {
            Functions = new List<Function>
            {
                new Function { Id=1,ParentId=0,ModuleName="监控管理",page="DataTabPage",index=null,
                    ChildFunc = new List<Function> {
                        new Function
                        {
                            Id=11,ParentId=0,ModuleName="模块1",page="",index=null,
                            ChildFunc = new List<Function>{
                                new Function{ Id=111,ParentId=11,ModuleName="实时数据",page="RtdataPage",index=0,icon="globe"},

                            }
                        },
                        new Function
                        {
                            Id=12,ParentId=0,ModuleName="模块2",page="",index=null,
                            ChildFunc = new List<Function>{
                                 new Function{ Id=121,ParentId=12,ModuleName="机器图表",page="MachineChartPage",index=1,},
                                 new Function{ Id=122,ParentId=12,ModuleName="润滑信息",page="MachineListPage",index=3,},
                            }
                        },
                        new Function
                        {
                             Id=13,ParentId=0,ModuleName="模块3",page="",index=null,
                            ChildFunc = new List<Function>{
                                 new Function{ Id=131,ParentId=13,ModuleName="机器列表",page="LubricationInfoPage",index=2,},
                                 new Function{ Id=132,ParentId=13,ModuleName="",page="",index=null,},
                            }
                        }
                    }
                },
                new Function { Id=2,ParentId=0,ModuleName="远程详情",page="",
                     ChildFunc = new List<Function> {
                        new Function
                        {
                            Id=11,ParentId=0,ModuleName="模块1",page="",index=null,
                            ChildFunc = new List<Function>{
                                new Function{ Id=111,ParentId=11,ModuleName="参数信息",page="",index=null,icon="laptop"},

                            }
                        },
                        new Function
                        {
                            Id=12,ParentId=0,ModuleName="模块2",page="",index=null,
                            ChildFunc = new List<Function>{
                                 new Function{ Id=121,ParentId=12,ModuleName="通信诊断",page="",index=null,},
                                 new Function{ Id=122,ParentId=12,ModuleName="实时温度",page="",index=null,},

                            }
                        },
                        new Function
                        {
                             Id=13,ParentId=0,ModuleName="模块3",page="",index=null,
                            ChildFunc = new List<Function>{
                                 new Function{ Id=131,ParentId=13,ModuleName="远程解码",page="",index=null,},
                                 new Function{ Id=132,ParentId=13,ModuleName="",page="",index=null,},
                            }
                        }
                    }
                },
                new Function { Id=3,ParentId=0,ModuleName="系统管理",page="",index=null,
                 ChildFunc = new List<Function> {
                        new Function
                        {
                            Id=11,ParentId=0,ModuleName="模块1",page="",index=null,
                            ChildFunc = new List<Function>{
                                new Function{ Id=111,ParentId=11,ModuleName="注塑机管理",page="",index=null,icon="construct"},

                            }
                        },
                        new Function
                        {
                            Id=12,ParentId=0,ModuleName="模块2",page="",index=null,
                            ChildFunc = new List<Function>{
                                 new Function{ Id=121,ParentId=12,ModuleName="区片管理",page="",index=null,},
                                 new Function{ Id=122,ParentId=12,ModuleName="",page="",index=null,},
                            }
                        },
                        new Function
                        {
                            Id=13,ParentId=0,ModuleName="模块3",page="",index=null,
                            ChildFunc = new List<Function>{
                                 new Function{ Id=131,ParentId=13,ModuleName="公司管理",page="",index=null,},
                                 new Function{ Id=132,ParentId=13,ModuleName="",page="",index=null,},
                            }
                        }
                    }
                },
            };
            Machines = new List<Machine>
            {
                new Machine
                {
                    Id=1,
                    SerialNumber="ty-00001",
                    State="时间自动",
                    Motion="开模1段"
                },
                new Machine
                {
                    Id=1,
                    SerialNumber="ty-00001",
                    State="时间自动",
                    Motion="开模1段"
                },
                new Machine
                {
                    Id=1,
                    SerialNumber="ty-00001",
                    State="时间自动",
                    Motion="开模1段"
                },
                new Machine
                {
                    Id=1,
                    SerialNumber="ty-00001",
                    State="时间自动",
                    Motion="开模1段"
                },
                new Machine
                {
                    Id=1,
                    SerialNumber="ty-00001",
                    State="离线",
                    Motion="无"
                },
                new Machine
                {
                    Id=1,
                    SerialNumber="ty-00001",
                    State="离线",
                    Motion="无"
                },
                new Machine
                {
                    Id=1,
                    SerialNumber="ty-00001",
                    State="离线",
                    Motion="无"
                },new Machine
                {
                    Id=1,
                    SerialNumber="ty-00001",
                     State="离线",
                    Motion="无"
                },new Machine
                {
                    Id=1,
                    SerialNumber="ty-00001",
                     State="离线",
                    Motion="无"
                },new Machine
                {
                    Id=1,
                    SerialNumber="ty-00001",
                     State="离线",
                    Motion="无"
                },new Machine
                {
                    Id=1,
                    SerialNumber="ty-00001",
                    State="离线",
                    Motion="无"
                },new Machine
                {
                    Id=1,
                    SerialNumber="ty-00001",
                     State="离线",
                    Motion="无"
                },
            };
        }
    }
}
