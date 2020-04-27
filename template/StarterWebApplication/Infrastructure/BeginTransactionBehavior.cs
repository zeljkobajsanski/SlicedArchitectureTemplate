using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using StarterWebApplication.Persistence;

namespace StarterWebApplication.Infrastructure
{
    public class BeginTransactionBehavior<T> : IRequestPreProcessor<T>
    {
        private readonly StarterWebApplicationContext _context;

        public BeginTransactionBehavior(StarterWebApplicationContext context)
        {
            _context = context;
        }

        public async Task Process(T request, CancellationToken cancellationToken)
        {
            if (_context.Database.CurrentTransaction == null)
            {
                await _context.Database.BeginTransactionAsync(cancellationToken);
            }
        }
    }
}