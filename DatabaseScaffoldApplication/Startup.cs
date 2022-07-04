using DatabaseScaffoldApplication.Domain.Models;
using DatabaseScaffoldApplication.Domain.Repositories;
using DatabaseScaffoldApplication.Identity;
using DatabaseScaffoldApplication.Infrastructure.EfCore;
using DatabaseScaffoldApplication.Infrastructure.Repositories;
using DatabaseScaffoldApplication.Middlewares;
using DatabaseScaffoldApplication.Requirements;
using DatabaseScaffoldApplication.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {



            services.AddControllersWithViews();


            // Serilog Logger Settings

            //Log.Logger = new LoggerConfiguration()
            //.Enrich.FromLogContext()
            //.WriteTo.Console()
            //.CreateLogger();
            //Log.Information("Starting up");


        //    Log.Logger = new LoggerConfiguration()
        //.WriteTo.Console()
        //.CreateLogger();


            // .AddNewtonsoftJson(options =>
            //options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            // just only use AddScoped service Injection for Repository Design Pattern.
            // when you use validation libraray, we use transient scope


            services.AddTransient<ITransientService, TransientService>();
            services.AddScoped<IScopeService, ScopeService>();
            services.AddSingleton<ISingletonService, SingletonService>();


            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<NORTHWNDContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<AppIdentityDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("NetCoreMVCIdentity"));
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>(opt =>
            {

                //opt.User.RequireUniqueEmail = false;
                //opt.Password.RequireDigit = false;
                //opt.Password.RequireLowercase = false;

            }).AddEntityFrameworkStores<AppIdentityDbContext>();


            services.AddAuthentication("CookieAuthentication")
                 .AddCookie("CookieAuthentication", config =>
                 {


                     config.Cookie.Name = "IdentityCookie";
                     config.AccessDeniedPath = "/Account/Authorize";
                     config.LoginPath = "/Account/Login";
                     config.ExpireTimeSpan = TimeSpan.FromDays(1);
                     config.SlidingExpiration = true;
                 });

            services.AddSession();


            //services.ConfigureApplicationCookie(option => //cookie burada yaratýlýr.
            //{
            //    option.Cookie.Name = "UserLoginCookie";
            //    option.LoginPath = "/Auth/Login";
            //});

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("UserPolicy", policy => policy.RequireRole("Manager", "Admin"));
                opt.AddPolicy("DateOfBirthClaim", policy => policy.RequireClaim("DateOfBirth"));
                opt.AddPolicy("SpecificUserPolicy", policy => policy.AddRequirements(new SpesificDomainRequirement("neominal.com")));
                opt.AddPolicy("Resourcepolicy", policy => policy.AddRequirements(new OperationAuthorizationRequirement()));
            });


            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();

            services.AddSingleton<ICartService, CartService>();
            services.AddTransient<ICartSession, CartSession>();

            services.AddTransient<IAuthorizationHandler, DomainRequirementHandler>();
            services.AddTransient<IAuthorizationHandler, UserResourceHandler>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseMiddleware<ExceptionMiddleware>();

            //app.UseExceptionMiddleware();

            //uygulamaya yeni bir Yetkilendirme kuralý ekleme

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
