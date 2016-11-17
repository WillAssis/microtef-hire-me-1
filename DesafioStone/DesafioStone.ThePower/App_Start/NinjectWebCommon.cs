[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DesafioStone.ThePower.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DesafioStone.ThePower.App_Start.NinjectWebCommon), "Stop")]

namespace DesafioStone.ThePower.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Application.Contracts;
    using Application.Services;
    using Domain.Contracts.Services;
    using Domain.Services;
    using Domain.Contracts.Repository;
    using Infra.Repository;
    using System.Web.Http;
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

                GlobalConfiguration.Configuration
                    .DependencyResolver = kernel.Get<System.Web.Http.Dependencies.IDependencyResolver>();

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
            //injeções de dependência

            //Nível Aplicação
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IAppServiceClient>().To<AppServiceClient>();
            kernel.Bind<IAppServiceCard>().To<AppServiceCard>();
            kernel.Bind<IAppServiceTransaction>().To<AppServiceTransaction>();

            //Nível Domínio
            kernel.Bind(typeof(IDomainServiceBase<>)).To(typeof(DomainServiceBase<>));
            kernel.Bind<IDomainServiceClient>().To<DomainServiceClient>();
            kernel.Bind<IDomainServiceCard>().To<DomainServiceCard>();
            kernel.Bind<IDomainServiceTransaction>().To<DomainServiceTransaction>();

            //Nível InfraEstrutura
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IRepositoryClient>().To<RepositoryClient>();
            kernel.Bind<IRepositoryCard>().To<RepositoryCard>();
            kernel.Bind<IRepositoryTransaction>().To<RepositoryTransaction>();
        }        
    }
}
