using UnityEngine;

public class Bullet : MonoBehaviour, IBulletDirecion
{
    [SerializeField] private float speed;
    [SerializeField] private float timeToDestroy;

    private SpriteRenderer sprite;
    private Vector2 direction;
    private float timer;

    private void OnEnable() => timer = 0f;
    private void Awake() => sprite = GetComponent<SpriteRenderer>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy") return;
        collision.GetComponent<IDamagable>().Damage();
        DestroyBullet();
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction);
        AutoDestruct();
    }

    private void AutoDestruct()
    {
        timer += Time.deltaTime;
        if (timer >= timeToDestroy)
            DestroyBullet();
    }    
    private void DestroyBullet() => gameObject.SetActive(false);

    public void BulletDirection(bool goLeft)
    {
        if (goLeft)
        {
            direction = Vector2.left;
            sprite.flipX = true;
        }
        else
        {
            direction = Vector2.right;
            sprite.flipX = false;
        }
    }
}

public interface IDamagable
{
    void Damage();
}

public interface IBulletDirecion
{
    void BulletDirection(bool goLeft);
}
