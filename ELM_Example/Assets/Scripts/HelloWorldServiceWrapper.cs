using ELM_Example.EventSystem;
using UnityEngine;

public class HelloWorldServiceWrapper : MonoBehaviour
{
    [SerializeField]
    private StringEventChannel _messageChannel;
    private HelloWorldService _helloWorldService = new HelloWorldService();

    private void Start()
    {
        PrintHelloWorld();
    }

    private void PrintHelloWorld()
    {
        string message = _helloWorldService.GetHelloWorld();
        _messageChannel?.Raise(message);
    }

}
