using Domain.ProductContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class EventStoreProductRepository : IProductRepository
    {
        private readonly IEventStore _eventStore;

        public EventStoreProductRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public async Task Save(Product aggregate, CancellationToken token)
        {
            await _eventStore.SaveEvents(aggregate.Id, aggregate.GetUnCommitedChanges(), aggregate.Version);
            aggregate.MarkChangesAsCommited();
        }

        public async Task<Product> Load(Guid id, CancellationToken token)
        {
            var aggregate = new Product();
            var history = await _eventStore.GetEventsForAggregate(id);
            aggregate.LoadsFromHistory(history);
            return aggregate;
        }
    }
}
