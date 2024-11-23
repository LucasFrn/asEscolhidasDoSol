using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class CustomGameEvent : UnityEvent<Component, object> { }
public class EventListener : MonoBehaviour
{
    public GameEvent combatEvents;
    public CustomGameEvent resposta;
    private void OnEnable()
    {
        combatEvents.AddListener(this);
    }
    private void OnDisable()
    {
        combatEvents.RemoveListener(this);
    }
    public void OnEventRaised(Component sender, object data)
    {
        resposta.Invoke(sender, data);
    }
}
