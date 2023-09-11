using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>();
            builder.RegisterType<EfCarRepository>().As<ICarRepository>();

            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<EfBrandRepository>().As<IBrandRepository>();

            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<EfColorRepository>().As<IColorRepository>();

            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerRepository>().As<ICustomerRepository>();

            builder.RegisterType<CarImageManager>().As<ICarImageService>();
            builder.RegisterType<EfCarImageRepository>().As<ICarImageRepository>();

            builder.RegisterType<RentalManager>().As<IRentalService>();
            builder.RegisterType<EfRentalRepository>().As<IRentalRepository>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserRepository>().As<IUserRepository>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<FileHelper>().As<IFileHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
