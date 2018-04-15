using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ionicDemoApI.Entities;
using ionicDemoApI.Repositories;
using ionicDemoApI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;

namespace ionicDemoApI
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); // 注册MVC到Container
                               //services.AddMvc().AddJsonOptions(options =>
                               //       {
                               //           if (options.SerializerSettings.ContractResolver is DefaultContractResolver resolver)
                               //           {
                               //               resolver.NamingStrategy = null;
                               //           }
                               //       });
            #if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService, CloudMailService>();
#endif
            // services.AddTransient<LocalMailService>(); //在容器中注册邮件服务

            //EF core的连接字符串配置 
            // string conStr = @"Server=(localdb)\MSSQLLocalDB;Database=ProductDB;Trusted_Connection=True";
            string constr = Configuration.GetConnectionString("MySqlConnection");

            services.AddDbContext<MyContext>(o=>o.UseMySql(constr));//注册MyContext 连接mysql, sqlserve使用useSqlserve
            services.AddScoped<IUserinfoRepository, UserinfoRepository>();//注册数据存储 使用AddScoped 每次实例化一个
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,MyContext myContext)
        {
            // loggerFactory.AddProvider(new NLogLoggerProvider());
            loggerFactory.AddNLog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.WithOrigins("*");
            });
            //myContext.EnsureSeedDataForContext(); //种子数据 表空时自动填充示例数据
            app.UseStatusCodePages(); // 如果不加这句 页面报错 反之返回错误Code页面
            app.UseMvc(); //告诉程式使用MVC中间件
        }
    }
}
