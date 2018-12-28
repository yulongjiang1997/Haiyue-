using System;
using System.IO;
using AutoMapper;
using Haiyue.Service.Services.PurchaseServices;
using Haiyue.Web.ActionFilter;
using Haiyue.HYEF;
using Haiyue.Service.Services.CurrencyServices;
using Haiyue.Service.Services.GameServices;
using Haiyue.Service.Services.PositionServices;
using Haiyue.Service.Services.UserServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Haiyue.Service.Services.NoteBookServices;
using Haiyue.Service.Services.DepartmentServices;

namespace Haiyue.Web
{
    /// <summary>
    /// Startup类
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //配置跨域
            services.AddCors(options =>
            {
                options.AddPolicy("allow_all", builder =>
                {
                    builder.AllowAnyOrigin() //允许任何来源的主机访问
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();//指定处理cookie
                });
            });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAutoMapper();//注册Automapper

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Haiyue API",
                    Description = "The All Web API List",
                    TermsOfService = "None",
                });

                //Determine base path for the application.  
                //Set the comments path for the swagger json and ui.  
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "Haiyue.Web.xml");
                options.IncludeXmlComments(xmlPath);
            });
            services.AddDbContextPool<HYContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
            //services.AddDbContextPool<HYContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TestSqlServer")));//测试数据库
            services.AddMvc(options => { options.Filters.Add(typeof(PermissionActionFillter)); });//权限检查
            services.AddMvc(options => { options.Filters.Add(typeof(ExceptionFiltering)); });

            #region 依赖注入添加
            services.AddTransient<IPurchaseService, PurchaseService>();
            services.AddTransient<IUserservice, Userservice>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IPositionService, PositionService>();
            services.AddTransient<INoteBookService, NoteBookService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<BaseService>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //启动跨域
            app.UseCors("allow_all");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MsSystem API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
