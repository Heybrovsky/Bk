using UnityEngine;

public class BK_TargetFollower : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private Transform targetToFollow = null;

    [Header("Components")]
    private Transform myTransform = null;

    private void Awake()
    {
        myTransform = transform;
    }

    private void Update()
    {
        myTransform.position = targetToFollow.position;
    }
}
