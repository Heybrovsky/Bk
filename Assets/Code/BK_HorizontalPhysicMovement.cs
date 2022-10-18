using UnityEngine;

public class BK_HorizontalPhysicMovement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed = 10f;

    [Header("Components")]
    private Rigidbody2D myRigidbody = null;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, moveSpeed * Time.deltaTime);
        //}
        myRigidbody.angularVelocity = -moveSpeed * Input.GetAxis("Horizontal");
    }
}
