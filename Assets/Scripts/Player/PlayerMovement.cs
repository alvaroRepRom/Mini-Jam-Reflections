using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private SpriteRenderer sprite;
    private Animator animator;
    private const string HORIZONTAL = "Horizontal";

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // Movement
        float horizontal = Input.GetAxis(HORIZONTAL);
        transform.Translate(horizontal * speed * Time.deltaTime * Vector2.right);
        // Animation and Sprite direction
        animator.SetFloat(HORIZONTAL, Mathf.Abs(horizontal));
        sprite.flipX = horizontal < 0;
    }
}
