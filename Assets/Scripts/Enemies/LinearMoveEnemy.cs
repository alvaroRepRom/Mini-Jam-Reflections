using UnityEngine;

public class LinearMoveEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distanceOnX;
    [SerializeField] private float distanceOnY;

    private SpriteRenderer sprite;
    private Vector2 direction;
    private float yOriginalPos;
    private float xOriginalPos;

    private void Awake() => sprite = GetComponent<SpriteRenderer>();
    private void Start()
    {       
        if (distanceOnX != 0)
            direction = Vector2.left;
        else
        if (distanceOnY != 0)
            direction = Vector2.down;

        xOriginalPos = transform.position.x;
        yOriginalPos = transform.position.y;
    }

    private void Update()
    {
        VerticalMove();
        HorizontalMove();
        transform.Translate(speed * Time.deltaTime * direction);
    }

    private void VerticalMove()
    {
        if (distanceOnY == 0f) return;
        if (transform.position.y > yOriginalPos + distanceOnY)
            direction = Vector2.down;
        if (transform.position.y < yOriginalPos)
            direction = Vector2.up;
    }
    
    private void HorizontalMove()
    {
        if (distanceOnX == 0f) return;
        if (transform.position.x > xOriginalPos + distanceOnX)
        {
            direction = Vector2.left;
            sprite.flipX = false;
        }
        if (transform.position.x < xOriginalPos)
        {
            direction = Vector2.right;
            sprite.flipX = true;
        }
    }
}
