[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MvcFrameworkApp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MvcFrameworkApp.App_Start.NinjectWebCommon), "Stop")]

namespace MvcFrameworkApp.App_Start
{
    using AutoMapper;
    using DAL;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using MvcFrameworkApp.MapperProfiles;
    using Ninject;
    using Ninject.Web.Common;
    using Shared.Services;
    using System;
    using System.Configuration;
    using System.Web;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            SetupDbContext(kernel);

            kernel.Bind<ICurrentDateServiceFactory>().To<CurrentDateServiceFactory>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IGameService>().To<GameService>();
            kernel.Bind<IReferenceService>().To<ReferenceService>();

            var config = new MapperConfiguration(c => {
                c.AddProfile(new MapperProfile());
                c.AddProfile(new MvcMapperProfile());
            });
            var mapper = config.CreateMapper();
            kernel.Bind<IMapper>().ToConstant(mapper);
        }

        private static void SetupDbContext(IKernel kernel)
        {
            var connectionString = ConfigurationManager.AppSettings["DefaultConnection"];
            var options = new DbContextOptionsBuilder<EfContext>()
                            .UseSqlServer(connectionString)
                            .Options;
            kernel.Bind<EfContext>().ToSelf().WithConstructorArgument("options", options);
        }
    }
}
