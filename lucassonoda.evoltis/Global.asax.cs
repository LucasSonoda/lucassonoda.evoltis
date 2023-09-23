using Autofac;
using Autofac.Integration.Web;
using BusinessLogic.Employee;
using BusinessLogic.Repository;
using Serilog;
using Serilog.Core;
using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace lucassonoda.evoltis
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        static IContainerProvider _containerProvider;
        static string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        static Logger _logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"))
        .CreateLogger();

        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        void Application_Start(object sender, EventArgs e)
        {
            _logger.Information("Iniciando WEB");
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder
                 .Register(Context =>
                 {
                     return new RepositoryContext(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);
                 })
                 .InstancePerLifetimeScope();
            builder
                .Register<ILogger>(_ => _logger)
                .SingleInstance();
            builder
                .RegisterType<EmployeeService>()
                .As<IEmployeeService>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<EmployeeRepository>()
                .As<IEmployeeRepository>()
                .InstancePerLifetimeScope();

            _containerProvider = new ContainerProvider(builder.Build());
        }

        protected void Application_End(object sender, EventArgs e)
        {
            _logger.Dispose();
        }
    }
}