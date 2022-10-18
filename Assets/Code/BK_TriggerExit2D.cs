using System;
using UnityEngine;
using UnityEngine.Events;

public class BK_TriggerExit2D : MonoBehaviour
{ 
    [Header("Events")]
    [SerializeField] private UnityEvent<Collider2D> onTriggerExit2DEvent = null;

    private void OnTriggerExit2D(Collider2D _collision)
    {
        onTriggerExit2DEvent?.Invoke(_collision);
    }

    public void AddOnTriggerExit2DCallback(Action<Collider2D> _callback)
    {
        onTriggerExit2DEvent.AddListener((_a) => _callback?.Invoke(_a));
    }
}
