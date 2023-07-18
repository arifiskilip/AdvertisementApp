using AutoMapper;
using Business.DependencyResolvers.Microsoft;
using Business.Helpers.Udemy.AdvertisementApp.Business.Helpers;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebUI.Mapping;
using WebUI.Models;
using WebUI.Validations;

namespace WebUI
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
            //AutoMapper

            var profiles = ProfileHelper.GetProfiles();
            profiles.Add(new UserCreateModelMapper());
            profiles.Add(new AdvertisementAppUserModelMapper());
            var mapperConfiguration = new MapperConfiguration(options =>
            {
                options.AddProfiles(profiles);
            });
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
             //

            services.AddDependencies();
            services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();
            services.AddControllersWithViews();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(opt =>
            {
                opt.Cookie.Name = "MyCookie";
                opt.Cookie.HttpOnly= true; // Client Side Scriptleri Engelle
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict; //Baþka sitelerde kullanma
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.ExpireTimeSpan = System.TimeSpan.FromMinutes(30);
                opt.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/SingIn");
                opt.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/Account/LogOut");
                opt.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/AccessDenied"); // Eriþim Engellendi
            });


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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
