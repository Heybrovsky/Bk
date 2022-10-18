using System;
using UnityEngine;
using UnityEngine.Events;

public class BK_PushButton : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private Color pressedColor = Color.green;
    [SerializeField] private Color releasedColor = Color.white;

    private bool isPressed = false;

    public bool IsPressed
    {
        get => isPressed;
        private set
        {
            isPressed = value;

            refreshBodySpriteRenderer();

            if (isPressed)
            {
                onPressedEvent?.Invoke();
            }
            else
            {
                onReleasedEvent?.Invoke();
            }
        }
    }

    [Header("Events")]
    [SerializeField] private UnityEvent onPressedEvent = null;
    [SerializeField] private UnityEvent onReleasedEvent = null;

    [Header("References")]
    [SerializeField] private BK_TriggerEnter2D bodyTriggerEnter2D = null;
    [SerializeField] private BK_TriggerExit2D bodyTriggerExit2D = null;
    [SerializeField] private SpriteRenderer bodySpriteRenderer = null;

    private void Awake()
    {
        refreshBodySpriteRenderer();

        bodyTriggerEnter2D.AddOnTriggerEnter2DCallback((_a) => IsPressed = true);
        bodyTriggerExit2D.AddOnTriggerExit2DCallback((_a) => IsPressed = false);
    }

    public void AddOnPressedCallback(Action _callback)
    {
        onPressedEvent.AddListener(() => _callback?.Invoke());
    }

    public void AddOnReleaseCallback(Action _callback)
    {
        onReleasedEvent.AddListener(() => _callback?.Invoke());
    }

    private void refreshBodySpriteRenderer()
    {
        if (isPressed)
        {
            bodySpriteRenderer.color = pressedColor;
        }
        else
        {
            bodySpriteRenderer.color = releasedColor;
        }
    }
}
