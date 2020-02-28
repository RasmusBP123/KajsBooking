using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public interface IEventHandler<in TEvent>
    {
        Task Handle(TEvent @event, CancellationToken cancellationToken);
    }
}
