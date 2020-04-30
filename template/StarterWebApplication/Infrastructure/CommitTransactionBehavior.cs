using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;

namespace StarterWebApplication.Infrastructure
{
    public class CommitTransactionBehavior<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly DbContext _context;

        public CommitTransactionBehavior(DbContext context)
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