using Autofac;

namespace StarterWebApplication.Tests.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static readonly DependencyContainer Singleton = new DependencyContainer();
        
        private readonly IContainer _container;
        
        private DependencyContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<DependencyModule>();
            _container = builder.Build();
        }

        public ILifetimeScope CreateScope()
        {
            return _container.BeginLifetimeScope();
        }
    }
}