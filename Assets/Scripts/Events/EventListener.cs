using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class CustomGameEvent : UnityEvent<Component, object> { }
public class EventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public CustomGameEvent resposta;
    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }
    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
    public void OnEventRaised(Component sender, object data)
    {
        resposta.Invoke(sender, data);
    }
}
