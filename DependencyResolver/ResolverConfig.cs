using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using DAL.EF;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IRepository>().To<AccountDBRepository>();
            kernel.Bind<IAccountService>().To<AccountService>().WithConstructorArgument(kernel.Get<IRepository>());
            //kernel.Bind<IRepository>().To<FakeRepository>();
            kernel.Bind<IAccountNumberCreateService>().To<AccountNumberCreator>().InSingletonScope();
            //kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        }
    }
}
