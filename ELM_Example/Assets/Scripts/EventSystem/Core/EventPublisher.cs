using ELM_Example.Core;
using System;
using System.Collections.Generic;

namespace ELM_Example.EventSystem
{
    public class EventPublisher<T> : DescriptionBaseSO
    {
        private readonly HashSet<IEventListener<T>> _listeners = new HashSet<IEventListener<T>>();
        public event Action<T> OnEventRaised;
        public void Raise(T item)
        {
            OnEventRaised?.Invoke(item);
            foreach (var listener in _listeners)
            {
                listener.OnEventRaised(item);
            }
        }
        public void RegisterListener(IEventListener<T> listener)
        {
            _listeners.Add(listener);
        }
        public void UnregisterListener(IEventListener<T> listener)
        {
            _listeners.Remove(listener);
        }
    }
}

