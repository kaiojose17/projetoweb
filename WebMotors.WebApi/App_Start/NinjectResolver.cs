using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using WebMotors.Domain;
using WebMotors.Domain.Interface;
using WebMotors.Domain.Interface.Services;
using WebMotors.Domain.Services;
using WebMotors.Infrastructure.Data.Repositories;
using WebMotors.Proxy;
using WebMotors.Proxy.Interface;

namespace WebMotors.WebApi.App_Start
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver() : this(new StandardKernel())
        {

        }

        public NinjectResolver(IKernel ninjectKernel, bool scope = false)
        {
            kernel = ninjectKernel;
            if (!scope)
            {
                AddBindings(kernel);
            }
        }

        private void AddBindings(IKernel kernel)
        {
            // singleton and transient bindings go here
        }

        private IKernel AddRequestBindings(IKernel kernel)
        {
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IWebMotorsService>().To<WebMotorsService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IWebMotorsRepository>().To<WebMotorsRepository>();

            kernel.Bind(typeof(IProxy<>)).To(typeof(IProxy<>));
            kernel.Bind(typeof(IAnuncioWebMotorsProxy)).To(typeof(AnuncioWebMotorsProxy));

            return kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectResolver(AddRequestBindings(new ChildKernel(kernel)), true);
        }

        public void Dispose()
        {
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}