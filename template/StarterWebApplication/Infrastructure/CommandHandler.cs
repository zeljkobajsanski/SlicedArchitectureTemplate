using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using StarterWebApplication.Persistence;

namespace StarterWebApplication.Infrastructure
{
    public abstract class CommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly StarterWebApplicationContext Context;
        protected readonly IMapper Mapper;
        protected IMediator Mediator;

        protected CommandHandler(StarterWebApplicationContext context, IMapper mapper, IMediator mediator)
        {
            Context = context;
            Mapper = mapper;
            Mediator = mediator;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}