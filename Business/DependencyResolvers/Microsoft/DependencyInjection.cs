using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Mappings.AutoMapper;
using Business.ValidationRules.Advertisement;
using Business.ValidationRules.AdvertisementAppUser;
using Business.ValidationRules.AppUser;
using Business.ValidationRules.Gender;
using Business.ValidationRules.ProvidedService;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Contexts;
using DataAccess.UnitOfWork;
using Dtos.Concrete.AdvertisementAppUserDto;
using Dtos.Concrete.AdvertisementDto;
using Dtos.Concrete.AppUserDto;
using Dtos.Concrete.GenderDto;
using Dtos.Concrete.ProvidedServiceDto;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers.Microsoft
{
    public static class DependencyInjection
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            //Db
            services.AddDbContext<AdvertisementContext>(opts =>
            {
                opts.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AdvertisementApp;Trusted_Connection=True;");
            });
            
            //FluentValidation
            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();
            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInDtoValidator>();
            services.AddTransient<IValidator<AdvertisementAppUserDto>, AdvertisementAppUserValidator>();
            //Dependency Injection 
            services.AddScoped<IUoW, UoW>(); 
            services.AddScoped<IAdvertisementDal, AdvertisementDal>();
            services.AddScoped<IProvidedServiceService, ProvidedServiceManager>();
            services.AddScoped<IAdvertisementService, AdvertisementManager>();
            services.AddScoped<IGenderService, GenderManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAdvertisementAppUserService, AdvertisementAppUserManager>();
        }
    }
}
