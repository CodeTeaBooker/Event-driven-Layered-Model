using UnityEngine;
using UnityEngine.Events;


namespace ELM_Example.EventSystem
{
    public abstract class EventListener<TEvent, TPublisher> : MonoBehaviour, IEventListener<TEvent>
        where TPublisher : EventPublisher<TEvent>
    {
        [SerializeField] private TPublisher _eventPublisher;
        [SerializeField] private UnityEvent<TEvent> _unityEventResponse;
        protected virtual void OnEnable()
        {
            _eventPublisher?.RegisterListener(this);
        }
        protected virtual void OnDisable()
        {
            _eventPublisher?.UnregisterListener(this);
        }
        public virtual void OnEventRaised(TEvent item)
        {
            _unityEventResponse?.Invoke(item);
        }
    }

}
