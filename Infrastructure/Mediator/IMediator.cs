using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Mediator
{
    public interface IMediator
    {
        Task SendAsync<TMessage>(TMessage message, CancellationToken token = default);
        Task<TResult> QueryAsync<TMessage, TResult>(TMessage message, CancellationToken token = default);
        Task<TResult> PublishAsync<TMessage, TResult>(TMessage @event, CancellationToken token = default);
    }
}
