using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;

namespace StarterWebApplication.Infrastructure
{
    public class BeginTransactionBehavior<T> : IRequestPreProcessor<T>
    {
        private readonly DbContext _context;

        public BeginTransactionBehavior(DbContext context)
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