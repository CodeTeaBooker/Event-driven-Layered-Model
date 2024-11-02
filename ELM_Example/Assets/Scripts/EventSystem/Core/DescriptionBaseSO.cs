using UnityEngine;

namespace ELM_Example.Core
{
    public class DescriptionBaseSO : SerializableScriptableObject
    {
        [TextArea] public string Description;
    }
}

