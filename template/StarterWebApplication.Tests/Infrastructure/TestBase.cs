using System.Threading.Tasks;
using Autofac;
using MediatR;
using StarterWebApplication.Persistence;
using StarterWebApplication.Tests.Infrastructure.IoC;

namespace StarterWebApplication.Tests.Infrastructure
{
    public class TestBase
    {
        private readonly ILifetimeScope _scope;

        public TestBase()
        {
            _scope = DependencyContainer.Singleton.CreateScope();
        }

        protected T Get<T>()
        {
            return _scope.Resolve<T>();
        }

        protected StarterWebApplicationContext GetDatabase() => Get<StarterWebApplicationContext>();

        protected async Task<TResponse> Execute<TResponse>(IRequest<TResponse> request)
        {
            return await Get<IMediator>().Send(request);
        }

        ~TestBase()
        {
            _scope?.Dispose();
        }
    }
}