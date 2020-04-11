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
            Timer t = new Timer(100000); //�]�p�ɶ����j�A�p�G�@�Ӥp�ɰ���@���N�אּ3600000 
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);
            t.AutoReset = true;
            t.Enabled = true;
        }

        private async void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            //�Ƶ{���e
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
                // �]�w���W�� (���n) (�w�]��: v1)
                config.DocumentName = "v1";

                // �]�w���� API ������T
                config.Version = "1.0";

                // �]�w�����D (����� Swagger/ReDoc UI ���ɭԷ|��ܦb�e���W)
                config.Title = "Work and school calceled data API";

                // �]�w���²�n����
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
                // �o�̪� Path �Ψӳ]�w ReDoc UI ������ (���}���|) (�@�w�n�H / �׽u�}�Y)
                config.Path = "/redoc";
            });
        }
    }
}
