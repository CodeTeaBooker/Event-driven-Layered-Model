using UnityEngine;

namespace ELM_Example.EventSystem
{
    [CreateAssetMenu(fileName = "NewVoidEventChannel", menuName = "ELM_Example/EventSystem/VoidEventChannel")]
    public class VoidEventChannel : EventPublisher<Void>
    {
        public void Raise()
        {
            base.Raise(new Void());
        }
    }
}