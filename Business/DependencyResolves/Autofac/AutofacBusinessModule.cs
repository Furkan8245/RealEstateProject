using Autofac;
using Castle.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Autofac.Extras.DynamicProxy;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System.Reflection;
using Module= Autofac.Module;
using Core.Utilities.Interceptors;
namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            containerBuilder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            containerBuilder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            containerBuilder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            containerBuilder.RegisterType<RealEstateManager>().As<IRealEstateService>().SingleInstance();
            containerBuilder.RegisterType<EfRealEstateDal>().As<IRealEstateDal>().SingleInstance();
            containerBuilder.RegisterType<EfNeighborhoodDal>().As<INeighborhoodDal>().SingleInstance();
            containerBuilder.RegisterType<NeighborhoodManager>().As<INeighborhoodService>().SingleInstance();

            containerBuilder.RegisterType<RealEstateContext>().AsSelf().InstancePerLifetimeScope();

            var assembly = Assembly.GetExecutingAssembly();
            containerBuilder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
