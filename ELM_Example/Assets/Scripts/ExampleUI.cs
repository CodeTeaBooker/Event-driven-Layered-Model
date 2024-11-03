using TMPro;
using UnityEngine;

public class ExampleUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    public void DisplayMessage(string message)
    {
        _textMeshPro.text = message;
    }
}
