using UnityEngine;

public class BK_GateWithPushButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private BK_Gate gate = null;
    [SerializeField] private BK_PushButton pushButton = null;

    private void Awake()
    {
        pushButton.AddOnPressedCallback(() => gate.Open());
        pushButton.AddOnReleaseCallback(() => gate.Close());
    }
}
