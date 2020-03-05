using Application;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Mediator
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Task SendAsync<TMessage>(TMessage message, CancellationToken token = default)
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TMessage>>();
            if(handler == null) throw new NullReferenceException($"handler of {nameof(TMessage)}");

            return handler.Handle(message, token);
        }


        public Task<TResult> QueryAsync<TMessage, TResult>(TMessage message, CancellationToken token = default)
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TMessage, TResult>>();
            if (handler == null) throw new NullReferenceException($"handler of {nameof(TMessage)}");

            return handler.Handle(message, token);
        }

        public Task PublishAsync<TEvent>(TEvent message, CancellationToken token = default)
        {
            var handler = _serviceProvider.GetRequiredService<IEventHandler<TEvent>>();
            if (handler == null) throw new NullReferenceException($"handler of {nameof(TEvent)}");

            return handler.Handle(message, token);
        }
    }
}
