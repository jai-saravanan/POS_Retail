using Autofac;
using Autofac.Integration.Mvc;
using Persistance;
using Repository.Implementation;
using Repository.Interface;
using Services.Implementation;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace POS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacRegistration.BuildContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }

    public class AutofacRegistration
    {
        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Now grab your connection string and wire up your db context
            builder.Register(c => new POSDbContext());
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<SupplierService>().As<ISupplierService>();
            builder.RegisterType<TaxMasterService>().As<ITaxMasterService>();
            builder.RegisterType<PurchaseOrderService>().As<IPurchaseOrderService>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<SupplierRepository>().As<ISupplierRepository>();
            builder.RegisterType<TaxMasterRepository>().As<ITaxMasterRepository>();
            builder.RegisterType<PurchaseOrderRepository>().As<IPurchaseOrderRepository>();

            // You can register any other dependencies here

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
