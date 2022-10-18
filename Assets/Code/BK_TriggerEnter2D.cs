using System;
using UnityEngine;
using UnityEngine.Events;

public class BK_TriggerEnter2D : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent<Collider2D> onTriggerEnter2DEvent = null;

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        onTriggerEnter2DEvent?.Invoke(_collision);
    }

    public void AddOnTriggerEnter2DCallback(Action<Collider2D> _callback)
    {
        onTriggerEnter2DEvent.AddListener((_a) => _callback?.Invoke(_a));
    }
}
