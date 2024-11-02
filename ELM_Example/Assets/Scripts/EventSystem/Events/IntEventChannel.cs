using UnityEngine;

namespace ELM_Example.EventSystem
{
    [CreateAssetMenu(fileName = "NewIntEventChannel", menuName = "ELM_Example/EventSystem/IntEventChannel")]
    public class IntEventChannel : EventPublisher<int> { }
}

