using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Abstraction
{
    public interface IRepository<T, TKey> where T: AggregateRoot<TKey>
    {
        Task Save(T aggregate, CancellationToken token);
        Task Load(TKey id, CancellationToken token);
    }
}
