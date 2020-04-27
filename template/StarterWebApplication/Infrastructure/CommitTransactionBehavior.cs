using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using StarterWebApplication.Persistence;

namespace StarterWebApplication.Infrastructure
{
    public class CommitTransactionBehavior<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly StarterWebApplicationContext _context;

        public CommitTransactionBehavior(StarterWebApplicationContext context)
        {
            _context = context;
        }

        public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            if (_context.Database.CurrentTransaction != null)
            {
                _context.Database.CommitTransaction();
            }
            return Task.CompletedTask;
        }
    }
}