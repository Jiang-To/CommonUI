using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonUI.Server.Config;
using CommonUI.Server.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VueCliMiddleware;

namespace CommonUI.Server {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            //  
            services.AddMvc(options => {
                options.OutputFormatters.RemoveType<TextOutputFormatter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            // add windows authentication service
            services.AddAuthentication(HttpSysDefaults.AuthenticationScheme);

            // add response compression
            services.AddResponseCompression();

            // add logger service
            var appConfig = new AppConfig(Configuration);
            services.AddSingleton<AppConfig>(appConfig);
            services.AddLogger(appConfig);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                
                /* uncomment below lines to enable integrated mode */
                // app.UseSpa(spa => {
                //     spa.Options.SourcePath = @"..\CommonUI.Client";
                //     spa.UseVueCli(npmScript: "serve", port: 8080);
                // });
            }
            else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseResponseCompression();
            
            app.UseStaticFiles();
            app.UseDefaultFiles();
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvc();
        }
    }
}