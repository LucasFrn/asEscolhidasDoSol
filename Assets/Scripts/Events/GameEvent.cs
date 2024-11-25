using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvents")]
public class GameEvent : ScriptableObject
{
    public List<EventListener> listeners = new List<EventListener>();
    public void Raise(Component sender, object data)
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised(sender, data);
        }
    }

    public void AddListener(EventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }
    public void RemoveListener(EventListener listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }

}
