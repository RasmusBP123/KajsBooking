using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Abstraction
{
    public interface IAggreateRoot
    {
        int Version { get; }
        bool Changes();
        IEnumerable<object> GetUnCommitedChanges();
        void MarkChangesAsCommited();
        void LoadsFromHistory(IEnumerable<object> history);
    }

    public abstract class AggregateRoot<TKey> : IAggreateRoot
    {
        public readonly List<object> _changes = new List<object>();
        private readonly InstanceEventRouter _router;

        public AggregateRoot()
        {
            _router = new InstanceEventRouter();
        }

        public virtual TKey Id { get; protected set; }
        public int Version { get; protected set; }

        public bool Changes() => _changes.Any();

        //Gets the events for the entitty
        public IEnumerable<object> GetUnCommitedChanges()
        {
            return _changes;
        }

        //When event has been committed to database, you should clear the list of events
        public void MarkChangesAsCommited()
        {
            _changes.Clear();
        }

        public void LoadsFromHistory(IEnumerable<object> history)
        {
            foreach (var @event in history)
            {
                ApplyChange(@event, false);
            }
        }

        protected void Register<TEvent>(Action<TEvent> handler)
        {
            if (handler is null) throw new ArgumentNullException(nameof(handler));
            _router.ConfigureRoute(handler);
        }

        protected void ApplyChange(object @event)
        {
            ApplyChange(@event, true);
        }

        protected void ApplyChange(object @event, bool isNew)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));
            _router.Route(@event);

            if (isNew)
            {
                _changes.Add(@event);
                Version++;
            }
        }
    }
}
