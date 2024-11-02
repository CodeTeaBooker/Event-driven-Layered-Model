namespace ELM_Example.EventSystem
{
    public interface IEventListener<in T>
    {
        void OnEventRaised(T item);
    }
}
