﻿using System;
using System.IO;
using EF;
using EPMS.Service.Services.PurchaseServices;
using EPMS.Web.ActionFilter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace EPMS.Web
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "EPMS API",
                    Description = "The All Web API List",
                    TermsOfService = "None",
                });

                //Determine base path for the application.  
                //Set the comments path for the swagger json and ui.  
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "Haiyue.Web.xml");
                options.IncludeXmlComments(xmlPath);
            });
            services.AddDbContextPool<EPMSContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
            //services.AddMvc(options => { options.Filters.Add(typeof(PermissionActionFillter)); });//权限检查
            services.AddMvc(options => { options.Filters.Add(typeof(ExceptionFiltering)); });

            #region 依赖注入添加
            services.AddTransient<IPurchaseService, PurchaseService>();
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