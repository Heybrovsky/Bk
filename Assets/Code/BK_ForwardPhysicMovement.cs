using UnityEngine;

public class BK_ForwardPhysicMovement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed = 10f;

    [Header("Components")]
    private Transform myTransform = null;
    private Rigidbody2D myRigidbody = null;

    private void Awake()
    {
        myTransform = transform;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = moveSpeed * myTransform.right;
    }
}
