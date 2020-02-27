using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Abstraction
{
    public class Entity
    {
        private readonly InstanceEventRouter _router;
        public Entity()
        {
            _router = new InstanceEventRouter();
        }

        protected void Register<TEvent>(Action<TEvent> handler)
        {
            if (handler == null) throw new Exception();
            _router.ConfigureRoute(handler);
        }

        public virtual void Route(object @event)
        {
            if (@event == null) throw new Exception();
            _router.Route(@event);
        }
    }
}
