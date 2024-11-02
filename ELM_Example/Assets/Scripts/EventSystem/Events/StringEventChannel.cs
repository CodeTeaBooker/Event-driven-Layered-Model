using UnityEngine;

namespace ELM_Example.EventSystem
{
    [CreateAssetMenu(fileName = "NewStringEventChannel", menuName = "ELM_Example/EventSystem/StringEventChannel")]
    public class StringEventChannel : EventPublisher<string> { }
}
