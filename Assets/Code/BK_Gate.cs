using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BK_Gate : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float openDuration = 3f;

    private bool isOpened = false;

    public bool IsOpened
    {
        get => isOpened;
        private set
        {
            isOpened = value;
        }
    }

    [Header("References")]
    [SerializeField] private Transform body = null;

    private void Update()
    {
        if(isOpened)
        {
            body.localScale = Vector3.MoveTowards(body.localScale, new Vector3(0f, body.localScale.y, body.localScale.z), openDuration * Time.deltaTime);
        }
        else
        {
            body.localScale = Vector3.MoveTowards(body.localScale, new Vector3(5f, body.localScale.y, body.localScale.z), openDuration * Time.deltaTime);
        }
    }

    public void Open()
    {
        IsOpened = true;
    }

    public void Close()
    {
        IsOpened = false;
    }
}
