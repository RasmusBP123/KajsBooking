using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public interface ICommandHandler<in TMessage>
    {
        Task Handle(TMessage message, CancellationToken token);
    }
}
