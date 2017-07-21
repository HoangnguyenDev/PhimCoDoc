using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DVMN.Data;
using DVMN.Models;
using DVMN.Services;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Serialization;

namespace DVMN
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }
            CurrentEnvironment = env;
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        private IHostingEnvironment CurrentEnvironment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMemoryCache();
            //if (CurrentEnvironment.IsDevelopment())
            //{
            //    //services.AddResponseCaching();
            //    services.AddDbContext<ApplicationDbContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //}
            //else
            //{
                services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("AzureConnection")));
            //}
            services.AddIdentity<Member, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.
                AddMvc(options =>
            {
                options.CacheProfiles.Add("Default",
                    new Microsoft.AspNetCore.Mvc.CacheProfile()
                    {
                        Duration = 60
                    });
                options.CacheProfiles.Add("Never",
                    new Microsoft.AspNetCore.Mvc.CacheProfile()
                    {
                        Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.None,
                        NoStore = true
                    });
            })
            .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession();
            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            // Add Kendo UI services to the services container
            services.AddKendo();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
              //  app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = (context) =>
                {
                    var headers = context.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new CacheControlHeaderValue()
                    {
                        MaxAge = TimeSpan.FromSeconds(120),
                        

                    };
                    // Cache static file for 1 year
                    //if (!string.IsNullOrEmpty(context.Context.Request.Query["v"]))
                    //{
                    //    context.Context.Response.Headers.Add("cache-control", new[] { "public,max-age=31536000" });
                    //    context.Context.Response.Headers.Add("Expires", new[] { DateTime.UtcNow.AddYears(1).ToString("R") }); // Format RFC1123
                    //}
                }
            });
            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715
            // IMPORTANT: This session call MUST go before UseMvc()
            app.UseSession();
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                LoginPath = "/quan-ly-web/dang-nhap",
                AuthenticationScheme = "Cookies",

                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });
            if (env.IsDevelopment())
            {
                app.UseFacebookAuthentication(new FacebookOptions()
                {
                    AppId = "112552656061422",
                    AppSecret = "a333bd5281e44e09f25f5234e3e86cf8"
                });

                //http://phimcodoc.azurewebsites.net/signin-facebook
            }
            else
            {
                app.UseFacebookAuthentication(new FacebookOptions()
                {
                    AppId = "846411685524427",
                    AppSecret = "61d17546384e1772e1f998f53a7bc89a"
                });

            }
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "areaRoute",
                    template: "{area:exists}/{controller=Admin}/{action=Index}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            // Configure Kendo UI
            app.UseKendo(env);
            //app.UseResponseCaching();
            //app.Run(async (context) =>
            //{
            //    context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue()
            //    {
            //        Public = true,
            //        MaxAge = TimeSpan.FromSeconds(10)
            //    };
            //    context.Response.Headers[HeaderNames.Vary] = new string[] { "Accept-Encoding" };

            //    await context.Response.WriteAsync("Hello World! " + DateTime.UtcNow);
            //});
        }
    }
}
