using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkStatus.Core.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Timer t = new Timer(100000); //設計時間間隔，如果一個小時執行一次就改為3600000 
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);
            t.AutoReset = true;
            t.Enabled = true;
        }

        private async void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            //排程內容
            Controllers.StatusController statusController = new Controllers.StatusController();
            await statusController.GetAsync();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Add OpenAPI v3 document
            services.AddOpenApiDocument(config =>
            {
                // 設定文件名稱 (重要) (預設值: v1)
                config.DocumentName = "v1";

                // 設定文件或 API 版本資訊
                config.Version = "1.0";

                // 設定文件標題 (當顯示 Swagger/ReDoc UI 的時候會顯示在畫面上)
                config.Title = "Work and school calceled data API";

                // 設定文件簡要說明
                config.Description = "I know I am not a good programmger so I created this API for everyone.<br />Contact me Poyi.Hong[@]outlook.com";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();       // serve OpenAPI/Swagger documents

            app.UseSwaggerUi3();    // serve Swagger UI

            app.UseReDoc(config =>  // serve ReDoc UI
            {
                // 這裡的 Path 用來設定 ReDoc UI 的路由 (網址路徑) (一定要以 / 斜線開頭)
                config.Path = "/redoc";
            });
        }
    }
}
