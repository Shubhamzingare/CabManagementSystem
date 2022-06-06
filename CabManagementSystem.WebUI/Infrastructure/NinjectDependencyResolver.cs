using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using CabManagementSystem.Domain.Abstract;
using CabManagementSystem.Domain.Concrete;
namespace CabManagementSystem.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        //prepare for DI
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IEmployeeRepository>().To<EFEmployeeRepository>();
            kernel.Bind<IShiftTimingsRepository>().To<EFShiftTimingRepository>();
            kernel.Bind<IRouteDetailRepository>().To<EFRouteDetailRepository>();
            kernel.Bind<IBatchDetailRepository>().To<EFBatchDetailRepository>();
            kernel.Bind<IVehicleDetailRepository>().To<EFVehicleDetailRepository>();
            kernel.Bind<ITripRepository>().To<EFTripRepository>();

        }

        public object GetService(Type serviceType)
        {
            return kernel.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}