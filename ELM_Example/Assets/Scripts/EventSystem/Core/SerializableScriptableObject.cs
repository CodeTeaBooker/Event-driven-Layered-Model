using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


namespace ELM_Example.Core
{
    [ExecuteAlways]
    public class SerializableScriptableObject : ScriptableObject
    {
        [SerializeField, HideInInspector]
        private string _guid;

        public string Guid => _guid;

        protected virtual void OnEnable()
        {
#if UNITY_EDITOR
            EnsureValidGuid();
#endif
        }

        protected virtual void OnValidate()
        {
#if UNITY_EDITOR
            EnsureValidGuid();
#endif
        }


#if UNITY_EDITOR
        private void EnsureValidGuid()
        {
            if (!Application.isEditor && !string.IsNullOrEmpty(_guid))
                return;
            string assetPath = AssetDatabase.GetAssetPath(this);
            if (string.IsNullOrEmpty(assetPath))
                return; // Asset is not yet saved
            string newGuid = AssetDatabase.AssetPathToGUID(assetPath);
            if (_guid != newGuid)
            {
                _guid = newGuid;
                EditorUtility.SetDirty(this);
            }
        }
#endif

    }

}

