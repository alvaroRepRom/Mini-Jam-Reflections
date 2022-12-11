using UnityEngine;

public class Jumping : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float rayLenght;
    [SerializeField] private Vector3 leftRayPos;
    [SerializeField] private Vector3 rightRayPos;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Debug.DrawRay(transform.position + leftRayPos, Vector2.down, Color.red);
        Debug.DrawRay(transform.position + rightRayPos, Vector2.down, Color.red);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !IsOnWall())
            Jump();
    }

    private void FixedUpdate()
    {
        Gravity();
    }

    private void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        bool leftRay = Physics2D.Raycast(transform.position + leftRayPos, Vector2.down, rayLenght, groundLayer);
        bool rightRay = Physics2D.Raycast(transform.position + rightRayPos, Vector2.down, rayLenght, groundLayer);
        return leftRay || rightRay;
    }

    private bool IsOnWall()
    {
        bool leftRay = Physics2D.Raycast(transform.position + leftRayPos, Vector2.left, rayLenght, groundLayer);
        bool rightRay = Physics2D.Raycast(transform.position + rightRayPos, Vector2.right, rayLenght, groundLayer);
        return leftRay || rightRay;
    }

    private void Gravity()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = 2f;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }
}
