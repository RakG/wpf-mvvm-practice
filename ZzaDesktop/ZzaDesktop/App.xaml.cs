using Autofac;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace ZzaDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ContainerBuilder builder = new ContainerBuilder();
            Assembly myAssembly = Assembly.GetExecutingAssembly();

            // Services
            builder.RegisterType<CustomersRepository>().As<ICustomersRepository>().SingleInstance();

            // View-Models
            builder.RegisterAssemblyTypes(new[] { myAssembly })
                  .Where(t => typeof(BindableBase).IsAssignableFrom(t))
                  .InstancePerDependency()
                  .AsSelf();

            // Main Window
            builder.RegisterType<MainWindow>().AsSelf().InstancePerDependency();

            IContainer container = builder.Build();

            using (ILifetimeScope scope = container.BeginLifetimeScope())
            {
                scope.Resolve<MainWindow>().Show();
            }
        }
    }
}
